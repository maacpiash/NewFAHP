using static NewFAHP.Numbers;

namespace NewFAHP
{
    public static class Inference
    {

        public static (double, double, double)[,] ComparisonMatrix(int[] values, int ConfLevel)
        {
#region Validation
            if (values.Length < 5)
                throw new System.ArgumentException("At least 5 integers are expected.");

            for (int i = 0; i < 4; i++)
                if (values[i] < -9 || values[i] > 9)
                    throw new System.ArgumentException($"Error at {i} = {values[i]}: Fuzzy input must be between -9 and +9.");

            if (ConfLevel < 0 || ConfLevel > 2)
                throw new System.ArgumentException("Confidence level must be between 1 and 3.");
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

            int max = 5;

            for (int j = 0; j < max; j++)
                CompMat[j, j] = (1.0, 1.0, 1.0); // 0-th => Equality
            
            for (int k = 0, l, m; k < max; k++)
            {
                l = k + 1;
                m = values[k];
                if (m >= 0)
                {
                    CompMat[0, l] = TFNs[ConfLevel, m];
                    CompMat[l, 0] = TFNs[ConfLevel, m].Inverse();
                }
                else
                {
                    CompMat[l, 0] = TFNs[ConfLevel, - m];
                    CompMat[0, l] = TFNs[ConfLevel, - m].Inverse();
                }
            }
            
             for (int r = 1; r <= max; r++)
             for (int c = r + 1; c <= max; c++)
             {
                 CompMat[r, c] = CompMat[r, 0].Multiply(CompMat[0, c]);
                 CompMat[c, r] = CompMat[r, c].Inverse();
             }
             

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