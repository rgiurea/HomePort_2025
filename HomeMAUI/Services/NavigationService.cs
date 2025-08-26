using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public class NavigationService : INavigationService
{
    public const string ParameterKey = "parameter";

    public async Task GoToAsync(string route, object? parameter = null, bool removePrevious = false)
    {
        
        var dict = new Dictionary<string, object>();
        if (parameter != null)
            dict[ParameterKey] = parameter;
        await Shell.Current.GoToAsync(route, true, dict);
        if (removePrevious)
        {
            var nav = Shell.Current.Navigation;
            var stack = nav.NavigationStack;
            if (stack.Count > 1)
            {
                var previousPage = stack[stack.Count - 2];
                nav.RemovePage(previousPage);
            }
        }
    }

    public Task GoBackAsync() => Shell.Current.GoToAsync("..");
}
