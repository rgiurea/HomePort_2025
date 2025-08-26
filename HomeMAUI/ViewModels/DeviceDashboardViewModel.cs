using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HomeMAUI.Models;

namespace HomeMAUI.ViewModels;

public partial class DeviceDashboardViewModel : BaseViewModel
{
    public const string Route = nameof(DeviceDashboardViewModel);

    [ObservableProperty]
    BleDevice? device;

    public override Task InitializeAsync()
    {
        Device = GetParameter<BleDevice>();
        return Task.CompletedTask;
    }
}
