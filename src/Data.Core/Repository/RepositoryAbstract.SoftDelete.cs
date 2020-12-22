﻿using System;
using System.Threading.Tasks;
using Dapper;

namespace Mkh.Data.Core.Repository
{
    public abstract partial class RepositoryAbstract<TEntity>
    {
        public Task<bool> SoftDelete(dynamic id)
        {
            return SoftDelete(id, null);
        }

        protected async Task<bool> SoftDelete(dynamic id, string tableName)
        {
            if (!EntityDescriptor.IsSoftDelete)
                throw new Exception("该实体未继承软删除接口，无法使用软删除功能~");

            PrimaryKeyValidate(id);

            var dynParams = new DynamicParameters();
            dynParams.Add(_adapter.AppendParameter("Id"), id);
            dynParams.Add(_adapter.AppendParameter("DeletedTime"), DateTime.Now);
            dynParams.Add(_adapter.AppendParameter("DeletedBy"), DbContext.AccountResolver.AccountId);
            dynParams.Add(_adapter.AppendParameter("Deleter"), DbContext.AccountResolver.AccountName);

            var sql = _sql.GetSoftDeleteSingle(tableName);

            _logger?.Write("SoftDelete", sql);

            return await Execute(sql, dynParams) > 0;
        }
    }
}
