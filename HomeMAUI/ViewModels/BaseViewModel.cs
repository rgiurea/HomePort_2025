using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.DependencyInjection;
using HomeMAUI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HomeMAUI.ViewModels;

public abstract partial class BaseViewModel : ObservableObject
{
    private IDictionary<string, object>? _parameters;
    private bool _initialized;

    protected IServiceProvider Services => Ioc.Default;

    protected T GetService<T>() where T : notnull => Services.GetRequiredService<T>();

    protected INavigationService Navigation => GetService<INavigationService>();

    public virtual void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        _parameters = query;
    }

    protected T? GetParameter<T>(string key = "parameter")
    {
        if (_parameters != null && _parameters.TryGetValue(key, out var value) && value is T t)
            return t;
        return default;
    }

    public async Task EnsureInitializedAsync()
    {
        if (_initialized) return;
        _initialized = true;
        await InitializeAsync();
    }

    protected virtual Task InitializeAsync() => Task.CompletedTask;

    public virtual Task OnViewAppearingAsync() => Task.CompletedTask;
    public virtual Task OnViewDisappearingAsync() => Task.CompletedTask;
    public virtual Task OnAppToBackgroundAsync() => Task.CompletedTask;
    public virtual Task OnAppToForegroundAsync() => Task.CompletedTask;
    public virtual void OnDestroy() { }
}
