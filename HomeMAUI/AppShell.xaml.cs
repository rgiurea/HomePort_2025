namespace HomeMAUI;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(MorePage), typeof(MorePage));
    }

    private async void OnMenuClicked(object? sender, EventArgs e)
    {
        string? action = await DisplayActionSheet("Menu", "Cancel", null, "Home", "More");
        if (action == "Home")
        {
            await GoToAsync("//MainPage");
        }
        else if (action == "More")
        {
            await GoToAsync(nameof(MorePage));
        }
    }
}
