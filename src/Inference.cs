using static NewFAHP.SerialNumbers;

namespace NewFAHP
{
    /*
        public static int TS_SE = 0;
        public static int TS_MF = 1;
        public static int TS_SA = 2;
        public static int TS_LA = 3;
        public static int TS_AA = 4;
     */

    public static class Inference
    {

        public static (int, int, int)[,] TFNs = new (int, int, int)[3, 5];

        public static (double, double, double)[,] ComparisonMatrix(int[] values)
        {
            (double, double, double)[,] CompMat = new (double, double, double)[6, 6];



            return CompMat;
        }

        public static (int, int, int) Multiply(this (int, int, int) a, (int, int, int) b)
        {
            int[] Items = new int[] { a.Item1 * b.Item1, a.Item1 * b.Item3, a.Item3 * b.Item1, a.Item3 * b.Item3 };
            
            int Left = Items[0], Middle = a.Item2 * b.Item2, Right = Items[0];

            for (int i = 0; i < 4; i++)
            {
                if (Items[i] < Left)
                    Left = Items[i];
                if (Items[i] > Right)
                    Right = Items[i];
            }

            return (Left, Middle, Right);
        }
    }
}