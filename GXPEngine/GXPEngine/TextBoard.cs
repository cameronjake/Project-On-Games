using GXPEngine;
using System.Drawing;


    public class TextBoard : Canvas
    {
        public TextBoard(int width, int height) : base(width, height)
        {
            SetText("");
        }

        public void SetText(string text)
        {
              graphics.Clear(Color.LightSkyBlue);
              graphics.DrawString(text, SystemFonts.DefaultFont, Brushes.Black, 0, 0);
        }
    }
