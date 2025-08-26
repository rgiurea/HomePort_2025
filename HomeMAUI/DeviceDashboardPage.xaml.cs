using Microsoft.Maui.Controls;
using HomeMAUI.Models;

namespace HomeMAUI;

public partial class DeviceDashboardPage : ContentPage
{
    public DeviceDashboardPage(BleDevice bleDevice)
    {
        InitializeComponent();
        BindingContext = bleDevice;
    }
}
