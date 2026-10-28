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

        #region setters
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
        #endregion

        #region getters
        public string GetBGColor()
        {
            return chosenBGColor.ToString();
        }

        public string GetTextColor()
        {
            return chosenTextColor.ToString();
        }

        public string GetText()
        {
            return displayedString;
        }
        #endregion


    }
}
