using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiovascular_Imaging.BusinessLogic
{
    public class RadialGradient
    {
        public double[,] _gradnientTable;

        public RadialGradient(int width, int height)
        {
            bool isWidthZero = width == 0;
            bool isHeightZero = height == 0;

            if (isWidthZero || isHeightZero)
                throw new Exception("Width or height cannot be zero.");

            GenerateGradientTable(width, height);
        }

        public double this[int x, int y]
        {
            get
            {
                return _gradnientTable[x, y];
            }

        }

        private void GenerateGradientTable(int width, int height)
        {
            _gradnientTable = new double[width, height];

            var xCenter = width/2d;
            var yCenter = height/2d;
            var maxDistance = Math.Sqrt(Math.Pow(xCenter, 2) + Math.Pow(yCenter, 2));

            for (int y = 0; y < height; y++)
            {
                var yDistance = Math.Abs(yCenter - y);

                for (int x = 0; x < width; x++)
                {
                    var xDistance = Math.Abs(xCenter - x);
                    var distance = Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                    var normalizedDistance = distance / maxDistance;

                    _gradnientTable[x, y] = normalizedDistance;
                }
            }
        }




    }
}
