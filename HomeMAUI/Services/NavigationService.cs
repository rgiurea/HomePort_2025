using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public class NavigationService : INavigationService
{
    public async Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel
    {
        var route = nameof(TViewModel);
        if (parameter is null)
        {
            await Shell.Current.GoToAsync(route);
        }
        else
        {
            var dict = new Dictionary<string, object>
            {
                ["parameter"] = parameter
            };
            await Shell.Current.GoToAsync(route, dict);
        }
    }

    public Task GoBackAsync()
    {
        return Shell.Current.GoToAsync("..");
    }
}
