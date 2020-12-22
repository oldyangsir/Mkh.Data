﻿using System.Linq.Expressions;

namespace Mkh.Data.Core.Queryable.Internal
{
    /// <summary>
    /// 查询更新信息
    /// </summary>
    internal class QueryUpdate
    {
        /// <summary>
        /// 模式
        /// </summary>
        public QueryUpdateMode Mode { get; set; }

        /// <summary>
        /// Lambda
        /// </summary>
        public LambdaExpression Lambda { get; set; }

        /// <summary>
        /// SQL语句
        /// </summary>
        public string Sql { get; set; }
    }

    /// <summary>
    /// 查询更新模式
    /// </summary>
    internal enum QueryUpdateMode
    {
        /// <summary>
        /// Lambda
        /// </summary>
        Lambda,
        /// <summary>
        /// SQL语句
        /// </summary>
        Sql
    }
}
