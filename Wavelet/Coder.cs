using System;

namespace Wavelet
{
    public class Coder
    {
        private double[] _analysisCoefLow = new double[] { 0.026748757411, -0.016864118443, -0.078223266529, 0.266864118443, 0.602949018236, 0.266864118443, -0.078223266529, -0.016864118443, 0.026748757411 };
        private double[] _analysisCoefHigh = new double[] { 0.000000000000, 0.091271763114, -0.057543526229, -0.591271763114, 1.115087052457, -0.591271763114, -0.057543526229, 0.091271763114, 0.000000000000 };
        //private int[,] _inputMatrix;
        public double[,] WaveletMatrix;
        private int _dimension;
        public byte[] Header;

        public Coder(string filePath, int dimension)
        {
            
            WaveletMatrix = new double[dimension, dimension];
            var imageMatrix = ImageHandler.ImageHandler.ImageToMatrix(filePath, dimension, dimension, out Header);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    WaveletMatrix[i,j] = 1.0 * imageMatrix[i, j];
                }
            }
            _dimension = dimension;

        }

        public void AnalysisHorizontal(int level)
        {
            int limit = _dimension / (int)Math.Pow(2, level - 1);

            for (int i = 0; i < limit; i++)
            {
                double[] extendedLine = new double[limit + 8];
                for (int j = 0; j < limit; j++)
                {
                    extendedLine[j + 4] = WaveletMatrix[i, j];
                    if (j < 5)
                        extendedLine[4 - j] = WaveletMatrix[i, j];
                    if (j >= limit - 5)
                        extendedLine[limit + 8 - 1 - (j - (limit - 5))] = WaveletMatrix[i, j];
                }
                int k = 4;
                double[] high = new double[limit + 10];
                double[] low = new double[limit + 10];
                while (k < limit + 4)
                {
                    for (int j = -4; j < 5; j++)
                    {
                        high[k] = high[k] + extendedLine[k + j] * _analysisCoefHigh[j + 4];
                        low[k] = low[k] + extendedLine[k + j] * _analysisCoefLow[j + 4];

                    }
                    k++;
                }
                int highIndex = 1, lowIndex = 0;
                double[] processedLine = new double[limit];

                for (int j = 0; j < limit; j++)

                    if (j < limit / 2)
                    {
                        WaveletMatrix[i,j] = low[lowIndex + 4];
                        lowIndex += 2;
                    }
                    else
                    {
                        WaveletMatrix[i,j] = high[highIndex + 4];
                        highIndex += 2;
                    }

            }

        }
    }
}
