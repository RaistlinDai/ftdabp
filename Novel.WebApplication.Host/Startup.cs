using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace Novel.WebApplication.Host;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // 启动模块注册到容器中
        services.AddApplication<NovelWebApplicationHostModule>();
        // 添加Swagger
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // 初始化app应用
        app.InitializeApplication();
        // 添加Swagger
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}