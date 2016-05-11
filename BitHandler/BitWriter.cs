using System;
using System.Collections;
using System.IO;
using System.Text;

namespace BitHandler
{
    public class BitWriter
    {
        private BitArray writeBuffer;
        private int noOfBitsWritten;
        private string filePath;
        private FileStream file;

        public BitWriter(string path)
        {
            noOfBitsWritten = 0;
            filePath = path;
            writeBuffer = new BitArray(8);
            file = File.Create(filePath);

        }

        public void WriteBit(bool bit)
        {

            writeBuffer[(noOfBitsWritten % 8)] = bit;
            noOfBitsWritten++;
            if (noOfBitsWritten % 8 == 0)
            {
                file.WriteByte(WriteBufferAsByte());
                writeBuffer = new BitArray(8);
            }

        }

        public void WriteNBits(BitArray array)
        {
            for (int i = 0; i < array.Count; i++)
                WriteBit(array[i]);
        }

        public void WriteIntOnNBits(int value, int noOfBits)
        {
            WriteNBits(IntToBitArray(value, noOfBits));
        }

        public void WriteString(string text)
        {
            var finalBitArray = new BitArray(text.Length * 8);
            byte[] asciiText = Encoding.ASCII.GetBytes(text);
            for (int i = 0; i < asciiText.Length; i++)
            {
                var bitArray = new BitArray(new byte[] { asciiText[i] });
                var reverted = new bool[8];
                bitArray.CopyTo(reverted, 0);
                Array.Reverse(reverted);
                bitArray = new BitArray(reverted);
                WriteNBits(bitArray);
            }
        }

        public void FlushLastBits()
        {
            if (WriteBufferAsByte() != 0) // doar daca in writeBuffer e ceva concret 0x0 -> Null
            {
                while (noOfBitsWritten % 8 != 0)
                    WriteBit(false);
            }
            file.Close();
        }

        private byte WriteBufferAsByte()
        {
            byte[] auxByteArray = new byte[1];
            writeBuffer.CopyTo(auxByteArray, 0);
            return auxByteArray[0];
        }
        private  BitArray IntToBitArray(int value, int length)
        {
            int[] intArray = new int[1] { value };
            BitArray bitArray = new BitArray(intArray);
            bool[] bits = new bool[length];
            for (int i = 0; i < length; i++)
                bits[i] = bitArray[i];
            Array.Reverse(bits);
            bitArray = new BitArray(bits);
            return bitArray;
        }

    }
}
