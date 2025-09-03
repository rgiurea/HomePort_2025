using CommunityToolkit.Mvvm.DependencyInjection;
using HomeMAUI.Services;
using HomeMAUI.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace HomeMAUI;

public static class MauiProgram
{
        public static MauiApp CreateMauiApp()
        {
                var builder = MauiApp.CreateBuilder();
                builder
                        .UseMauiApp<App>()
                        .ConfigureSyncfusionCore()
                        .ConfigureFonts(fonts =>
                        {
                                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                        });
                
                builder.Services.AddSingleton<INavigationService, NavigationService>();
                
                // Register ViewModels
                builder.Services.AddTransient<HomeViewModel>();
                builder.Services.AddTransient<ConnectViewModel>();
                builder.Services.AddTransient<DeviceDashboardViewModel>();
                builder.Services.AddTransient<MoreViewModel>();

                // Register Pages
                builder.Services.AddTransient<HomePage>();
                builder.Services.AddTransient<ConnectPage>();
                builder.Services.AddTransient<DeviceDashboardPage>();
                builder.Services.AddTransient<MorePage>();

#if DEBUG
                builder.Logging.AddDebug();
#endif

                var app = builder.Build();
                Ioc.Default.ConfigureServices(app.Services);
                return app;
        }
}
