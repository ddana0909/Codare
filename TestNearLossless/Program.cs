using NearLosslessPredictiveCoder;
using System;

namespace TestNearLossless
{
    class Program
    {
        static void Main(string[] args)
        {

            var coder = new Coder(2, 0, 15, 4, 4)
            {
                originalImage = new int[,] {{7, 5, 2, 0}, {2, 11, 1, 0}, {15, 15, 15, 0}, {1, 4, 14, 14}}
            };
            coder.Code();
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                { if(coder.quatizedPredictionError[i, j]>=0)
                        Console.Write(@" ");
                    Console.Write(coder.quatizedPredictionError[i, j] + @" ");
                }
                Console.WriteLine();
            }

        }
    }
}
