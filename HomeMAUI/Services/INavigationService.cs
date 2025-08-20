using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public interface INavigationService
{
    Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : BaseViewModel;
    Task GoBackAsync();
}
