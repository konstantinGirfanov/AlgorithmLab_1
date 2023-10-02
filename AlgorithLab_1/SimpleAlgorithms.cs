using System.Diagnostics;

namespace AlgorithLab_1
{
    public class SimpleAlgorithms
    {
        public static int DoTheConstAlgorithm(int[] inputArray)
        {
            return 1;
        }

        public static int DoTheSumAlgorithm(int[] inputArray) 
        { 
            int sum = 0;
            foreach (int i in inputArray)
                sum += i;
            return sum;
        }

        public static int DoTheMultiplyAlgorithm(int[] inputArray)
        {
            int mult = 1;
            foreach (int i in inputArray)
                mult *= i;
            return mult;
        }

        public static double NaiveCountPolynomial(int[] inputArray)
        {
            double polynomialCount = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                polynomialCount += inputArray[i]*Math.Pow(1.5, i-1);
            }
            return polynomialCount;
        }

        public static double DoTheGarnersMethod(int[] inputArray)
        {
            return GornersStepInto(inputArray, 0);
        }

        private static double GornersStepInto(int[] inputArray, int stepNumber)
        {
            if (stepNumber < inputArray.Length)
                return inputArray[stepNumber] + 1.5 * GornersStepInto(inputArray, stepNumber + 1);
            else return 0;
        }
        public static long ConstTimer(int variableCount)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            DoTheConstAlgorithm(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
        public static long SumTimer(int variableCount)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            DoTheSumAlgorithm(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
        public static long MultTimer(int variableCount)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            DoTheMultiplyAlgorithm(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
        public static long NaivePolynomialTimer(int variableCount)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            NaiveCountPolynomial(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
        public static long GornersTimer(int variableCount)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            DoTheMultiplyAlgorithm(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
    }
}
