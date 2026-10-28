

namespace NecklaceContollerApp
{
    public partial class AppShell : Shell
    {
        string textToShow = string.Empty;
        NecklaceContollerApp.ConnetionManager _conn;
        public AppShell()
        {
            InitializeComponent();
            _conn = new ConnetionManager();
            Routing.RegisterRoute("ChooseTextPg", typeof(Views.ColorTextPicker));
            Routing.RegisterRoute("ChooseColorPg", typeof(Views.JustColorPicker));
            SetCurrentKeychainStates();
        }

        private async void OnColorPicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("ChooseColorPg"); 

        }

        private async void OnTextPicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("ChooseTextPg");
        }

        private void SetCurrentKeychainStates()
        {
            CurrentText.Text = "Keychain currently says \"" + _conn.GetText() + "\"";
            CurrentBG.Text = "Keychain background is currently " + _conn.GetBGColor().ToString();
            CurrentTextColor.Text = "Keychain text color is currently " + _conn.GetTextColor().ToString();
        }

        
    }
}
