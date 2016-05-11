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
            var predictorType = "GL";
            byte[] predictor = Encoding.ASCII.GetBytes("p" + predictorType);
            //byte[] error = Encoding.ASCII.GetBytes("k" + acceptedError);
            //byte[] saveMeth = Encoding.ASCII.GetBytes("k" + saveMode);

            // writer.WriteNBits(new BitArray(predictor));
            //writer.WriteNBits(new BitArray(error));
            //writer.WriteNBits(new BitArray(saveMeth));

            var bitarray = new BitArray(predictor);

            int x = -2;
            int y = 2;
             bitarray = new BitArray(new[] {1,-1,0,2,-2, 5,-5});

            for (int i = 0; i < bitarray.Length; i++)
            {
                if (i % 32 == 0)
                    Console.WriteLine();
                Console.Write(bitarray[i] ? 1 : 0);

            }
            Console.WriteLine();
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

        }
    }
}
