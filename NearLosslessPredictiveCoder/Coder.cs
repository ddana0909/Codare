using System;
using System.Drawing.Text;

namespace NearLosslessPredictiveCoder
{
    public class Coder
    {
        protected int k;
        protected int rangeMinValue { get; set; }
        protected int rangeMaxValue { get; set; }
        protected int predFormula;
        protected int imageDimension;
        public int[,] OriginalImage;
        protected int[,] prediction1;
        public int[,] PredictionError;
        public int[,] QuatizedPredictionError;
        protected int[,] deQuatizedPredictionError;
       // private int[,] prediction2;
        public int[,] Decoded;
        protected int[,] error;

        protected Coder()
        {

        }
        public Coder(int acceptedError, int min, int max, int predictionType, int imageDim, int[,] origMatrix)
        {
            k = acceptedError;
            predFormula = predictionType;
            rangeMinValue = min;
            rangeMaxValue = max;
            imageDimension = imageDim;
            InitMatrixes();
            OriginalImage = origMatrix;
        }

        protected void InitMatrixes()
        {
            OriginalImage = new int[imageDimension, imageDimension];
            prediction1 = new int[imageDimension, imageDimension];
            PredictionError = new int[imageDimension, imageDimension];
            QuatizedPredictionError = new int[imageDimension, imageDimension];
            deQuatizedPredictionError = new int[imageDimension, imageDimension];
            //prediction2 = new int[imageDimension, imageDimension];
            Decoded = new int[imageDimension, imageDimension];
            error = new int[imageDimension, imageDimension];
        }
        public void Code()

        {
            for (var i = 0; i < imageDimension ; i++)
                for (var j = 0; j < imageDimension ; j++)
                {
                    prediction1[i, j] = TruncateValueToInterval(PredictValue(i, j)); //predictionFormula --change
                    PredictionError[i, j] = OriginalImage[i, j] - prediction1[i, j];
                    QuatizedPredictionError[i, j] = Quantize(PredictionError[i, j]);
                    deQuatizedPredictionError[i, j] = DeQuantize(QuatizedPredictionError[i, j]);
                    Decoded[i, j] = deQuatizedPredictionError[i, j] + prediction1[i, j];
                    error[i, j] = OriginalImage[i, j] - Decoded[i, j];
                }
        }


        private int Quantize(int value)
        {
            return (int)Math.Floor((double)(value + k) / (2 * k + 1));
        }
        protected int DeQuantize(int value)
        {
            return value * (2 * k + 1);
        }
        protected int PredictValue(int line, int column) //from decoded matrxi
        {
            var halfRange = (rangeMaxValue - rangeMinValue + 1) / 2;
            if (line == 0 && column == 0)
                return PredictionFunctions.pHalfRange(halfRange);
            int b;
            if (column != 0)
            {
                var a = Decoded[line, column - 1];
                if (line == 0)
                    return PredictionFunctions.pVal(a);
                b = Decoded[line - 1, column];
                var c = Decoded[line - 1, column - 1];
                return PredictionFunctions.Predict(a, b, c, predFormula, halfRange);
            }
            b = Decoded[line - 1, column];
            return PredictionFunctions.pVal(b);
        }

        protected int TruncateValueToInterval(int value)
        {
            if (value < rangeMinValue)
                return rangeMinValue;
            if (value > rangeMaxValue)
                return rangeMaxValue;
            return
                value;
        }
    }


}
