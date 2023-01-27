using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Modularity;

namespace ftdnet;

/**
 * 启动模块
 */
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
public class FtdAppModule : AbpModule
{
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var env = context.GetEnvironment();
        var app = context.GetApplicationBuilder();

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseRouting();
        app.UseConfiguredEndpoints();
    }

    /**
     * 模块中注册服务
     */
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        // 注册测试服务类
        context.Services.AddTransient<FuckWorldService>();
    }
}