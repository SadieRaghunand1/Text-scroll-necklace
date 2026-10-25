namespace NecklaceContollerApp
{
    public partial class AppShell : Shell
    {
        int count = 0;
        string textToShow = string.Empty;
        public AppShell()
        {
            InitializeComponent();
        }

        private void OnColorPicked(object sender, EventArgs args)
        {
            //TitleText.Text = "AAAAAAAA";
            count++;
            textToShow = count.ToString();
            PickedColor.Text = textToShow;
            
        }

        public string GetCount()
        {
            return textToShow;
        }
    }
}
