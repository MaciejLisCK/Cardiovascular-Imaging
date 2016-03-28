using Cardiovascular_Imaging.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Drawing
{
    public static class BitmapExtensions
    {
        public static List<Pixel> GetDarkestPixels(this Bitmap bitmap)
        {
            var darkestPixelsTemp = new List<Pixel>();
            var darkestColor = Color.White;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var currentPixelColor = bitmap.GetPixel(x, y);

                    bool hasSameBrightness = currentPixelColor.GetBrightness() == darkestColor.GetBrightness();
                    if (hasSameBrightness)
                    {
                        var nextDarkestPixel = new Pixel(x, y, currentPixelColor);
                        darkestPixelsTemp.Add(nextDarkestPixel);
                    }

                    bool isDarker = currentPixelColor.GetBrightness() < darkestColor.GetBrightness();
                    if (isDarker)
                    {
                        var newDarkestPixel = new Pixel(x, y, currentPixelColor);

                        darkestPixelsTemp.Clear();
                        darkestPixelsTemp.Add(newDarkestPixel);

                        darkestColor = currentPixelColor;
                    }
                }
            }

            return darkestPixelsTemp;
        }

        public static Color GetPixel(this Bitmap bitmap, Point position)
        {
            return bitmap.GetPixel(position.X, position.Y);
        }

        public static void SetPixel(this Bitmap bitmap, Point position, Color color)
        {
            bitmap.SetPixel(position.X, position.Y, color);
        }

        public static float[,] GetBrightnessTable(this Bitmap bitmap)
        {
            var result = new float[bitmap.Width, bitmap.Height];

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var pixel = bitmap.GetPixel(x, y);

                    var brightness = pixel.GetBrightness();

                    result[x, y] = brightness;
                }
            }

            return result;
        }

        public static List<Point> GetSiblingsForPixel(this Bitmap bitmap, Point position)
        {
            var x = position.X;
            var y = position.Y;

            var result = new List<Point>();

            /*
            var result = new List<Point>()
            {
                new Point(x-1,y-1),new Point(x,y-1),new Point(x+1,y-1),
                new Point(x-1,y), new Point(x+1,y),
                new Point(x-1,y+1),new Point(x,y+1),new Point(x+1,y+1),
            };
            */


            bool isLeftEdge = x == 0;
            bool isRightEdge = x == bitmap.Width - 1;
            bool isTopEdge = y == 0;
            bool isBottomEdge = y == bitmap.Height - 1;

            if (!isLeftEdge && !isTopEdge)
                result.Add(new Point(x - 1, y - 1));
            if (!isTopEdge)
                result.Add(new Point(x, y - 1));
            if (!isTopEdge && !isRightEdge)
                result.Add(new Point(x + 1, y - 1));

            if (!isLeftEdge)
                result.Add(new Point(x - 1, y));
            if (!isRightEdge)
                result.Add(new Point(x + 1, y));


            if (!isBottomEdge && !isLeftEdge)
                result.Add(new Point(x - 1, y + 1));
            if (!isBottomEdge)
                result.Add(new Point(x, y + 1));
            if (!isBottomEdge && !isRightEdge)
                result.Add(new Point(x + 1, y + 1));

            return result;
        }

        public static List<Point> GetSiblingsForPixels(this Bitmap bitmap, List<Point> positions)
        {
            var allSiblings = new List<Point>();

            foreach (var position in positions)
            {
                var siblings = bitmap.GetSiblingsForPixel(position);

                allSiblings.AddRange(siblings);
            }

            var distinctSiblings = allSiblings.Distinct().ToList();

            // remove source pixels
            foreach (var position in positions)
                distinctSiblings.Remove(position);

            return distinctSiblings.ToList();
        }

        public static List<Point> GetMostDarkSiblingPixels(this Bitmap bitmap, Point position, int count)
        {
            var brightnessTable = bitmap.GetBrightnessTable();

            var positions = new List<Point>();
            positions.Add(position);

            for (int i = 0; i < count; i++)
            {
                var siblings = bitmap.GetSiblingsForPixels(positions);

                var darkestSibling = siblings.First();
                var darkestBrightness = bitmap.GetPixel(darkestSibling).GetBrightness();
                //get darkest pixel
                foreach (var sibling in siblings)
                {
                    var siblingBrigtness = bitmap.GetPixel(sibling).GetBrightness();

                    if(siblingBrigtness<darkestBrightness)
                    {
                        darkestSibling = sibling;
                        darkestBrightness = siblingBrigtness;
                    }
                }

                positions.Add(darkestSibling);
            }


            return positions;
        }


    }
}
