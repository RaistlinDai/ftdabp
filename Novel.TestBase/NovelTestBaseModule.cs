using Microsoft.Extensions.DependencyInjection;
using Novel.Domain;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Novel.TestBase;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpTestBaseModule))]
[DependsOn(typeof(NovelDomainModule))]
public class NovelTestBaseModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {

    }
    
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

    }
    
    public override void PostConfigureServices(ServiceConfigurationContext context)
    {

    }
    
    public override void OnPreApplicationInitialization(ApplicationInitializationContext context)
    {

    }
    
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        AsyncHelper.RunSync(
            async () =>
            {
                // 加载数据种子
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .SeedAsync();
            });
    }
    
    public override void OnPostApplicationInitialization(ApplicationInitializationContext context)
    {

    }
    
    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {

    }
}