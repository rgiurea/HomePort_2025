using System.Collections.Generic;
using System.Threading.Tasks;
using HomeMAUI.ViewModels;
using Microsoft.Maui.Controls;

namespace HomeMAUI.Services;

public class NavigationService : INavigationService
{
    public async Task NavigateToAsync(string uri, object? parameter = null)
    {
        if (parameter is null)
        {
            await Shell.Current.GoToAsync(uri);
        }
        else
        {
            var dict = new Dictionary<string, object>
            {
                ["parameter"] = parameter
            };
            await Shell.Current.GoToAsync(uri, dict);
        }
    }

    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}
