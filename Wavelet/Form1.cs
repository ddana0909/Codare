using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wavelet
{
    public partial class Form1 : Form
    {
        int imageHardCodedDim = 512;
        Coder _coder;

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
                    _coder = new Coder(dlg.FileName, imageHardCodedDim);

                }
                waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, 512);
            }

            dlg.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _coder.AnalysisHorizontal(1);
            xTb.Text = "256";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, 512);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            _coder.AnalysisHorizontal(2);
            xTb.Text = "128";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            _coder.AnalysisHorizontal(3);
            xTb.Text = "64";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);


        }

        private void button16_Click(object sender, EventArgs e)
        {
            _coder.AnalysisHorizontal(4);
            xTb.Text = "32";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

        }

        private void button20_Click(object sender, EventArgs e)
        {
            _coder.AnalysisHorizontal(5);
            xTb.Text = "16";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

        }


        private void button2_Click(object sender, EventArgs e)
        {
            _coder.AnalysisVerical(1);
            yTb.Text = "256";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

            // using (System.IO.StreamWriter file =
            //new System.IO.StreamWriter(@"V1.txt", true))
            // {
            //     for (int i = 0; i < 512; i++)
            //     {
            //         for (int j = 0; j < 512; j++)
            //         {
            //             file.Write(_coder.WaveletMatrix[i, j] + " ");
            //         }
            //         file.WriteLine();
            //     }
            // }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            _coder.AnalysisVerical(2);
            yTb.Text = "128";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

        }

        private void button11_Click(object sender, EventArgs e)
        {
            _coder.AnalysisVerical(3);
            yTb.Text = "64";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);


        }

        private void button15_Click(object sender, EventArgs e)
        {
            _coder.AnalysisVerical(4);
            yTb.Text = "32";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);


        }

        private void button19_Click(object sender, EventArgs e)
        {
            _coder.AnalysisVerical(5);
            yTb.Text = "16";
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);

        }


        private void refreshBtn_Click(object sender, EventArgs e)
        {
            //var image = ImageHandler.ImageHandler.BmpWithScaleAndOffset(_coder.WaveletMatrix, double.Parse(scaleTb.Text), int.Parse(offsetTb.Text), imageHardCodedDim,
            //     int.Parse(xTb.Text), int.Parse(yTb.Text));
            // waveletImagePb.Image = image;

            waveletImagePb.Image =
                ImageHandler.ImageHandler.CreateBitmapFromMatrix
                (
                    ImageHandler.ImageHandler.ScaleAndOffsetImageMatrix(_coder.WaveletMatrix, double.Parse(scaleTb.Text), int.Parse(offsetTb.Text),
                                                                        imageHardCodedDim,
                                                                        int.Parse(xTb.Text),
                                                                        int.Parse(yTb.Text)),
                    512);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _coder.SynthesisVertical(1);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _coder.SynthesisHorizontal(1);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
            _coder.CalculateDifference();
            maxLabel.Text = "Max: " + _coder.MaxError;
            minLabel.Text = "Min: " + _coder.MinError;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            _coder.SynthesisHorizontal(2);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _coder.SynthesisVertical(2);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            _coder.SynthesisHorizontal(3);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            _coder.SynthesisVertical(3);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            _coder.SynthesisHorizontal(4);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            _coder.SynthesisVertical(4);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            _coder.SynthesisHorizontal(5);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            _coder.SynthesisVertical(5);
            waveletImagePb.Image = ImageHandler.ImageHandler.CreateBitmapFromMatrix(_coder.WaveletMatrix, imageHardCodedDim);
        }
    }
}
