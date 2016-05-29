using System.IO;
using System.Linq;
using System.Drawing;
using System;

namespace ImageHandler
{
    public static class ImageHandler
    {
        public static int[,] ImageToMatrix(string path, int height, int weight, out byte[] header)
        {
            byte[] image = File.ReadAllBytes(path);
            header = image.Take(1078).ToArray();
            var imageMatrix = new int[height, weight];
            var imageBookmark = 1078;
            for (var i = 0; i < height; i++)
                for (var j = 0; j < weight; j++)
                {
                    imageMatrix[i, j] = image.ElementAt(imageBookmark);
                    imageBookmark++;
                }
            return imageMatrix;
        }

        public static byte[,] ReadImageByteMatrixFromFile(string path, int heigh, int weigth, out byte[] header)
        {
            header = new byte[1078];
            var imageMatrix = new byte[512, 512];

            BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open, FileAccess.Read));
            header = reader.ReadBytes(1078);
            for (int i = 511; i >= 0; i--)
                for (int j = 0; j < 512; j++)
                {
                    imageMatrix[j, i] = reader.ReadByte();
                }
            reader.Close();
            return imageMatrix;
        }

        public static Bitmap CreateBitmapFromMatrix(double[,] matrix, int dimension)
        {
            Bitmap bitmap = new Bitmap(dimension, dimension);
            for (int i = 0; i < dimension; i++)
                for (int j = 0; j < dimension; j++)
                {
                    var byteField = (byte)Convert.ToInt32(matrix[i, j]);
                    Color color = Color.FromArgb(byteField, byteField, byteField);
                    bitmap.SetPixel(i, j, color);

                }
            return bitmap;
        }


        public static double[,] ScaleAndOffsetImageMatrix(double[,] matrix, double scale, int offset, int dimension, int fromX, int fromY)
        {
            var scaledMatrix = new double[dimension, dimension];
            for (int Xcount = 0; Xcount < dimension; Xcount++)
            {
                for (int Ycount = 0; Ycount < dimension; Ycount++)
                {
                    if (!(Xcount < fromX && Ycount < fromY))
                    {
                        var x = (int)(offset + matrix[Xcount, Ycount] * scale);
                        if (x < 0)
                            x = 0;
                        if (x > 255)
                            x = 255;
                        scaledMatrix[Xcount, Ycount] = x;
                    }
                    else
                        scaledMatrix[Xcount, Ycount] = matrix[Xcount, Ycount];

                }
            }
            return scaledMatrix;

        }

    }
}
