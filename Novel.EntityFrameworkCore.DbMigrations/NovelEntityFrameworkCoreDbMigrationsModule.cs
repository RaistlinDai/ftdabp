using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Novel.EntityFrameworkCore;

/// <summary>
/// EntityFramework Migration 模块
/// </summary>
[DependsOn(typeof(NovelEntityFrameworkModule))]
public class NovelEntityFrameworkCoreDbMigrationsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NovelMigurationDbContext>();
    }
}