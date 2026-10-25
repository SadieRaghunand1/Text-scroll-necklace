using NecklaceContollerApp.Views;

namespace NecklaceContollerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
           // MainPage = new ColorTextPicker();
        }
    }
}
