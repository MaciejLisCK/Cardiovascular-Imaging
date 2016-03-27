using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiovascular_Imaging.BusinessLogic
{
    public class Pixel
    {
        public Pixel(int x, int y, Color color)
        {
            Position = new Point(x, y);
            Color = color;
        }

        public Color Color { get; set; }
        public Point Position { get; set; }
    }
}
