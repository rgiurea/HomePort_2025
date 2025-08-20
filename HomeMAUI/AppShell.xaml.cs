namespace HomeMAUI;

using HomeMAUI.ViewModels;
using HomeMAUI.Views;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(HomeViewModel), typeof(HomePage));
        Routing.RegisterRoute(nameof(ConnectViewModel), typeof(ConnectPage));
        Routing.RegisterRoute(nameof(DeviceDashboardViewModel), typeof(DeviceDashboardPage));

        Items.Add(new ShellContent
        {
            ContentTemplate = new DataTemplate(typeof(SplashPage)),
            Route = nameof(SplashViewModel)
        });
    }
}
