using NearLosslessPredictiveCoder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNearLossless
{
    class Program
    {
        static void Main(string[] args)
        {

            var coder = new Coder(2, 0, 15, 4, 4);
            coder.originalImage = new int[,] { { 7, 5, 2, 0 }, { 2, 11, 1, 0 }, { 15, 15, 15, 0 }, { 1, 4, 14, 14 } };
            coder.Code();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                    Console.Write(coder.quatizedPredictionError[i, j] + " ");
                Console.WriteLine();
            }

        }
    }
}
