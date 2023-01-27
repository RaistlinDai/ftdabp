using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Novel.Domain.Book.Entities;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;
using Volo.Abp.EntityFrameworkCore.MySQL;
using Volo.Abp.Modularity;

namespace Novel.EntityFrameworkCore;

[DependsOn(typeof(AbpEntityFrameworkCoreModule))]
[DependsOn(typeof(AbpEntityFrameworkCoreMySQLModule))]
public class NovelEntityFrameworkModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<NovelDbContext>(
            options =>
            {
                // Abp自动为数据上下文中的数据实体创建仓储（Domain层与数据层的桥梁）
                options.AddDefaultRepositories(true);
                
                // 设置Book级联查询
                options.Entity<Book>(
                    opt =>
                    {
                        opt.DefaultWithDetailsFunc = 
                            queryable => queryable
                                .Include(book => book.Volumes)
                                .ThenInclude(volume => volume.Chapters);
                    });
            });
        
        Configure<AbpDbContextOptions>(
            options =>
            {
                // 数据上下文使用MySql
                options.UseMySQL();
            });
    }
}