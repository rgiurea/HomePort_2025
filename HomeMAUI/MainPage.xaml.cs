using System.Linq;
using HomeMAUI.Models;
using HomeMAUI.ViewModels;

namespace HomeMAUI;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
    }

    async void OnDeviceSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Device device)
        {
            await Shell.Current.GoToAsync(nameof(ConnectPage), new Dictionary<string, object>
            {
                { "device", device }
            });
            ((CollectionView)sender!).SelectedItem = null;
        }
    }
}
