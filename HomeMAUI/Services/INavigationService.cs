using System.Threading.Tasks;
using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public interface INavigationService
{
    Task GoToAsync<TViewModel>(object? parameter = null, bool removePrevious = false) where TViewModel : BaseViewModel;
    Task GoBackAsync();
}
