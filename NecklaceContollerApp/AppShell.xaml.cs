namespace NecklaceContollerApp
{
    public partial class AppShell : Shell
    {
        int count = 0;
        string textToShow = string.Empty;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ChooseTextPg", typeof(Views.ColorTextPicker));
        }

        private void OnColorPicked(object sender, EventArgs args)
        {
            //TitleText.Text = "AAAAAAAA";
            count++;
            textToShow = count.ToString();
            ChangeColor.Text = textToShow;
            
        }

        private async void OnTextPicked(object sender, EventArgs args)
        {
            await Shell.Current.GoToAsync("ChooseTextPg");
        }

        public string GetCount()
        {
            return textToShow;
        }
    }
}
