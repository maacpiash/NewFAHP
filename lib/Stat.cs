using System;
using System.Collections.Generic;
using System.Text;

namespace NewFAHP.Lib
{
    public static class Stat
    {
        public static double[] Normalize(ref double[] numbers)
        {
            int max = numbers.Length;
            double sum = 0;
            for (int i = 0; i < max; i++)
                sum += numbers[i];
            for (int i = 0; i < max; i++)
                numbers[i] /= sum;
            return numbers;
        }

        public static double[] Normalize(ref double[] numbers, double lower = 0.0, double upper = 1.0)
        {
            int length = numbers.Length;
            double min = numbers[0], max = numbers[0];
            for (int i = 1; i < length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
                if (numbers[i] < min)
                    min = numbers[i];
            }

            double dx = max - min;
            double diff = upper - lower;
            for (int i = 0; i < length; i++)
                numbers[i] = lower + (numbers[i] - min) * diff / dx;

            return numbers;
        }

        public static (double, double, double) ScalarMultiply
        (this (double, double, double) a, (double, double, double) b)
            => (a.Item1 * b.Item1, a.Item2 * b.Item2, a.Item3 * b.Item3);
    }
}
