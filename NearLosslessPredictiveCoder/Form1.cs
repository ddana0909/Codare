using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Double;
using static System.Int32;

namespace NearLosslessPredictiveCoder
{
    public partial class Form1 : Form
    {
        private Coder _coder;
        private Dictionary<int, string> _predictionTypes;
        private string _origPicturePath;
        private int[,] _originalImageMatrix;
        public Form1()
        {
            InitializeComponent();
            initPredTypes();

        }

        private void initPredTypes()
        {
            _predictionTypes = new Dictionary<int, string>
            {
                {0, "128"},
                {1, "A"},
                {2, "B"},
                {3, "C"},
                {4, "A + B - C"},
                {5, "(A + B - C) / 2"},
                {6, "B+ (A - C) / 2"},
                {7, "(A + B) / 2"},
                {8, "jpegLs"}
            };

            p128RadioBtn.Text = _predictionTypes[0];
            pARadioBtn.Text = _predictionTypes[1];
            pBRadioBtn.Text = _predictionTypes[2];
            pCRadioBtn.Text = _predictionTypes[3];
            pABCRadioBtn.Text = _predictionTypes[4];
            pABC2RadioBtn.Text = _predictionTypes[5];
            pBAC2RadioBtn.Text = _predictionTypes[6];
            pAB2RadioBtn.Text = _predictionTypes[7];
            pJpegRadioBtn.Text = _predictionTypes[8];

        }

        private void loadOrigBtn_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                var picture = Image.FromFile(dlg.FileName);


                var origImageWidth = picture.Width;
                var origImageHeight = picture.Height;

                if (origImageWidth != 256 || origImageHeight != 256)
                    MessageBox.Show("Please Choose a 256x256 picture");
                else
                {
                    originalImagePb.Image = picture;
                    _origPicturePath = dlg.FileName;
                    _originalImageMatrix = ImageHandler.ImageToMatrix(_origPicturePath, origImageHeight, origImageWidth);
                }
            }

            dlg.Dispose();
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {

            if (!InitCoder())
            {
                MessageBox.Show("Not all necessary data has been delivered");
                return;
            }

            _coder.Code();
            MessageBox.Show("Coded");


        }

        private bool InitCoder()
        {
            var acceptedError = acceptedErrorTextBox.Text;
            int intAcceptedError;
            var isInt = TryParse(acceptedError, out intAcceptedError);
            if (!isInt || intAcceptedError < 0)
                return false;

            RadioButton checkedRb = predictorGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRb == null)
                return false;
            var predictorType = _predictionTypes.FirstOrDefault(x => x.Value == checkedRb.Text).Key;



            //mai trebuie tratat cazul cand nu e checked save mode
            _coder = new Coder(intAcceptedError, 0, 512, predictorType, 256, _originalImageMatrix);
            return true;

        }

        private void refreshHistogramBtn_Click(object sender, EventArgs e)
        {
            int[] histVector;
            RadioButton checkedRb = histogramImputGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRb == null)
            {
                MessageBox.Show("Histogram input not defined");
                return;
            }

            double scale;
            var isDouble = TryParse(histogramScaleTextBox.Text, out scale);
            if (!isDouble || scale < 0)
            {
                MessageBox.Show("Scale must be a positive number");
                return;
            }

            switch (checkedRb.Text)
            {
                case "Original Image":
                    DrawHistogram(getHistogram(ImageHandler.ImageToMatrix(_origPicturePath, 256, 256)), scale);
                    break;
                case "Quantized Prediction Error":
                    {
                        if (_coder == null)
                        {
                            MessageBox.Show("Image was not encoded");
                            return;
                        }
                        DrawHistogram(getHistogram(_coder.quatizedPredictionError), scale);
                        break;
                    }
                case "Prediction Error":
                    {
                        if (_coder == null)
                        {
                            MessageBox.Show("Image was not encoded");
                            return;
                        }
                        DrawHistogram(getHistogram(_coder.predictionError), scale);
                        break;
                    }
                case "Decoded Image":
                    break;
            }
        }

        public void DrawHistogram(int[] values, double scale)
        {
            var bmp = new Bitmap(histogram.Width, histogram.Height);
            var g = Graphics.FromImage(bmp);
            Pen pen = new Pen(Color.Black);
            g.DrawLine(pen, new Point { X = 255, Y = 0 }, new Point { X = 255, Y = 255 });
            pen = new Pen(Color.BlueViolet);
            for (int i = 0; i < values.Length; i++)
            {
                g.DrawLine(pen, new Point { X = i, Y = 255 }, new Point { X = i, Y = histogram.Height - (int)(scale * values[i]) });
            }
            histogram.Image = bmp;
            g.Dispose();
        }

        private int[] getHistogram(int[,] matrix)
        {
            int[] histogram = new int[511];
            //0...-255, 1 -254...
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    histogram[matrix[i, j] + 255]++;
                }
            }
            return histogram;

        }
    }
}
