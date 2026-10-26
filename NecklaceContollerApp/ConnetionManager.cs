using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace NecklaceContollerApp
{
    class ConnetionManager
    {
        private Color chosenColor = new Color();
        private string displayedString = string.Empty;


        public void SetColor(Color _color)
        {
            chosenColor = _color;
        }

        public void SetText(string _text)
        {
            displayedString = _text;
        }



    }
}
