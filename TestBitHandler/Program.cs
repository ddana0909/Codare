using BitHandler;
using System;
using System.Collections;
using System.Collections.Generic;
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
            //bool? bla;
            //do
            //{
            //   bla = x.Read();
            //    if(bla!=null)
            //   Console.Write((bool)bla ? 1 : 0);

            //}while (bla != null) ;

           BitArray bla;
            do
            {
                bla = x.ReadNBits(8);
                if (bla != null)
                {
                    for(int i=0;i<bla.Length;i++)
                    {
                          
                        Console.Write(bla[i]?1:0);
                    }
                       
                    Console.WriteLine();
                }
                   
                    
            } while (bla != null);




        }
    }
}
