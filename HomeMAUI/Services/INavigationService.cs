using System.Threading.Tasks;
using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public interface INavigationService
{
    Task NavigateToAsync(string uri, object? parameter = null);
    Task GoBackAsync();
}
