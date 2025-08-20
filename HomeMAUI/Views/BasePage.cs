using HomeMAUI.ViewModels;
using System;

namespace HomeMAUI.Views;

public class BasePage<TViewModel> : ContentPage, IQueryAttributable where TViewModel : BaseViewModel
{
    public BasePage()
    {
        Appearing += async (s, e) =>
        {
            await ViewModel.EnsureInitializedAsync();
            await ViewModel.OnViewAppearingAsync();
        };
        Disappearing += async (s, e) =>
        {
            await ViewModel.OnViewDisappearingAsync();
        };

        if (Application.Current is App app)
        {
            app.AppToBackground += OnAppToBackground;
            app.AppToForeground += OnAppToForeground;
        }
    }

    protected TViewModel ViewModel => (TViewModel)BindingContext;

    private void OnAppToBackground(object? sender, EventArgs e) => ViewModel.OnAppToBackgroundAsync();
    private void OnAppToForeground(object? sender, EventArgs e) => ViewModel.OnAppToForegroundAsync();

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ViewModel.ApplyQueryAttributes(query);
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler == null)
        {
            if (Application.Current is App app)
            {
                app.AppToBackground -= OnAppToBackground;
                app.AppToForeground -= OnAppToForeground;
            }
            ViewModel.OnDestroy();
        }
    }
}
