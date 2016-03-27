using System.Collections;
using System.IO;

namespace BitHandler
{
    public class BitReader
    {
        private BitArray readBuffer;
        private int noOfBitsRead;
        private string filePath;
        private int fileBookmark;
        private FileStream file;
        public BitReader(string path)
        {
            fileBookmark = 0;
            noOfBitsRead = 0;
            filePath = path;
            file = File.Open(filePath, FileMode.Open);

        }

        public bool? Read()
        {
            var auxArray = new byte[1];
            if (noOfBitsRead % 8 == 0)
            {
                if (file.CanRead && fileBookmark != file.Length)
                {

                    auxArray[0] = (byte)file.ReadByte();
                    readBuffer = new BitArray(auxArray);
                    noOfBitsRead++;
                    fileBookmark++;
                    return readBuffer[0];
                }
                else
                {
                    file.Close(); 
                    return null;
                }

            }
            noOfBitsRead++;
            return readBuffer[(noOfBitsRead - 1) % 8];
        }

        public BitArray ReadNBits(int noOfBits)
        {
            var bitsRead = new BitArray(noOfBits);
            for (int i = 0; i < noOfBits; i++)
            {
                var bitRead = Read();
                if (bitRead == null && i == 0)
                {
                    file.Close();
                    return null;
                }

                if (bitRead != null)

                    bitsRead[i] = (bool)bitRead;
            }
            return bitsRead;
        }
    }
}
