using Microsoft.OpenApi.Models;
using Novel.Application;
using Novel.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Novel.WebApplication.Host;

[DependsOn(typeof(AbpAutofacModule))]
[DependsOn(typeof(AbpAspNetCoreMvcModule))]
[DependsOn(typeof(NovelApplicationModule))]
[DependsOn(typeof(NovelEntityFrameworkModule))]
public class NovelWebApplicationHostModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAspNetCoreMvcOptions>(
            options =>
            {
                options
                    .ConventionalControllers
                    .Create(typeof(NovelApplicationModule).Assembly);
            });

        context.Services
            .AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v01", new OpenApiInfo {Title = "Novel API", Version = "V01", Description = "The first document version"});
                    options.DocInclusionPredicate((docName, decription) => true);
                    options.CustomSchemaIds(type => type.FullName);
                })
            .AddMvcCore()
            .AddApiExplorer();
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var env = context.GetEnvironment();
        var app = context.GetApplicationBuilder();

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();

        app.UseHttpsRedirection()
            .UseStaticFiles()
            .UseRouting()
            .UseSwaggerUI(
                options =>
                {
                    options.SwaggerEndpoint("/swagger/v01/swagger.json", "Novel API");
                })
            .UseConfiguredEndpoints();
    }
}