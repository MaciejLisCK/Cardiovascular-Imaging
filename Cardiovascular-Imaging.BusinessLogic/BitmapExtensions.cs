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

        public static List<Pixel> GetDarkestPixelsWithThreshold(this Bitmap bitmap, float brightnessThreshold)
        {
            var darkPixels = new List<Pixel>();

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var currentPixelColor = bitmap.GetPixel(x, y);
                    var currentPixelBrightness = currentPixelColor.GetBrightness();

                    if (currentPixelBrightness < brightnessThreshold)
                        darkPixels.Add(new Pixel(x, y, currentPixelColor));
                }
            }

            return darkPixels;
        }

        public static List<Pixel> GetDarkestPixelsWithThresholdAndExclusionRadius(this Bitmap bitmap, float brightnessThreshold, int exclusionRadius)
        {
            var darkestPixels = GetDarkestPixelsWithThreshold(bitmap, brightnessThreshold);

            if (!darkestPixels.Any())
                return darkestPixels;

            bool isEnd = false;
            while (!isEnd)
            {
                var pixelsInRadius = new List<Pixel>();
                for (int i = 0; i < darkestPixels.Count; i++)
                {
                    var darkestPixel = darkestPixels[i];

                    var leftRadius = darkestPixel.Position.X - exclusionRadius;
                    var rightRadius = darkestPixel.Position.X + exclusionRadius;
                    var topRadius = darkestPixel.Position.Y - exclusionRadius;
                    var bottomRadius = darkestPixel.Position.Y + exclusionRadius;

                    foreach (var darkestPixelsToCheck in darkestPixels)
                    {
                        bool isSourcePixel = darkestPixel == darkestPixelsToCheck;
                        if (isSourcePixel)
                            continue;

                        bool isInXRange = leftRadius <= darkestPixelsToCheck.Position.X && darkestPixelsToCheck.Position.X <= rightRadius;
                        bool isInYRange = topRadius <= darkestPixelsToCheck.Position.Y && darkestPixelsToCheck.Position.Y <= bottomRadius;

                        if(isInXRange && isInYRange)
                        {
                            pixelsInRadius.Add(darkestPixelsToCheck);
                        }
                    }

                    if (pixelsInRadius.Any())
                        break;

                    isEnd = i == darkestPixels.Count - 1;
                }

                foreach (var pixelInRadius in pixelsInRadius)
                    darkestPixels.Remove(pixelInRadius);
            }

            return darkestPixels;
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

            return GetMostDarkSiblingPixels(bitmap, position, count, brightnessTable);
        }

        public static List<Point> GetMostDarkSiblingPixels(this Bitmap bitmap, Point position, int count, float[,] brightnessTableCache)
        {
            var positions = new List<Point>();
            positions.Add(position);

            for (int i = 0; i < count; i++)
            {
                var siblings = bitmap.GetSiblingsForPixels(positions);

                var darkestSibling = siblings.First();
                var darkestBrightness = brightnessTableCache[darkestSibling.X, darkestSibling.Y];
                //get darkest pixel
                foreach (var sibling in siblings)
                {
                    var siblingBrigtness = brightnessTableCache[sibling.X, sibling.Y];

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
