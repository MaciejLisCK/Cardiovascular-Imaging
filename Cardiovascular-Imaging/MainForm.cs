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
        int _tickCount = 0;

        public MainForm()
        {
            InitializeComponent();

            uxTimer.Tick += UxTimer_Tick;
            uxTimer.Start();
        }

        private void UxTimer_Tick(object sender, EventArgs e)
        {
            var currentImagePath = GetCurrentImagePath();
            var bitmap = new Bitmap(currentImagePath);

            var darkestPixels = bitmap.GetDarkestPixels();
            foreach (var darkestPixel in darkestPixels)
                bitmap.SetPixel(darkestPixel.Position, Color.Yellow);

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
