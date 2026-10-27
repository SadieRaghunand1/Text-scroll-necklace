using Docutain;
using DocutainColorPicker;

namespace NecklaceContollerApp.Views;

public partial class JustColorPicker : ContentPage
{
    NecklaceContollerApp.ConnetionManager _conn;


    public JustColorPicker()
	{
		InitializeComponent();
        _conn = new ConnetionManager();
	}
   
    private void OnBGColorChanged(object sender, EventArgs e)
    {
        if (sender is Entry entry) { }
            //_conn.SetBGColor();
    }

    private void OnTextColorChanged(object sender, EventArgs e)
    {
        if (sender is Entry entry) { }
        //_conn.SetTextColor();
    }

# region Handle color picker behavior
    public async void HandleColorPicker()
    {
        var previousColor = BackgroundColor;

        // Define your custom config; all values are optional.
        var colorConfig = new ColorPickerConfig
        {
            Title = "Pick a color",
            DefaultColor = Colors.Yellow,
            PositiveButton = "OK",
            NegativeButton = "Cancel",
            SupportsAlpha = true,
            ShowDefaultColors = true,
            Dismissable = true,
            OnColorChanged = color => BackgroundColor = color,
            RecentColorsLabel = "Recent",
            DefaultColorsLabel = "Colors",
            CustomColorLabel = "Custom color"
        };

        // Open the picker and wait for the result.
        var color = await ColorPicker.PickColor(colorConfig);

        if (color != null)
        {
            BackgroundColor = color;
        }
        else
        {
            // Restore the previous color after canceling a live preview.
            BackgroundColor = previousColor;
        }
    }

   
    #endregion
}
    