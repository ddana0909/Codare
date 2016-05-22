using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wavelet
{
    public partial class Form1 : Form
    {
        int imageHardCodedDim = 512;

        public Form1()
        {
            InitializeComponent();
        }

        private void origImageLoadBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                var picture = Image.FromFile(dlg.FileName);


                var origImageWidth = picture.Width;
                var origImageHeight = picture.Height;

                if (origImageWidth != imageHardCodedDim || origImageHeight != imageHardCodedDim)
                    MessageBox.Show("Please Choose a 512x512 picture");
                else
                {
                    originalImagePb.Image = picture;

                }
            }

            dlg.Dispose();
        }
    }
}
