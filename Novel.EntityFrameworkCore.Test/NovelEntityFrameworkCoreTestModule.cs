using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Novel.TestBase;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;

namespace Novel.EntityFrameworkCore.Test;

[DependsOn(typeof(AbpEntityFrameworkCoreSqliteModule))]
[DependsOn(typeof(NovelTestBaseModule))]
[DependsOn(typeof(NovelEntityFrameworkModule))]
public class NovelEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection _sqliteConnection;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();
        context.Services.Configure<AbpDbContextOptions>(
            options =>
            {
                options.Configure(configurationContext =>
                    configurationContext.DbContextOptions.UseSqlite(_sqliteConnection));
            });
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }

    /// <summary>
    /// 测试数据库连接池 - Sqlite
    /// </summary>
    /// <returns></returns>
    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<NovelDbContext>()
            .UseSqlite(connection)
            .Options;

        // Sqlite中创建数据库表
        using var context = new NovelDbContext(options);
        context.GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }
}