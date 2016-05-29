using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BitHandler;
using static System.Double;
using static System.Int32;
using System.IO;
using ImageHandler;

namespace NearLosslessPredictiveCoder
{
    public partial class Form1 : Form
    {
        private Coder _coder;
        private Dictionary<int, string> _predictionTypes;
        private string _origPicturePath;
        private string _codedPicturePath;
        private int[,] _originalImageMatrix;
        private int[,] _codedImageMatrix;
        private int[,] _decodedImageMatrix;
        private byte[] _origImageHeader;

        private int _predictionTypeCoded;
        private int _acceptedErrorCoded;
        private byte[] _headerCoded;
        private int[,] _errorMatrix;

        private int imageHardCodedDim = 256;



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

                if (origImageWidth != imageHardCodedDim || origImageHeight != imageHardCodedDim)
                    MessageBox.Show("Please Choose a 256x256 picture");
                else
                {
                    originalImagePb.Image = picture;
                    _origPicturePath = dlg.FileName;
                    _originalImageMatrix = ImageHandler.ImageHandler.ImageToMatrix(_origPicturePath, origImageHeight, origImageWidth, out _origImageHeader);
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
            statusLabel.Text = "Coded finished";
            statusLabel.ForeColor = Color.Red;

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

            _coder = new Coder(intAcceptedError, 0, 255, predictorType, originalImagePb.Image.Width, _originalImageMatrix);
            return true;

        }

        private void refreshHistogramBtn_Click(object sender, EventArgs e)
        {
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
                    DrawHistogram(getHistogram(_originalImageMatrix), scale);
                    break;
                case "Quantized Prediction Error":
                    {
                        if (_coder == null)
                        {
                            MessageBox.Show("Image was not encoded");
                            return;
                        }
                        DrawHistogram(getHistogram(_coder.QuatizedPredictionError), scale);
                        break;
                    }
                case "Prediction Error":
                    {
                        if (_coder == null)
                        {
                            MessageBox.Show("Image was not encoded");
                            return;
                        }
                        DrawHistogram(getHistogram(_coder.PredictionError), scale);
                        break;
                    }
                case "Decoded Image":
                    if (_decodedImageMatrix == null)
                    {
                        MessageBox.Show("No decoded image");
                    }
                    DrawHistogram(getHistogram(_decodedImageMatrix), scale);
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
                g.DrawLine(pen, new Point { X = i, Y = 255 },
                    new Point { X = i, Y = histogram.Height - (int)(scale * values[i]) });
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

        private void saveOrigBtn_Click(object sender, EventArgs e)
        {
            RadioButton checkedRb = saveModeGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRb == null)
            {
                MessageBox.Show("Histogram input not defined");
                return;
            }
            switch (checkedRb.Text)
            {
                case "Fixed no bits - 9":
                    {
                        SaveEncodedImage("F");
                        break;
                    }
                case "JPEG Table":
                    break;
                case "Arithmetic Coding":
                    break;
                default:
                    {
                        SaveEncodedImage("D");
                        break;
                    }
            }
            statusLabel.Text = "Saved";
        }

        private void SaveEncodedImage(string saveMode)
        {
            RadioButton checkedRb = predictorGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            int predictorType = _predictionTypes.FirstOrDefault(x => x.Value == checkedRb.Text).Key;
            string acceptedError = acceptedErrorTextBox.Text;
            string fileName = "Coded.bmp.p" + predictorType + "k" + acceptedError + saveMode + ".prd";
            if (File.Exists(@"../../../Images/" + fileName))
            {
                File.Delete(@"../../../Images/" + fileName);
            }
            if (saveMode == "F")
            { FixedCoding(fileName, predictorType, acceptedError); }
            if (saveMode == "D")
            {
                DefaultCoding(fileName, predictorType, acceptedError);
                return;
            }


        }

        private void DefaultCoding(string fileName, int predictorType, string acceptedError)
        {
            //Create the file.
            using (BinaryWriter fs = new BinaryWriter(File.Open(@"../../../Images/" + fileName, FileMode.Create)))
            {
                //fs.Write(_origImageHeader);
                foreach (var b in _origImageHeader)
                    fs.Write(b);
                fs.Write("p" + predictorType);
                fs.Write("k" + acceptedError);
                fs.Write("s" + "F");
                for (int i = 0; i < _coder.QuatizedPredictionError.GetLength(0); i++)
                {
                    for (int j = 0; j < _coder.QuatizedPredictionError.GetLength(1); j++)
                    {
                        fs.Write(_coder.QuatizedPredictionError[i, j]);
                    }
                }
            }
        }

        private void FixedCoding(string fileName, int predictorType, string acceptedError)
        {

            var writer = new BitWriter("../../../Images/" + fileName);

            writer.WriteNBits(new BitArray(_origImageHeader)); //asta inca nu e ok

            writer.WriteString("p" + predictorType);
            writer.WriteString("k" + acceptedError);
            writer.WriteString("s" + "F");

            //write quantized prediction Error to File
            for (int i = 0; i < _coder.QuatizedPredictionError.GetLength(0); i++)
            {
                for (int j = 0; j < _coder.QuatizedPredictionError.GetLength(1); j++)
                {
                    writer.WriteIntOnNBits(_coder.QuatizedPredictionError[i, j], 9);
                }
            }
            writer.FlushLastBits();
        }


        private void loadEncodedImage_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();

            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.prd)|*.prd";

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                //var picture = Image.FromFile(dlg.FileName);


