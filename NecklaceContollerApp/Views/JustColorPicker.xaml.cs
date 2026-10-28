using System.Drawing;

namespace NecklaceContollerApp.Views;

public partial class JustColorPicker : ContentPage
{ 

    public struct ColorVals
    {
        public bool isBG;
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
        InitVals();
	}

    private void InitVals()
    {
        //!!Need to make persistant!!
        bg = new ColorVals();
        txt = new ColorVals();
        bg.rgb = new byte[3];
        bg.currentColor = Microsoft.Maui.Graphics.Color.FromArgb("#000000");
        bg.isBG = true;
        txt.rgb = new byte[3];
        txt.currentColor = Microsoft.Maui.Graphics.Color.FromArgb("#000000");

        BGHexLabel.Text = bg.currentColor.ToString();
        HexLabel.Text = txt.currentColor.ToString();
    }
   
    private void OnBGColorChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender is Slider _slider)
        {
            
            BGColorPreview.Color = CalculateColor(bg, BGRedSlider.Value, BGGreenSlider.Value, BGBlueSlider.Value);
            BGHexLabel.Text = bg.currentColor.ToString();
        }
            
    }

    private void OnTextColorChanged(object sender, ValueChangedEventArgs e)
    {
        if (sender is Slider _slider)
        {

            ColorPreview.Color = CalculateColor(txt, RedSlider.Value, GreenSlider.Value, BlueSlider.Value);
            HexLabel.Text = txt.currentColor.ToString();
        }
    }


    private Microsoft.Maui.Graphics.Color CalculateColor(ColorVals _obj, double _r, double _g, double _b)
    {
        _obj.rgb[0] = (byte)Math.Clamp(Math.Round(_r), 0, 255);
        _obj.rgb[1] = (byte)Math.Clamp(Math.Round(_g), 0, 255);
        _obj.rgb[2] = (byte)Math.Clamp(Math.Round(_b), 0, 255);


        _obj.currentColor = Microsoft.Maui.Graphics.Color.FromArgb(Convert.ToHexString(_obj.rgb));
        if(_obj.isBG)
            _conn.SetBGColor(_obj.currentColor);
        else
            _conn.SetTextColor(_obj.currentColor);
        return _obj.currentColor;
    }

    
}
    