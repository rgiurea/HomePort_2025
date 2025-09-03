using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using HomeMAUI.Models;
using HomeMAUI.Services;

namespace HomeMAUI.ViewModels;

public partial class ConnectViewModel : BaseViewModel
{
    public const string Route = nameof(ConnectViewModel);
    private CancellationTokenSource? _cancellationTokenSource;

    [ObservableProperty]
    BleDevice? device;

    public override Task InitializeAsync()
    {
        Device = GetParameter<BleDevice>();
        return Task.CompletedTask;
    }

    public override async Task OnViewAppeared()
    {
        _cancellationTokenSource = new CancellationTokenSource();
        try
        {
            await Task.Delay(2000, _cancellationTokenSource.Token);
            if (Device != null && !_cancellationTokenSource.Token.IsCancellationRequested)
                await GetService<INavigationService>().GoToAsync(nameof(DeviceDashboardViewModel), Device, true);
        }
        catch (TaskCanceledException)
        {
            // Expected when navigation is cancelled
        }
    }

    public override void OnDestroy()
    {
        _cancellationTokenSource?.Cancel();
        _cancellationTokenSource?.Dispose();
        base.OnDestroy();
    }
}
