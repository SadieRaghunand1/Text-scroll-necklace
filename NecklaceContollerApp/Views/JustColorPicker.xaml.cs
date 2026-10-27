using System.Drawing;

namespace NecklaceContollerApp.Views;

public partial class JustColorPicker : ContentPage
{ 

    public struct ColorVals
    {
        public byte[] rgb;

        public Microsoft.Maui.Graphics.Color currentColor;
    }

    NecklaceContollerApp.ConnetionManager _conn;
    private ColorVals bg;
    private ColorVals txt;


    public JustColorPicker()
	{
		InitializeComponent();
        _conn = new ConnetionManager();
	}
   
    private void OnBGColorChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender is Slider _slider)
        {
            
            BGColorPreview.Color = CalculateColor(bg, BGRedSlider.Value, BGGreenSlider.Value, BGBlueSlider.Value);
        }
            
    }

    private void OnTextColorChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender is Slider _slider)
        {

            ColorPreview.Color = CalculateColor(txt, RedSlider.Value, GreenSlider.Value, BlueSlider.Value);
        }
    }


    private Microsoft.Maui.Graphics.Color CalculateColor(ColorVals _obj, double _r, double _g, double _b)
    {
        _obj.rgb[0] = (byte)Math.Clamp(Math.Round(_r), 0, 255);
        _obj.rgb[1] = (byte)Math.Clamp(Math.Round(_g), 0, 255);
        _obj.rgb[2] = (byte)Math.Clamp(Math.Round(_b), 0, 255);


        _obj.currentColor = Microsoft.Maui.Graphics.Color.FromArgb(Convert.ToHexString(_obj.rgb));
        _conn.SetTextColor(_obj.currentColor);
        return _obj.currentColor;
    }
}
    