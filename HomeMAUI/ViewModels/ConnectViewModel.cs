using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HomeMAUI.Models;
using HomeMAUI.Services;

namespace HomeMAUI.ViewModels;

public partial class ConnectViewModel : BaseViewModel
{
    public const string Route = nameof(ConnectViewModel);

    [ObservableProperty]
    BleDevice? device;

    public override Task InitializeAsync()
    {
        Device = GetParameter<BleDevice>();
        return Task.CompletedTask;
    }

    public override async Task OnViewAppeared()
    {
        await Task.Delay(2000);
        if (Device != null)
            await GetService<INavigationService>().GoToAsync(nameof(DeviceDashboardViewModel), Device, true);
    }
}
