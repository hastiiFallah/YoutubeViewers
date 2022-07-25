using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using YoutubeViewer.Domain.Commands;
using YoutubeViewer.Domain.Queries;
using YoutubeViewer.EnitityFramework;
using YoutubeViewer.EnitityFramework.Commands;
using YoutubeViewer.EnitityFramework.Queries;
using YoutubeViewers.Stores;
using YoutubeViewers.ViewModels;
using YoutubeViewers.HostBuilders;

namespace YoutubeViewers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            _host = Host.CreateDefaultBuilder().AddDbContext().ConfigureServices((context, services) =>
            {
                services.AddSingleton<IGetAllYoutubeViewerQuery,GetAllYoutubeViewerQuery>();
                services.AddSingleton<ICreateYoutubeViewerCommand,CreateYoutubeViewerCommand>();
                services.AddSingleton<IDeleteYoutubeViewerCommand,DeleteYoutubeViewerCommand>();
                services.AddSingleton<IUpdateYoutubeViewerCommand,UpdateYoutubeViewerCommand>();
                services.AddSingleton<ModelNavigationStore>();
                services.AddSingleton<YoutubeViewerStore>();
                services.AddSingleton<SelectedYoutubeViewersStore>();
                services.AddTransient<YoutubeViewersViewModel>(CreateYoutubeViewerViewModel);
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>((services) => new MainWindow()
                {
                    DataContext = services.GetRequiredService<MainViewModel>()
                });
            }).Build();
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            YoutubeViewersDbContextFactory youtubeViewersDb = _host.Services.GetRequiredService<YoutubeViewersDbContextFactory>();

            using (YoutubeViewerDbContext context = youtubeViewersDb.Create())
            {
                context.Database.Migrate();
            }
        
            MainWindow.Show();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
        private YoutubeViewersViewModel CreateYoutubeViewerViewModel(IServiceProvider services)
        {
            return YoutubeViewersViewModel.LoadViewModel(
                services.GetRequiredService<YoutubeViewerStore>(),
                services.GetRequiredService<SelectedYoutubeViewersStore>(),
                services.GetRequiredService<ModelNavigationStore>());
        }
    }
}
