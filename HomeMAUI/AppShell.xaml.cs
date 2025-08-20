namespace HomeMAUI;

public partial class AppShell : Shell
{
        public AppShell()
        {
                InitializeComponent();
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
                Shell.Current.FlyoutIsPresented = true;
        }
}
