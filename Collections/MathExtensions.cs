using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtendedCollections
{
    public static class MathExtensions
    {
        public static double StandardDeviation(this IEnumerable<double> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static string StatisticsToString(this IEnumerable<double> values)
        {
            string result = "";
            result +=
                "AVG: " + values.Average() + 
                " | STD: " + StandardDeviation(values) +
                " | ERR: " + (StandardDeviation(values)/Math.Sqrt(values.Count()));
            return result;
        }

        public static double StandardDeviation(this IEnumerable<long> values)
        {
            double avg = values.Average();
            return Math.Sqrt(values.Average(v => Math.Pow(v - avg, 2)));
        }

        public static int CantorPair(int x, int y)
        {
            return (((x + y) * (x + y + 1)) / 2) + y;
        }

        public static void ReverseCantorPair(int cantor, out int x, out int y)
        {
            var t = (int)Math.Floor((-1 + Math.Sqrt(1 + 8 * cantor)) / 2);
            x = t * (t + 3) / 2 - cantor;
            y = cantor - t * (t + 1) / 2;
        }

        public static int SignedCantorPair(int x, int y)
        {
            x = x >= 0 ? 2 * x : -2 * x + 1;
            y = y >= 0 ? 2 * y : -2 * y + 1;

            return (((x + y) * (x + y + 1)) / 2) + y;
        }

        public static void SignedReverseCantorPair(int cantor, out int x, out int y)
        {
            var t = (int)Math.Floor((-1 + Math.Sqrt(1 + 8 * cantor)) / 2);
            x = t * (t + 3) / 2 - cantor;
            y = cantor - t * (t + 1) / 2;

            x = x % 2 == 0 ? x / 2 : ((1 - x) / 2);
            y = y % 2 == 0 ? y / 2 : ((1 - y) / 2);
        }

        /*
        // --------------------------------------
        // oldschool rand() from Visual Studio
        // --------------------------------------
        int seed = 1;
        void srand(int s) { seed = s; }
        int rand(void) { seed = seed * 0x343fd + 0x269ec3; return (seed >> 16) & 32767; }
        float frand(void) { return float(rand()) / 32767.0; }
        // --------------------------------------
        // hash to initialize the random seed (copied from Hugo Elias)
        // --------------------------------------
        int hash(int n) { n = (n << 13) ^ n; return n * (n * n * 15731 + 789221) + 1376312589; }
        */

    }
}
