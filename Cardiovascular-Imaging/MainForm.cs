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
        int _tickCount = 10;

        RadialGradient _stentDetectionGradient;
        public RadialGradient StentDetectionGradient
        {
            get
            {
                _stentDetectionGradient = _stentDetectionGradient ?? new RadialGradient(_imagesWidth, _imagesHeight);

                return _stentDetectionGradient;
            }
        }

        public float Threshold { get { return uxThresholdTrackBar.Value/1000f; } }

        public MainForm()
        {
            InitializeComponent();

            Image firstImage = Image.FromFile(String.Format(_imagePathPattern, _minImageNumber));
            _imagesWidth = firstImage.Width;
            _imagesHeight = firstImage.Height;

            uxTimer.Tick += UxTimer_Tick;

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
