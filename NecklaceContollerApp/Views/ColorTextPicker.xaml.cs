using System.Runtime.CompilerServices;

namespace NecklaceContollerApp.Views;

public partial class ColorTextPicker : ContentPage
{

	int count = 0;
	
	private void OnColorPicked(object sender, EventArgs args)
	{
		TitleText.Text = "AAAAAAAA";
		count++;
	}
}