using System.Collections.Generic;
using HomeMAUI.Models;

namespace HomeMAUI.ViewModels;

public partial class ConnectViewModel : BaseViewModel
{
    private Device? _device;

    public string DeviceName => _device?.Name ?? string.Empty;

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        _device = GetParameter<Device>();
        OnPropertyChanged(nameof(DeviceName));
    }

    public override async Task OnViewAppearingAsync()
    {
        await Task.Delay(2000);
        await Navigation.NavigateToAsync<DeviceDashboardViewModel>(_device!);
        var navigation = Shell.Current.Navigation;
        var previous = navigation.NavigationStack[navigation.NavigationStack.Count - 2];
        navigation.RemovePage(previous);
    }
}
