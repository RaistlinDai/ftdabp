using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Novel.EntityFrameworkCore;

public class NovelMigrationsDbContextFactory : IDesignTimeDbContextFactory<NovelMigurationDbContext>
{
    public NovelMigurationDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();
        var connectionString = configuration.GetConnectionString("MySqlConnection");
        var builder = new DbContextOptionsBuilder<NovelMigurationDbContext>()
            .UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString));
        return new NovelMigurationDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);
        return builder.Build();
    }
}