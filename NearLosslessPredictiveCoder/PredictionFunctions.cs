using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearLosslessPredictiveCoder
{
    public static class PredictionFunctions
    {

        public static int Predict(int a, int b, int c, int formula, int halfRange = 0)
        {
            switch (formula)
            {
                case 0:
                    return pHalfRange(halfRange);
                case 1:
                    return pVal(a);
                case 2:
                    return pVal(b);
                case 3:
                    return pVal(c);
                case 4:
                    return pAbc(a, b, c);
                case 5:
                    return pAbc2(a, b, c);
                case 6:
                    return pBac2(a, b, c);
                case 7:
                    return pAb2(a, b);
                default:
                    return pJpegLs(a, b, c);

            }
        }
        public static int pHalfRange(int halfRange)
        {
            return halfRange;
        }
        public static int pVal(int x)
        {
            return x;
        }

        private static int pAbc(int a, int b, int c)
        {
            return a + b - c;
        }
        private static int pAbc2(int a, int b, int c)
        {
            return (a + b - c) / 2;
        }
        private static int pBac2(int a, int b, int c)
        {
            return b + (a - c) / 2;
        }
        private static int pAb2(int a, int b)
        {
            return (a + b) / 2;
        }

        private static int pJpegLs(int a, int b, int c)
        {
            if (c >= Math.Max(a, b))
                return Math.Min(a, b);
            if (c <= Math.Min(a, b))
                return Math.Max(a, b);
            return a + b - c;
        }



    }
}
