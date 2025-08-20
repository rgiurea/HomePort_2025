using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using HomeMAUI.Models;

namespace HomeMAUI.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    public ObservableCollection<Device> Devices { get; } = new();

    protected override Task InitializeAsync()
    {
        var rnd = new Random();
        for (int i = 1; i <= 20; i++)
        {
            Devices.Add(new Device
            {
                Name = $"Device {i}",
                Rssi = rnd.Next(-100, 0),
                BleAddress = rnd.Next(0, int.MaxValue).ToString("X")
            });
        }
        return Task.CompletedTask;
    }

    public IAsyncRelayCommand<Device> SelectDeviceCommand => new AsyncRelayCommand<Device>(OnSelectDeviceAsync);

    private async Task OnSelectDeviceAsync(Device device)
    {
        await Navigation.NavigateToAsync<ConnectViewModel>(device);
    }
}
