using Microsoft.Maui.Controls;
using HomeMAUI.Models;

namespace HomeMAUI;

public partial class DeviceDashboardPage : ContentPage
{
    public DeviceDashboardPage(Device device)
    {
        InitializeComponent();
        BindingContext = device;
    }
}
