using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace NecklaceContollerApp
{
    class ConnetionManager
    {
        private Color chosenBGColor = new Color();
        private Color chosenTextColor = new Color();
        private string displayedString = string.Empty;


        public void SetBGColor(Color _color)
        {
            chosenBGColor = _color;
        }

        public void SetTextColor(Color _color)
        {
            chosenTextColor = _color;
        }

        public void SetText(string _text)
        {
            displayedString = _text;
        }



    }
}