                //var codedImageWidth = picture.Width;
                //var codedImageHeigth = picture.Height;

                _codedPicturePath = dlg.FileName;
                //_codedImageMatrix = ImageHandler.ImageToMatrix(_origPicturePath, imageHardCodedDim, imageHardCodedDim, out _origImageHeader);
                //ReadCodedImage();
                ReadDeafault();
            }

            dlg.Dispose();
            //DrawHistogram(getHistogram(_codedImageMatrix), Double.Parse(histogramScaleTextBox.Text));
        }

        private void ReadDeafault()
        {
            _codedImageMatrix = new int[imageHardCodedDim, imageHardCodedDim];
            using (BinaryReader sr = new BinaryReader(File.Open(_codedPicturePath, FileMode.Open)))
            {
                _headerCoded = new byte[1078];
                for (int i = 0; i < 1078; i++)
                    _headerCoded[i] = sr.ReadByte();
                var predictionType = sr.ReadString();
                _predictionTypeCoded = Int32.Parse(predictionType[1].ToString());
                var accepedError = sr.ReadString();
                _acceptedErrorCoded = Int32.Parse(accepedError[1].ToString());
                var saveMode = sr.ReadString();
                for (int i = 0; i < imageHardCodedDim; i++)
                {

                    for (int j = 0; j < imageHardCodedDim; j++)
                    {
                        _codedImageMatrix[i, j] = sr.ReadInt32();
                    }


                }
            }
        }

        private void ReadCodedImage()
        {
            var x = new BitReader(_codedPicturePath);
            //byte[] image = 
            var header = x.ReadNBits(8624);
            var predictionType = ConvertToByte(x.ReadNBits(8));
            //int accepedError = (int)image[1081];
            char saveMode = 'F';
            //s
            switch (saveMode)
            {
                case 'F':
                    {
                        ReadCodedImageFromFile();
                        break;
                    }
            }

        }

        private void ReadCodedImageFromFile()
        {

        }

        byte ConvertToByte(BitArray bits)
        {
            if (bits.Count != 8)
            {
                throw new ArgumentException("bits");
            }
            byte[] bytes = new byte[1];
            bits.CopyTo(bytes, 0);
            return bytes[0];
        }

        private void decodeBtn_Click(object sender, EventArgs e)
        {
            if (_codedPicturePath == null)
            {
                MessageBox.Show("No Image Selected");
                return;
            }
            _decodedImageMatrix = new int[imageHardCodedDim, imageHardCodedDim];
            var x = new Decoder(_acceptedErrorCoded, 0, 255, _predictionTypeCoded, imageHardCodedDim, _codedImageMatrix);
            x.Decode();

            byte[] imagebytes = new byte[1078 + imageHardCodedDim * imageHardCodedDim];
            for (int i = 0; i < 1078; i++)
            {
                imagebytes[i] = _headerCoded[i];
            }
            for (int i = 0; i < imageHardCodedDim; i++)
            {
                for (int j = 0; j < imageHardCodedDim; j++)
                {
                    _decodedImageMatrix[i, j] = x.Decoded[i, j];
                    imagebytes[1078 + i * imageHardCodedDim + j] = (byte)x.Decoded[i, j];
                }
            }


            var img = Image.FromStream(new MemoryStream(imagebytes));

            pictureBox1.Image = img;
        }

        private void refreshErrorImageBtn_Click(object sender, EventArgs e)
        {
            if (_origPicturePath == null || _codedPicturePath == null)
            {
                MessageBox.Show("Loas coded and decoded image");
                return;
            }
            _errorMatrix = new int[imageHardCodedDim, imageHardCodedDim];
            var minError = 9999;
            var maxError = -9999;
            for (int i = 0; i < imageHardCodedDim; i++)
            {
                for (int j = 0; j < imageHardCodedDim; j++)
                {
                    _errorMatrix[i, j] = _originalImageMatrix[i, j] - _decodedImageMatrix[i, j];
                    if (_errorMatrix[i, j] > maxError)
                        maxError = _errorMatrix[i, j];
                    if (_errorMatrix[i, j] < minError)
                        minError = _errorMatrix[i, j];
                }
            } //error*scale+128
            var scale = Convert.ToDouble(errorImageScaleTextBox.Text);
            RadioButton checkedRb = displayedErrorGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRb == null)
            {
                MessageBox.Show("No Error Type Selected");
                return;
            }
            if (checkedRb.Text == "Prediction Error")
                DrawErrorImage(_errorMatrix, scale);
            else
                DrawErrorImage(_codedImageMatrix, scale);
            minComputedErrorLabel.Text = minError.ToString();
            maxComputedErrorLabel.Text = maxError.ToString();
        }

        private void DrawErrorImage(int[,] errorM, double scale)
        {
            Bitmap errorImageBmp = new Bitmap(imageHardCodedDim, imageHardCodedDim);

            for (int Xcount = 0; Xcount < errorImage.Width; Xcount++)
            {
                for (int Ycount = 0; Ycount < errorImage.Height; Ycount++)
                {
                    var x = (int)(128 + errorM[Xcount, Ycount] * scale);
                    if (x < 0)
                        x = 0;
                    if (x > 255)
                        x = 255;
                    errorImageBmp.SetPixel(Xcount, Ycount, Color.FromArgb(x, x, x));
                }
            }

            errorImage.Image = errorImageBmp;
        }
    }

}
