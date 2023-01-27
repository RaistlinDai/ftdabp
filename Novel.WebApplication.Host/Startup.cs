namespace Novel.WebApplication.Host;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 启动模块注册到容器中
        services.AddApplication<NovelWebApplicationHostModule>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // 初始化app应用
        app.InitializeApplication();
    }
}