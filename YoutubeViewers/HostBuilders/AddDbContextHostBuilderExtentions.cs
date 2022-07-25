using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YoutubeViewer.EnitityFramework;

namespace YoutubeViewers.HostBuilders
{
    public static class AddDbContextHostBuilderExtentions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host = Host.CreateDefaultBuilder().AddDbContext().ConfigureServices((context, services) =>
            {
                string connectionstring = context.Configuration.GetConnectionString("sqllite");
                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionstring).Options);
                services.AddSingleton<YoutubeViewersDbContextFactory>();
            });
            return host;
        }
    }
}
