using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearLosslessPredictiveCoder
{
    public class Decoder : Coder
    {
        public Decoder(int acceptedError, int min, int max, int predictionType, int imageDim, int[,] quantizedPredictionError)
        {
            k = acceptedError;
            predFormula = predictionType;
            rangeMinValue = min;
            rangeMaxValue = max;
            imageDimension = imageDim;
            InitMatrixes();
            QuatizedPredictionError = quantizedPredictionError;
        }

        public void Decode()
        {
            for (var i = 0; i < imageDimension; i++)
                for (var j = 0; j < imageDimension; j++)
                {
                     //predictionFormula --change
                    //PredictionError[i, j] = OriginalImage[i, j] - prediction1[i, j];
                    //QuatizedPredictionError[i, j] = Quantize(PredictionError[i, j]);
                    deQuatizedPredictionError[i, j] = DeQuantize(QuatizedPredictionError[i, j]);
                    prediction1[i, j] = TruncateValueToInterval(PredictValue(i, j));
                    Decoded[i, j] = deQuatizedPredictionError[i, j] + prediction1[i, j];
                    error[i, j] = OriginalImage[i, j] - Decoded[i, j];
                }
        }

    }

}
