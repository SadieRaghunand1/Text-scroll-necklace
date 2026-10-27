namespace NecklaceContollerApp
{
    public partial class AppShell : Shell
    {
        string textToShow = string.Empty;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ChooseTextPg", typeof(Views.ColorTextPicker));
            Routing.RegisterRoute("ChooseColorPg", typeof(Views.JustColorPicker));
        }

        private async void OnColorPicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("ChooseColorPg");

        }

        private async void OnTextPicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("ChooseTextPg");
        }

        
    }
}
