using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HomeMAUI.Models;
using HomeMAUI.Services;

namespace HomeMAUI.ViewModels;

public partial class HomeViewModel : BaseViewModel
{
    public const string Route = nameof(HomeViewModel);

    public ObservableCollection<BleDevice> Devices { get; } = new();

    [ObservableProperty]
    BleDevice? selectedDevice;

    public override Task InitializeAsync()
    {
        var rand = new Random();
        for (int i = 1; i <= 20; i++)
        {
            Devices.Add(new BleDevice
            {
                Name = $"Device {i}",
                Rssi = rand.Next(-90, -30),
                BleAddress = string.Join(":", Enumerable.Range(0, 6).Select(_ => rand.Next(0, 256).ToString("X2")))
            });
        }
        return Task.CompletedTask;
    }

    partial void OnSelectedDeviceChanged(BleDevice? value)
    {
        if (value != null)
        {
            SelectDeviceCommand.Execute(value);
        }
    }

    [RelayCommand]
    async Task SelectDevice(BleDevice device)
    {
        await GetService<INavigationService>().GoToAsync(nameof(ConnectViewModel), device);
        SelectedDevice = null;
    }
}
