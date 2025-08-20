using System.Threading.Tasks;

namespace HomeMAUI.ViewModels;

public partial class SplashViewModel : BaseViewModel
{
    public override async Task OnViewAppearingAsync()
    {
        await Task.Delay(2000);
        await Navigation.NavigateToAsync<HomeViewModel>();
    }
}
