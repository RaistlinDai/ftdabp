using Microsoft.Extensions.DependencyInjection;
using Novel.Application.Author.Profiles;
using Novel.Application.Book.Profiles;
using Novel.Domain;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Novel.Application;

/// <summary>
/// 应用服务Application实现类，使用AutoMapper将App应用层Dto与Domain层实体绑定
/// </summary>
[DependsOn(typeof(AbpAutoMapperModule))]
[DependsOn(typeof(NovelDomainModule))]
public class NovelApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.Configure<AbpAutoMapperOptions>(
            options =>
            {
                options.AddProfile<AuthorProfile>(true);
                options.AddProfile<BookProfile>(true);
            });
    }
}