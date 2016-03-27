using BitHandler;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBitHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new BitReader("Test.txt");

            var y = new BitWriter("TestWrite.txt");
            //bool? bla;
            //do
            //{
            //    bla = x.Read();
            //    if (bla != null)
            //        Console.Write((bool)bla ? 1 : 0);

            //} while (bla != null);

            //***************************************************************/

            //BitArray bla;
            // do
            // {
            //     bla = x.ReadNBits(8);
            //     if (bla != null)
            //     {
            //         for(int i=0;i<bla.Length;i++)
            //         {

            //             Console.Write(bla[i]?1:0);
            //         }

            //         Console.WriteLine();
            //     }


            // } while (bla != null);

            //*******************************************//

            //bool? bla;
            //do
            //{
            //    bla = x.Read();
            //    if (bla != null)
            //        y.WriteBit((bool)bla);

            //} while (bla != null);

            //y.FlushLastBits();

            //Process.Start("TestWrite.txt");

            //********************************************//

            BitArray bla;
            do
            {
                bla = x.ReadNBits(3);
                if (bla != null)
                {
                    y.WriteNBits(bla);
                   
                }


            } while (bla != null);

            y.FlushLastBits();

            Process.Start("TestWrite.txt");



        }
    }
}
