using System.Collections.Generic;
using System.Threading.Tasks;
using HomeMAUI.Models;

namespace HomeMAUI;

[QueryProperty(nameof(Device), "device")]
public partial class ConnectPage : ContentPage
{
    public ConnectPage()
    {
        InitializeComponent();
    }

    public Device? Device
    {
        get => BindingContext as Device;
        set => BindingContext = value;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await Task.Delay(2000);
        await Shell.Current.GoToAsync(nameof(DeviceDashboardPage), new Dictionary<string, object>
        {
            { "device", Device! }
        });
        Shell.Current.Navigation.RemovePage(this);
    }
}
