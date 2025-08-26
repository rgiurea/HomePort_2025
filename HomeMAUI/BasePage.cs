using System.Collections.Generic;
using HomeMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace HomeMAUI;

public class BasePage : ContentPage, IQueryAttributable
{
    bool _initialized;

    public BaseViewModel? ViewModel => BindingContext as BaseViewModel;

    public BasePage()
    {
        Unloaded += (_, __) => ViewModel?.OnDestroy();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (!_initialized && ViewModel != null)
        {
            _initialized = true;
            await ViewModel.InitializeAsync();
        }
        if (ViewModel != null)
            await ViewModel.OnViewAppeared();
    }

    protected override async void OnDisappearing()
    {
        if (ViewModel != null)
            await ViewModel.OnViewDisappeared();
        base.OnDisappearing();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ViewModel?.ApplyQueryAttributes(query);
    }
}
