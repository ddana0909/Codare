﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitHandler
{
    public class BitWriter
    {
        private BitArray writeBuffer;
        private int noOfBitsWritten;
        private string filePath;
        private int fileBookmark;
        private FileStream file;

        public BitWriter(string path)
        {
            fileBookmark = 0;
            noOfBitsWritten = 0;
            filePath = path;
            writeBuffer = new BitArray(8);

            file=File.Create(filePath);
            //file = File.Open(filePath, FileMode.Open);

        }
        public void WriteBit(bool bit)
        {

            writeBuffer[(noOfBitsWritten % 8)] = bit;
            noOfBitsWritten++;
            if (noOfBitsWritten % 8 == 0)
            {
                file.WriteByte(ConvertWriteBufferToByte());
                writeBuffer = new BitArray(8);
            }

        }

        private byte ConvertWriteBufferToByte()
        {
            byte[] auxByteArray = new byte[1];
            writeBuffer.CopyTo(auxByteArray, 0);
            return auxByteArray[0];
        }

        public void WriteNBits(BitArray array)
        {
            for (int i = 0; i < array.Count; i++)
                WriteBit(array[i]);
        }

        public void FlushLastBits()
        {
            if (ConvertWriteBufferToByte() != 0) // doar daca in writeBuffer e ceva concret 0x0 -> Null
            {
                while (noOfBitsWritten % 8 != 0)
                    WriteBit(false);
            }
            file.Close();
        }
    }
}
