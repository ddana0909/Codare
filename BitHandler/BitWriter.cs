using System.Collections;
using System.IO;

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
    }
}
