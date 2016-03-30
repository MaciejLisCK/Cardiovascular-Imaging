using Cardiovascular_Imaging.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        StentLocationHelper _stentLocationHelper;

        public float Threshold { get { return uxThresholdTrackBar.Value/1000f; } }

        public MainForm()
        {
            InitializeComponent();

            Initialize();

            uxTimer.Interval = 100;
            uxTimer.Tick += UxTimer_Tick;
        }

        private void Initialize()
        {
            Image firstImage = Image.FromFile(GetCurrentImagePath());
            _imagesWidth = firstImage.Width;
            _imagesHeight = firstImage.Height;

            var stentArea = new Rectangle(0, 0, _imagesWidth / 3, _imagesHeight / 3);

            _stentLocationHelper = new StentLocationHelper(stentArea);
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

            var brightnessTableCache = bitmap.GetBrightnessTable();

            foreach (var darkestPixel in darkestPixels)
            {
                var darkestPathPositions = bitmap.GetMostDarkSiblingPixels(darkestPixel.Position, 500, brightnessTableCache);

                foreach (var pathPosition in darkestPathPositions)
                    bitmap.SetPixel(pathPosition, Color.Yellow);
            }

            foreach (var darkestPixel in darkestPixels)
                bitmap.SetPixel(darkestPixel.Position, Color.Red);
            */
            var stentLocation = _stentLocationHelper.GetStentLocation(bitmap);

            bitmap.SetPixel(stentLocation, Color.Red);

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


    }
}
