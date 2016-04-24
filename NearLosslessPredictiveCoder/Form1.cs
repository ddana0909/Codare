using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Int32;

namespace NearLosslessPredictiveCoder
{
    public partial class Form1 : Form
    {
        private Coder _coder;
        private Dictionary<int, string> _predictionTypes;
        private string origPicturePath;
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

                originalImagePb.Image= Image.FromFile(dlg.FileName);
                origPicturePath = dlg.FileName;
            }

            dlg.Dispose();
        }

        private void encodeBtn_Click(object sender, EventArgs e)
        {

            if (!InitCoder())
                MessageBox.Show("Not all necessary data has been delivered");
            _coder.Code();

        }

        private bool InitCoder()
        {
            var acceptedError = acceptedErrorTextBox.Text;
            int intAcceptedError;
            var isInt = TryParse(acceptedError, out intAcceptedError);
            if (!isInt ||intAcceptedError<0)
                return false;

            RadioButton checkedRb=predictorGroupBox.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (checkedRb == null)
                return false;
            var predictorType = _predictionTypes.FirstOrDefault(x=>x.Value==checkedRb.Text).Key;

            int origImageWidth;
            int origImageHeight;

            try
            {
               origImageWidth = originalImagePb.Image.Size.Width;
               origImageHeight = originalImagePb.Image.Size.Height;

            }
            catch (NullReferenceException)
            {
                
                return false;
            }
            if (origImageWidth <= 0|| origImageHeight <=0 || origImageWidth !=origImageHeight)
                return false;

            //mai trebuie tratat cazul cand nu e checked save mode
            _coder= new Coder(intAcceptedError,0,512,predictorType,origImageHeight, ImageHandler.ImageToMatrix(origPicturePath, origImageHeight , origImageWidth));
            return true;
            

        }

   

    }
}
