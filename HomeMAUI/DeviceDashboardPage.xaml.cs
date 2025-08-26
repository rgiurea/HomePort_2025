using HomeMAUI.Models;

namespace HomeMAUI;

[QueryProperty(nameof(Device), "device")]
public partial class DeviceDashboardPage : ContentPage
{
    public DeviceDashboardPage()
    {
        InitializeComponent();
    }

    public Device? Device
    {
        get => BindingContext as Device;
        set => BindingContext = value;
    }
}
