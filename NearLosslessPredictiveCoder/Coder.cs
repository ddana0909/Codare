using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private int[,] predictionError;
        public int[,] quatizedPredictionError;
        private int[,] deQuatizedPredictionError;
        private int[,] prediction2;
        private int[,] decoded;
        private int[,] error;

        public Coder(int acceptedError, int min, int max, int predictionFormula, int imageDim)
        {
            k = acceptedError;
            predFormula = predictionFormula;
            rangeMinValue = min;
            rangeMaxValue = max;
            imageDimension = imageDim;
            initMatrixes();
    

        }
        private void initMatrixes()
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
            int a, b, c;
            if (line == 0 && column == 0)
                return PredictionFunctions.pHalfRange(halfRange);
            a = 99999;
            b = 99999;
            c = 99999;
            if (column != 0)
            {
                a = decoded[line, column - 1];
                if (line == 0)
                    return PredictionFunctions.pVal(a);
                else
                {
                    b = decoded[line - 1, column];
                    c = decoded[line - 1, column - 1];
                }
                return PredictionFunctions.Predict(a, b, c, predFormula, halfRange);
            }
            else
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
