namespace Novel.WebApplication.Host;

/**
 * Ftdabp项目入口
 */
public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Microsoft.Extensions.Hosting.Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                builder =>
                {
                    builder.UseContentRoot(Directory.GetCurrentDirectory());
                    builder.UseIISIntegration();
                    builder.UseStartup<Startup>();
                });
    }
}