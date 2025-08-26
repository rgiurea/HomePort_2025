using Microsoft.Maui.Controls;
using HomeMAUI.ViewModels;

namespace HomeMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ConnectViewModel), typeof(ConnectPage));
        Routing.RegisterRoute(nameof(DeviceDashboardViewModel), typeof(DeviceDashboardPage));
    }
}
