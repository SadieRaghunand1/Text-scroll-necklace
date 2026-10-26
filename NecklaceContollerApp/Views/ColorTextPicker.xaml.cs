
using System.Runtime.CompilerServices;

namespace NecklaceContollerApp.Views;

public partial class ColorTextPicker : ContentPage
{

    NecklaceContollerApp.ConnetionManager _conn;


    public ColorTextPicker()
    {
        InitializeComponent();
        _conn = new NecklaceContollerApp.ConnetionManager();
    }

    private void OnKeychainTextChanged(object sender, EventArgs e)
    {
        if(sender is Entry entry)
        _conn.SetText(entry.Text);
    }
}