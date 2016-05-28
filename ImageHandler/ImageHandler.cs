using System.IO;
using System.Linq;

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


        public static MemoryStream ImageByteStream (double[,] matrix, byte[] header, int dimension)
        {
            byte[] imagebytes = new byte[1078 + dimension * dimension];
            for (int i = 0; i < 1078; i++)
            {
                imagebytes[i] = header[i];
            }
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    //_decodedImageMatrix[i, j] = x.Decoded[i, j];
                    imagebytes[1078 + i * dimension + j] = (byte)matrix[i, j];
                }
            }


            return new MemoryStream(imagebytes);

        }
    }
}
