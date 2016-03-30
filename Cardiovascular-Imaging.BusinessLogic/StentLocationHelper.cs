using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiovascular_Imaging.BusinessLogic
{
    public class StentLocationHelper
    {
        private Rectangle _area;
        private RadialGradient _locationGradient;

        public StentLocationHelper(Rectangle area)
        {
            _area = area;
            _locationGradient = new RadialGradient(_area.Width, _area.Height);
        }

        public Point GetStentLocation(Bitmap bitmap)
        {
            var highestScore = 0d;
            var highestScorePixel = new Point(_area.Left,_area.Bottom);

            for (int y = _area.Top; y < _area.Bottom; y++)
            {
                for (int x = _area.Left; x < _area.Right; x++)
                {
                    var pixelColor = bitmap.GetPixel(x, y);

                    // im mniej tym lepiej
                    var pixelBrightness = pixelColor.GetBrightness();
                    // im mniej tym lepiej
                    var gradientModifier = _locationGradient[x, y];

                    var score = (1-pixelBrightness) + (1-gradientModifier); 

                    if(score > highestScore)
                    {
                        highestScore = score;
                        highestScorePixel = new Point(x, y);
                    }
                }
            }

            return highestScorePixel;

        }
    }
}
