using Microsoft.Extensions.DependencyInjection;
using Novel.Domain;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Novel.TestBase;

[DependsOn(typeof(AbpAutofacModule), typeof(AbpTestBaseModule), typeof(NovelDomainModule))]
public class NovelTestBaseModule : AbpModule
{
    /// <summary>
    /// 加载公共数据种子
    /// </summary>
    /// <param name="context"></param>
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
}