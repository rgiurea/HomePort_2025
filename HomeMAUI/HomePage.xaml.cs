using System.Linq;
using HomeMAUI.Models;
using HomeMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace HomeMAUI;

public partial class HomePage : BasePage
{
    public HomePage()
    {
        InitializeComponent();
    }

    void OnDeviceSelected(object? sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is BleDevice device && BindingContext is HomeViewModel vm)
        {
            vm.SelectDeviceCommand.Execute(device);
        }

        if (sender is CollectionView collectionView)
        {
            collectionView.SelectedItem = null;
        }
    }
}
