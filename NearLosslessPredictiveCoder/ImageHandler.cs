using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BitHandler;

namespace NearLosslessPredictiveCoder
{
    public static class ImageHandler
    {
        public static int[,] ImageToMatrix(string path, int height, int weight)
        {
            byte[] image = System.IO.File.ReadAllBytes(path);
            //header = image.Take(1078).ToArray();
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
