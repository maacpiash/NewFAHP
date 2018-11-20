using System;
using System.Collections.Generic;
using System.Text;

namespace NewFAHP.Lib
{
    public static class Inference
    {
        public static (double, double, double)[,] ComparisonMatrix(int[] values, int ConfLevel)
        {
            #region Validation
            if (values.Length < 5)
                throw new ArgumentException("At least 5 integers are expected.");

            for (int i = 0; i < 4; i++)
                if (values[i] < -9 || values[i] > 9)
                    throw new ArgumentException($"Error at {i} = {values[i]}: Fuzzy input must be between -9 and +9.");

            if (ConfLevel < 0 || ConfLevel > 2)
                throw new ArgumentException("Confidence level must be between 1 and 3.");
            #endregion

            (double, double, double)[,] CompMat = new (double, double, double)[6, 6];

            (double, double, double)[,] TFNs =
            {
                {
                    (1, 1, 1), (1, 2, 3), (2, 3, 4),
                    (3, 4, 5), (4, 5, 6), (5, 6, 7),
                    (6, 7, 8), (7, 8, 9), (9, 9, 9)
                },
                {
                    (1, 1, 1), (1.5, 2, 2.5), (2.5, 3, 3.5),
                    (3.5, 4, 4.5), (4.5, 5, 5.5), (5.5, 6, 6.5),
                    (6.5, 7, 7.5), (7.5, 8, 8.5), (9, 9, 9)
                },
                {
                    (1, 1, 1), (2, 2, 2), (3, 3, 3),
                    (4, 4, 4), (5, 5, 5), (6, 6, 6),
                    (7, 7, 7), (8, 8, 8), (9, 9, 9)
                }
            };

            int j, k, l;

            for (j = 0; j <= 5; j++)
                CompMat[j, j] = (1.0, 1.0, 1.0); // 0-th => Equality

            for (k = 0; k < 5; k++)
            {
                int temp = values[k];
                if (temp < 0)
                    CompMat[k, k + 1] = TFNs[ConfLevel, - 1 - temp];
                else
                    CompMat[k, k + 1] = TFNs[ConfLevel, - 1 - temp].Inverse();

            }
                

            for (l = 3; l >= 0; l--)
            {
                j = 5 - l;
                k = 4 - l; // k = j - 1
                for (int i = 0; i <= l; i++)
                    CompMat[i, i + j] = CompMat[i, i + 1].Multiply(CompMat[i + k, i + j]);
            }

            for (int r = 1; r <= 5; r++)
                for (int c = 0; c < r; c++)
                    CompMat[r, c] = CompMat[c, r].Inverse();              


            return CompMat;
        }

        public static (double, double, double) Multiply(this (double, double, double) a, (double, double, double) b)
        {
            double[] Items = { a.Item1 * b.Item1, a.Item1 * b.Item3, a.Item3 * b.Item1, a.Item3 * b.Item3 };

            double Left = Items[0], Middle = a.Item2 * b.Item2, Right = Items[0];

            for (int i = 0; i < 4; i++)
            {
                if (Items[i] < Left)
                    Left = Items[i];
                if (Items[i] > Right)
                    Right = Items[i];
            }

            return (Left, Middle, Right);
        }

        public static (double, double, double) Inverse(this (double, double, double) a)
            => (1.0 / a.Item3, 1.0 / a.Item2, 1.0 / a.Item1);
    }
}
