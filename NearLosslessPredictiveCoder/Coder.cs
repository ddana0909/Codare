using System;
using System.Drawing.Text;

namespace NearLosslessPredictiveCoder
{
    public class Coder
    {
        private int k;
        private int rangeMinValue { get; set; }
        private int rangeMaxValue { get; set; }
        private int predFormula;
        private int imageDimension;
        public int[,] originalImage;
        private int[,] prediction1;
        public int[,] predictionError;
        public int[,] quatizedPredictionError;
        private int[,] deQuatizedPredictionError;
        private int[,] prediction2;
        private int[,] decoded;
        private int[,] error;

        public Coder(int acceptedError, int min, int max, int predictionType, int imageDim, int[,] origMatrix)
        {
            k = acceptedError;
            predFormula = predictionType;
            rangeMinValue = min;
            rangeMaxValue = max;
            imageDimension = imageDim;
            InitMatrixes();
            originalImage = origMatrix;
        }

        private void InitMatrixes()
        {
            originalImage = new int[imageDimension, imageDimension];
            prediction1 = new int[imageDimension, imageDimension];
            predictionError = new int[imageDimension, imageDimension];
            quatizedPredictionError = new int[imageDimension, imageDimension];
            deQuatizedPredictionError = new int[imageDimension, imageDimension];
            prediction2 = new int[imageDimension, imageDimension];
            decoded = new int[imageDimension, imageDimension];
            error = new int[imageDimension, imageDimension];
        }
        public void Code()

        {
            for (var i = 0; i < imageDimension ; i++)
                for (var j = 0; j < imageDimension ; j++)
                {
                    prediction1[i, j] = TruncateValueToInterval(PredictValue(i, j)); //predictionFormula --change
                    predictionError[i, j] = originalImage[i, j] - prediction1[i, j];
                    quatizedPredictionError[i, j] = Quantize(predictionError[i, j]);
                    deQuatizedPredictionError[i, j] = DeQuantize(quatizedPredictionError[i, j]);
                    decoded[i, j] = deQuatizedPredictionError[i, j] + prediction1[i, j];
                    error[i, j] = originalImage[i, j] - decoded[i, j];
                }
        }


        private int Quantize(int value)
        {
            return (int)Math.Floor((double)(value + k) / (2 * k + 1));
        }
        private int DeQuantize(int value)
        {
            return value * (2 * k + 1);
        }
        private int PredictValue(int line, int column) //from decoded matrxi
        {
            var halfRange = (rangeMaxValue - rangeMinValue + 1) / 2;
            if (line == 0 && column == 0)
                return PredictionFunctions.pHalfRange(halfRange);
            int b;
            if (column != 0)
            {
                var a = decoded[line, column - 1];
                if (line == 0)
                    return PredictionFunctions.pVal(a);
                b = decoded[line - 1, column];
                var c = decoded[line - 1, column - 1];
                return PredictionFunctions.Predict(a, b, c, predFormula, halfRange);
            }
            b = decoded[line - 1, column];
            return PredictionFunctions.pVal(b);
        }

        private int TruncateValueToInterval(int value)
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
