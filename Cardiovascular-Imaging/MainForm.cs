using AForge.Imaging.Filters;
using Cardiovascular_Imaging.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cardiovascular_Imaging
{
    public partial class MainForm : Form
    {
        string _imagePathPattern = @"D:\studies\PHD thesis\images\BK\BMP\IMG\IMG00000_00{0}.bmp";
        const int _minImageNumber = 1;
        const int _maxImageNumber = 70;

        int _imagesWidth;
        int _imagesHeight;
        int _tickCount = 0;

        StentPositionFinder _stentPositionFinder;

        public float Threshold { get { return uxThresholdTrackBar.Value/1000f; } }

        public MainForm()
        {
            InitializeComponent();

            Initialize();

            uxTimer.Interval = 10;
            uxTimer.Tick += UxTimer_Tick;
        }

        private void Initialize()
        {
            Image firstImage = Image.FromFile(GetCurrentImagePath());
            _imagesWidth = firstImage.Width;
            _imagesHeight = firstImage.Height;

            var stentArea = new Rectangle(0, 0, _imagesWidth / 3, _imagesHeight / 3);

            _stentPositionFinder = new StentPositionFinder(stentArea);
        }

        private void uxFindDarkestAndPathFill_Click(object sender, EventArgs e)
        {
            if(uxTimer.Enabled)
            {
                uxTimer.Stop();
            }
            else
            {
                uxTimer.Start();
            }
        }


        private void UxTimer_Tick(object sender, EventArgs e)
        {
            var currentImagePath = GetCurrentImagePath();
            var bitmap = new Bitmap(currentImagePath);
            /*
            var darkestPixels = bitmap.GetDarkestPixelsWithThresholdAndExclusionRadius(Threshold,10);
            */
            var brightnessTableCache = bitmap.GetBrightnessTable();
           
            /*
            foreach (var darkestPixel in darkestPixels)
            {
                var darkestPathPositions = bitmap.GetMostDarkSiblingPixels(darkestPixel.Position, 500, brightnessTableCache);

                foreach (var pathPosition in darkestPathPositions)
                    bitmap.SetPixel(pathPosition, Color.Yellow);
            }

            foreach (var darkestPixel in darkestPixels)
                bitmap.SetPixel(darkestPixel.Position, Color.Red);
            
            */
            var stentPosition = _stentPositionFinder.GetStentPosition(bitmap);
            /*
            var brightnessTableCache = bitmap.GetBrightnessTable();
*/
            /* ExpandSimilarityAlgorithm */
            var alg = new ExpandSimilarityAlgorithm();
            var res = alg.Run(brightnessTableCache, stentPosition, new Rectangle(20, 20, bitmap.Width - 1, bitmap.Height - 1));
            foreach (var resPos in res)
            {
                bitmap.SetPixel(resPos, Color.Red);
            }

            Bitmap expandSimilarityAlgorithmBinaryBitmap = new Bitmap(bitmap.Width, bitmap.Height, PixelFormat.Format24bppRgb);
            foreach (var resPos in res)
            {
                expandSimilarityAlgorithmBinaryBitmap.SetPixel(resPos, Color.Red);
            }
            uxExpandSimilarityAlgorithmPictureBox.Image = expandSimilarityAlgorithmBinaryBitmap;
            uxExpandSimilarityAlgorithmPictureBox.Refresh();

            /* CLOSING for ExpandSimilarityAlgorithm */
            Closing filter = new Closing();
            var closingResultBitmap = filter.Apply(expandSimilarityAlgorithmBinaryBitmap);

            uxClosingResultPictureBox.Image = closingResultBitmap;
            uxClosingResultPictureBox.Refresh();




            /*
            foreach (var darkestPixel in darkestPixels.Where(p => p.Position.X>40))
            {
                var res1 = alg.Run(brightnessTableCache, darkestPixel.Position, new Rectangle(20, 20, bitmap.Width - 1, bitmap.Height - 1));

                foreach (var pathPosition in res1)
                    bitmap.SetPixel(pathPosition, Color.Yellow);
            }
            */
            /*
            var gt = new RadialGradient(bitmap.Width / 3, bitmap.Height / 3)._gradnientTable;

            for (int y = 0; y < bitmap.Height/3; y++)
            {
                for (int x = 0; x < bitmap.Width/3; x++)
                {
                    var gradientValue = gt[x, y];
                    var bitmapPixelBrightness = bitmap.GetPixel(x, y).GetBrightness();

                    var value = ((gradientValue*1.5) * bitmapPixelBrightness);
                    var value2 = (int)(value * 255);
                    bitmap.SetPixel(x,y, Color.FromArgb(value2,value2,value2));

                }
            }

            */
            /*
            bitmap.SetPixel(stentPosition, Color.YellowGreen);
            var graphics = Graphics.FromImage(bitmap);
            graphics.DrawEllipse(Pens.GreenYellow, new RectangleF(stentPosition.X - 3, stentPosition.Y - 3, 6, 6));
            graphics.Dispose();
            */
            DisplayBitmap(bitmap);

            _tickCount++;
        }

        private string GetCurrentImagePath()
        {
            var imageNumberRange = _maxImageNumber - _minImageNumber;
            var currentImageNumber = (_tickCount % imageNumberRange) + 1;
            var currentImageNumberPadded = currentImageNumber.ToString().PadLeft(2, '0');
            var imagePath = String.Format(_imagePathPattern, currentImageNumberPadded);
            return imagePath;
        }

        private void DisplayBitmap(Bitmap bitmap)
        {
            uxPictureBox.Image = bitmap;
            uxPictureBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datetimeString = DateTime.Now.ToString("yyyyMMddHHmmss");
            uxPictureBox.Image.Save(datetimeString + " 1.png");
            uxExpandSimilarityAlgorithmPictureBox.Image.Save(datetimeString + " 2.png");
            uxClosingResultPictureBox.Image.Save(datetimeString + " 3.png");
        }
    }
}
