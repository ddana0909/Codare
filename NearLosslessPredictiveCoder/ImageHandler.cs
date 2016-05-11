using System.IO;
using System.Linq;

namespace NearLosslessPredictiveCoder
{
    public static class ImageHandler
    {
        public static int[,] ImageToMatrix(string path, int height, int weight, out byte [] header)
        {
            byte[] image = File.ReadAllBytes(path);
            header = image.Take(1078).ToArray();
            var imageMatrix = new int[height, weight];
            var imageBookmark = 1078;
            for (var i=0;i<height;i++)
                for (var j = 0; j < weight; j++)
                {
                    imageMatrix[i, j] = image.ElementAt(imageBookmark);
                    imageBookmark++;
                }
            return imageMatrix;


        }
    }
}
