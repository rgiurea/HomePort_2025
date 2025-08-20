using System.Collections.Generic;
using HomeMAUI.Models;

namespace HomeMAUI.ViewModels;

public partial class DeviceDashboardViewModel : BaseViewModel
{
    private Device? _device;

    public string DeviceName => _device?.Name ?? string.Empty;

    public override void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        base.ApplyQueryAttributes(query);
        _device = GetParameter<Device>();
        OnPropertyChanged(nameof(DeviceName));
    }
}
