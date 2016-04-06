using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardiovascular_Imaging.BusinessLogic
{
    public class ExpandSimilarityAlgorithm
    {
        public Point[] Run(float[,] bitmapBrightneses, Point startPosition, Rectangle area)
        {
            var expandPixels = new List<Point>();
            var pixelSimilarities = new Dictionary<Point, float>();

            expandPixels.Add(startPosition);

            var siblingPixels = GetSiblingsForPixel(startPosition, area);
            var startPositionBrightness = bitmapBrightneses[startPosition.X, startPosition.Y];

            foreach (var siblingPixel in siblingPixels)
            {
                try
                {
                    var brightness = bitmapBrightneses[siblingPixel.X, siblingPixel.Y];
                    pixelSimilarities[siblingPixel] = startPositionBrightness - brightness;
                }
                catch(Exception e)
                {
                    continue;
                }
            }

            for (int i = 0; i < 3000; i++)
            {
                try
                {
                    var lowestDifferencesEntity = pixelSimilarities.OrderBy(ps => ps.Value).Last(ps => bitmapBrightneses[ps.Key.X, ps.Key.Y] < 0.3);
                    var position = lowestDifferencesEntity.Key;
                    pixelSimilarities.Remove(position);
                    expandPixels.Add(position);

                    var lowestDifferencesEntityBrightness =
                        bitmapBrightneses[position.X,position.Y];

                    var thisSiblingPixels = GetSiblingsForPixel(position, area);

                    foreach (var expandPixel in expandPixels)
                        thisSiblingPixels.Remove(expandPixel);

                    foreach (var item in thisSiblingPixels)
                    {
                        var siblingBrightness2 = bitmapBrightneses[item.X,item.Y];
                        if (!expandPixels.Contains(item))
                            pixelSimilarities[item] = lowestDifferencesEntityBrightness - siblingBrightness2;
                    }
                }
                catch (Exception e) { break; }
            }


            return expandPixels.ToArray();
        }


        public static List<Point> GetSiblingsForPixel(Point position, Rectangle area)
        {
            var x = position.X;
            var y = position.Y;

            var result = new List<Point>();

            bool isLeftEdge = x == area.Left;
            bool isRightEdge = x == area.Right;
            bool isTopEdge = y == area.Top;
            bool isBottomEdge = y == area.Bottom;

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
    }


    public struct PixelSimilarityEntity
    {
        public int X;
        public int Y;
        public float Value;
        public PixelSimilarityEntity(int x, int y, float value)
        {
            X = x;
            Y = y;
            Value = value;
        }

    }
}
