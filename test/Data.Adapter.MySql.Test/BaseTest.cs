using System;
using Data.Common.Test;
using Data.Common.Test.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Mkh.Data.Abstractions;

namespace Data.Adapter.MySql.Test
{
    public class BaseTest
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly IDbContext Context;

        public BaseTest()
        {
            var connString = "Database=blog;Data Source=localhost;Port=3306;User Id=root;Password=root;Charset=utf8;SslMode=None;allowPublicKeyRetrieval=true;";
            var services = new ServiceCollection();
            //��־
            services.AddLogging(builder =>
            {
                builder.AddDebug();
            });

            //�Զ����˻���Ϣ������
            services.AddSingleton<IAccountResolver, CustomAccountResolver>();

            services
                .AddMkhDbWidthMySql<BlogDbContext>(connString)
                .AddRepositories(typeof(BlogDbContext).Assembly);

            ServiceProvider = services.BuildServiceProvider();
            Context = ServiceProvider.GetService<BlogDbContext>();
        }
    }
}