using NearLosslessPredictiveCoder;
using System;
using System.Collections;
using System.Text;

namespace TestNearLossless
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test the coding algorithm
            /*var coder = new Coder(2, 0, 15, 4, 4)
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
            }*/

            Console.ReadLine();
        }



        private static void DisplayBitArray(BitArray bitArray, int typeLength)
        {
            for (int i = 0; i < bitArray.Length; i++)
            {
                if (i % typeLength == 0)
                    Console.WriteLine();
                Console.Write(bitArray[i] ? 1 : 0);
            }
            Console.WriteLine();
        }



    }

}

