using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Device = HomeMAUI.Models.Device;

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
        await Navigation.NavigateToAsync(nameof(DeviceDashboardViewModel), _device!);
        var navigation = Shell.Current.Navigation;
        var previous = navigation.NavigationStack[navigation.NavigationStack.Count - 2];
        navigation.RemovePage(previous);
    }
}
