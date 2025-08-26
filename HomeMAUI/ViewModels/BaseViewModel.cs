using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Maui.Controls;
using HomeMAUI.Services;

namespace HomeMAUI.ViewModels;

public abstract partial class BaseViewModel : ObservableObject, IQueryAttributable
{
    IDictionary<string, object>? _parameters;

    protected TService GetService<TService>() where TService : class =>
        Ioc.Default.GetRequiredService<TService>();

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _parameters = query;
    }

    protected T? GetParameter<T>(string key = NavigationService.ParameterKey)
    {
        if (_parameters != null && _parameters.TryGetValue(key, out var value) && value is T t)
            return t;
        return default;
    }

    public virtual Task InitializeAsync() => Task.CompletedTask;
    public virtual Task OnViewAppeared() => Task.CompletedTask;
    public virtual Task OnViewDisappeared() => Task.CompletedTask;
    public virtual void OnDestroy() { }
    public virtual void OnAppToBackground() { }
    public virtual void OnAppToForeground() { }
}
