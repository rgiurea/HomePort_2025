using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using HomeMAUI.Models;

namespace HomeMAUI;

public partial class MainPage : ContentPage
{
    public ObservableCollection<BleDevice> Devices { get; } = new()
    {
        new BleDevice { Name = "Device A", Rssi = -42, BleAddress = "AA:BB:CC:DD:EE:FF" },
        new BleDevice { Name = "Device B", Rssi = -55, BleAddress = "11:22:33:44:55:66" },
        new BleDevice { Name = "Device C", Rssi = -60, BleAddress = "77:88:99:AA:BB:CC" }
    };

    public MainPage()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private async void OnDeviceSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is BleDevice device)
        {
            await Navigation.PushAsync(new ConnectPage(device));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
