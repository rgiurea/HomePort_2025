using Microsoft.Maui;
using Microsoft.Maui.Controls;
using HomeMAUI.ViewModels;

namespace HomeMAUI;

public partial class App : Application
{
        public App()
        {
                InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
                return new Window(new AppShell());
        }

        static BaseViewModel? GetCurrentViewModel()
        {
                if (Current?.MainPage is Shell shell)
                        return shell.CurrentPage?.BindingContext as BaseViewModel;
                return null;
        }

        protected override void OnStart()
        {
                base.OnStart();
                GetCurrentViewModel()?.OnAppToForeground();
        }

        protected override void OnSleep()
        {
                base.OnSleep();
                GetCurrentViewModel()?.OnAppToBackground();
        }

        protected override void OnResume()
        {
                base.OnResume();
                GetCurrentViewModel()?.OnAppToForeground();
        }
}