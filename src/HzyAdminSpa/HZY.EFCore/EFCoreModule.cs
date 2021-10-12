using HZY.EFCore.DbContexts;
using HZY.EFCore.Impl;
using HZY.EFCore.Interface;
using HZY.EFCore.Repositories;
using HZY.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HZY.EFCore;

/// <summary>
/// 仓储模块
/// </summary>
public class EFCoreModule
{
    /// <summary>
    /// 注册 Admin 后台管理数据库
    /// </summary>
    /// <param name="services"></param>
    /// <param name="connectionString">默认数据库连接字符串</param>
    /// <param name="defaultDatabaseType">默认数据库类型</param>
    public static void RegisterAdminRepository(IServiceCollection services, string connectionString, DefaultDatabaseType defaultDatabaseType)
    {
        #region 后台 管理系统 数据库上下文

        services.AddDbContext<AdminBaseDbContext>(options =>
        {

            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            .UseLazyLoadingProxies()
            ;
            //无跟踪
            // .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)

            if (defaultDatabaseType == DefaultDatabaseType.SqlServer)
            {
                #region SqlSever
                options.UseSqlServer(connectionString, w => w.MinBatchSize(1).MaxBatchSize(500));
                #endregion
            }

            if (defaultDatabaseType == DefaultDatabaseType.MySql)
            {
                #region MySql
                options.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion, w => w.MinBatchSize(1).MaxBatchSize(500));
                #endregion
            }

            if (defaultDatabaseType == DefaultDatabaseType.PostgreSql)
            {
                #region Npgsql
                options.UseNpgsql(connectionString, w => w.MinBatchSize(1).MaxBatchSize(500));
                #endregion
            }

        });

        #endregion

        services.AddSingleton<ICacheEntity, CacheEntityImpl>();
        services.AddTransient(typeof(EFCoreBaseRepository<>));
    }




}
