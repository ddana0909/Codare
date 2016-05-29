using System;

namespace Wavelet
{
    public class Coder
    {
        private double[] _analysisCoefLow = new double[] { 0.026748757411, -0.016864118443, -0.078223266529, 0.266864118443, 0.602949018236, 0.266864118443, -0.078223266529, -0.016864118443, 0.026748757411 };
        private double[] _analysisCoefHigh = new double[] { 0.000000000000, 0.091271763114, -0.057543526229, -0.591271763114, 1.115087052457, -0.591271763114, -0.057543526229, 0.091271763114, 0.000000000000 };
        private double[] _synthesisCoefLow = new double[] { 0.000000000000, -0.091271763114, -0.057543526229, 0.591271763114, 1.115087052457, 0.591271763114, -0.057543526229, -0.091271763114, 0.000000000000 };
        private double[] _synthesisCoefHigh = new double[] { 0.026748757411, 0.016864118443, -0.078223266529, -0.266864118443, 0.602949018236, -0.266864118443, -0.078223266529, 0.016864118443, 0.026748757411 };

        private int[,] _inputMatrix;
        public double[,] WaveletMatrix;
        private int _dimension;
        public byte[] Header;
        public int MaxError;
        public int MinError;

        public Coder(string filePath, int dimension)
        {

            WaveletMatrix = new double[dimension, dimension];
            _inputMatrix = new int[dimension, dimension];
            var imageMatrix = ImageHandler.ImageHandler.ReadImageByteMatrixFromFile(filePath, dimension, dimension, out Header);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    _inputMatrix[i, j] = imageMatrix[i, j];
                    WaveletMatrix[i, j] = 1.0 * imageMatrix[i, j];
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

                var processedLine = ProcessExdendedLine(extendedLine, limit);
                for (int j = 0; j < limit; j++)
                {
                    WaveletMatrix[i, j] = processedLine[j];
                }


            }

        }

        public void AnalysisVerical(int level)
        {
            int limit = _dimension / (int)Math.Pow(2, level - 1);

            for (int i = 0; i < limit; i++)
            {
                double[] extendedLine = new double[limit + 8];
                for (int j = 0; j < limit; j++)
                {
                    extendedLine[j + 4] = WaveletMatrix[j, i];
                    if (j < 5)
                        extendedLine[4 - j] = WaveletMatrix[j, i];
                    if (j >= limit - 5)
                        extendedLine[limit + 8 - 1 - (j - (limit - 5))] = WaveletMatrix[j, i];
                }

                var processedLine = ProcessExdendedLine(extendedLine, limit);
                for (int j = 0; j < limit; j++)
                {
                    WaveletMatrix[j, i] = processedLine[j];
                }


            }

        }

        public void SynthesisVertical(int level)
        {
            int limit = _dimension / (int)Math.Pow(2, level - 1);
            for (int col = 0; col < limit; col++)
            {
                double[] longlow = new double[limit];
                double[] longhigh = new double[limit];

                double[] low = new double[limit];
                double[] high = new double[limit];


                var lowIndex = 0;
                var highIndex = 1;
                for (int i = 0; i < limit; i++)
                {
                    if (i < limit / 2)
                    {
                        longlow[lowIndex] = WaveletMatrix[i, col];
                        lowIndex += 2;
                    }
                    else
                    {
                        longhigh[highIndex] = WaveletMatrix[i, col];
                        highIndex += 2;
                    }
                }

                for (int i = 0; i < limit; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        int index;
                        index = i - 4 + k;

                        if (index < 0)
                            index = Math.Abs(index);

                        if (index >= limit)
                            index = limit - 1 - (index - (limit - 1));

                        low[i] += _synthesisCoefLow[k] * longlow[index];
                        high[i] += _synthesisCoefHigh[k] * longhigh[index];
                    }
                }

                for (int i = 0; i < limit; i++)
                {
                    WaveletMatrix[i, col] = low[i] + high[i];
                }
            }
        }

        public void SynthesisHorizontal(int level)
        {
            int limit = _dimension / (int)Math.Pow(2, level - 1);

            for (int line = 0; line < limit; line++)
            {
                double[] longlow = new double[limit];
                double[] longhigh = new double[limit];

                double[] low = new double[limit];
                double[] high = new double[limit];

                var lowIndex = 0;
                var highIndex = 1;
                for (int i = 0; i < limit; i++)
                {
                    if (i < limit / 2)
                    {
                        longlow[lowIndex] = WaveletMatrix[line, i];
                        lowIndex += 2;
                    }
                    else
                    {
                        longhigh[highIndex] = WaveletMatrix[line, i];
                        highIndex += 2;
                    }
                }

                for (int i = 0; i < limit; i++)
                {
                    for (int k = 0; k < 9; k++)
                    {

                        int index;
                        index = i - 4 + k;

                        if (index < 0)
                            index = Math.Abs(index);

                        if (index >= limit)
                            index = limit - 1 - (index - (limit - 1));
                        low[i] += _synthesisCoefLow[k] * longlow[index];
                        high[i] += _synthesisCoefHigh[k] * longhigh[index];
                    }
                }
                for (int i = 0; i < limit; i++)
                {
                    WaveletMatrix[line, i] = low[i] + high[i];
                }
            }
        }

        public double[] ProcessExdendedLine(double[] extendedLine, int limit)
        {
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
                    processedLine[j] = low[lowIndex + 4];
                    lowIndex += 2;
                }
                else
                {
                    processedLine[j] = high[highIndex + 4];
                    highIndex += 2;
                }
            return processedLine;
        }

        public void CalculateDifference()
        {
            MinError = int.MaxValue;
            MaxError = int.MinValue;
            for (int i = 0; i < 512; i++)
                for (int j = 0; j < 512; j++)
                {
                    if (_inputMatrix[i, j] - WaveletMatrix[i, j] > MaxError)
                        MaxError = (int)(_inputMatrix[i, j] - WaveletMatrix[i, j]);
                    if (_inputMatrix[i, j] - WaveletMatrix[i, j] < MinError)
                        MinError = (int)(_inputMatrix[i, j] - WaveletMatrix[i, j]);
                }
        }
    }
}
