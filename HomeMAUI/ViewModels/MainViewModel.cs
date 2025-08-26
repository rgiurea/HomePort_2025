using System.Collections.ObjectModel;
using HomeMAUI.Models;

namespace HomeMAUI.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Device> Devices { get; } = new()
    {
        new Device { Name = "Device 1", Rssi = -40, BleAddress = "AA:BB:CC:DD:EE:01" },
        new Device { Name = "Device 2", Rssi = -55, BleAddress = "AA:BB:CC:DD:EE:02" },
        new Device { Name = "Device 3", Rssi = -60, BleAddress = "AA:BB:CC:DD:EE:03" }
    };
}
