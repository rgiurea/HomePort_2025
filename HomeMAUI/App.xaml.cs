using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace HomeMAUI;

public partial class App : Application
{
    public event EventHandler? AppToBackground;
    public event EventHandler? AppToForeground;

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    protected override void OnSleep()
    {
        AppToBackground?.Invoke(this, EventArgs.Empty);
        base.OnSleep();
    }

    protected override void OnResume()
    {
        AppToForeground?.Invoke(this, EventArgs.Empty);
        base.OnResume();
    }
}