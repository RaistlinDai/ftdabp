using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Novel.EntityFrameworkCore;

public class NovelEntityFrameworkCoreDbSchemaMigrator : ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public NovelEntityFrameworkCoreDbSchemaMigrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        var context = _serviceProvider
            .GetRequiredService<NovelMigurationDbContext>();
        await context.Database.MigrateAsync();
    }
}