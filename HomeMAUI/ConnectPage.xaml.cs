using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using HomeMAUI.Models;

namespace HomeMAUI;

public partial class ConnectPage : ContentPage
{
    private readonly Device _device;

    public ConnectPage(Device device)
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
