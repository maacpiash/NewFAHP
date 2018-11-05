using System;

using static System.Console;
using static NewFAHP.Numbers;

namespace NewFAHP
{
    class Program
    {
        static string[] Criteria = { "DIST", "SES", "ADS", "AS", "MFR" };

        static void Main(string[] args)
        {
            int[] values = new int[5];
            int input;
            string read;

            for (int i = 0; i < 5; i++)
            {
                WriteLine($"Compared to TSR, is {Criteria[i]} more important to you?");
                WriteLine($"[A] Yes, {Criteria[i]} is more important\n[B] No, TSR is more important");
                WriteLine("[C] No, they're equally important");
                Write("Please enter (A/B/C): ");
                read = ReadLine();

                switch (read)
                {
                    case "A": case "a":
                        values[i] = -1;
                        break;
                    case "B": case "b":
                        values[i] = 1;
                        break;
                    default:
                        values[i] = 0;
                        break;
                }

                if (values[i] != 0)
                {
                    WriteLine($"\nHow much more important?");
                    WriteLine("[1] Weakly\n[2] Moderately\n[3] Very much\n[4] Strongly\n[5] Absolutely");
                    Write("Please enter (1—5): ");
                    input = int.Parse(ReadLine()) - 1;
                    values[i] *= input;
                }
                WriteLine();
            }

            WriteLine("\nFinally, how confident are you with your answer?");
            WriteLine("[1] Weakly\n[2] Moderately\n[3] Very much\n[4] Strongly\n[5] Absolutely");
            Write("Please enter (1—5): ");
            input = Convert.ToInt16(ReadKey().KeyChar.ToString()) - 1;
            WriteLine();

            for (int i = 0; i < 5; i++)
                WriteLine(values[i]);

            var ComparisonMatrix = Inference.ComparisonMatrix(values, input);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                    Write($"({ComparisonMatrix[i, j].Item1}, {ComparisonMatrix[i, j].Item2}, {ComparisonMatrix[i, j].Item3})");
                WriteLine();
            }
            

            // var fahp = new FAHP(ComparisonMatrix);
            // var weights = fahp.CriteriaWeights;

            // for (int i = 0; i < 6; i++)
            //     Console.WriteLine($"{Criteria[i]} = {weights[i]}");
        }
    }
}
