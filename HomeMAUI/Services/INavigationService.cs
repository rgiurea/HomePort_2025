using System.Threading.Tasks;
using HomeMAUI.ViewModels;

namespace HomeMAUI.Services;

public interface INavigationService
{
    Task GoToAsync(string route, object? parameter = null, bool removePrevious = false);
    Task GoBackAsync();
}
