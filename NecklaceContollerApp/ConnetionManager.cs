using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls.Platform.Compatibility;

namespace NecklaceContollerApp
{
    class ConnetionManager
    {
        private Color chosenBGColor = new Color(); //1
        private Color chosenTextColor = new Color(); //2
        private string displayedString = string.Empty; //0
        private string dataAddress = string.Empty;
        private StreamWriter sw;
        private StreamReader sr;

        public ConnetionManager()
        {
            dataAddress = FileSystem.Current.AppDataDirectory + "KeychainData.txt";
            if(File.Exists(dataAddress))
            {
                sw = new StreamWriter(dataAddress, true);
            }
            else
            {
                sw = new StreamWriter(dataAddress, false);
                sw.WriteLine("\n\n\n");
                
            }

            sr = new StreamReader(dataAddress);

            //read file for saved keychain data
            displayedString = File.ReadLines(dataAddress).ElementAtOrDefault(0);

            string bgString = File.ReadLines(dataAddress).ElementAtOrDefault(1);
            string txtString = File.ReadLines(dataAddress).ElementAtOrDefault(2);

            //chosenBGColor = new Color(Color.)


        }


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

        public void WriteNewKeychainData(string _toWrite, int _idx) //index 0 = text, 1 is bg color, 2 is text color
        {
            int i = 0;
            string line = string.Empty;
            while((line = sr.ReadLine()) != null)
            {
                if(i == _idx)
                {
                    sw.WriteLine(_toWrite);
                    break;
                }
                else
                {
                    sw.WriteLine(line);
                }

                i++;
            }
        }


    }
}
