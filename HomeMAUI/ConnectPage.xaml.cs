using System.Threading.Tasks;
using HomeMAUI.Models;
using Microsoft.Maui.Controls;

namespace HomeMAUI;

public partial class ConnectPage : ContentPage
{
    private readonly BleDevice _device;

    public ConnectPage(BleDevice device)
    {
        InitializeComponent();
        _device = device;
        BindingContext = _device;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(2000);
        await Navigation.PushAsync(new DeviceDashboardPage(_device));
        Navigation.RemovePage(this);
    }
}
