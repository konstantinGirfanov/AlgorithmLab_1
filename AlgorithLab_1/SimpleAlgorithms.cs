using System.Diagnostics;

namespace AlgorithLab_1
{
    public class ConstAlgorythm : IExecutable
    {
        public void Execute(int n)
        {
            DoTheConstAlgorithm(n);
        }

        public Func<double, double> GetComplexityFunction() => num => 0;
        
        public static int DoTheConstAlgorithm(int ny)
        {
            return 1;
        }
        
        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new ConstAlgorythm());
        }
    }
    
    public class NaivePolynomial : IExecutable
    {
        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            NaiveCountPolynomial(randomArray);
        }

        public Func<double, double> GetComplexityFunction() => num => num;
        
        public static double NaiveCountPolynomial(int[] inputArray)
        {
            double polynomialCount = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                polynomialCount += inputArray[i]*Math.Pow(1.5, i-1);
            }
            return polynomialCount;
        }

        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new NaivePolynomial());
        }
    }
    
    public class MultiplyAlgorythm : IExecutable
    {
        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            DoTheMultiplyAlgorithm(randomArray);
        }

        public Func<double, double> GetComplexityFunction() => num => num;
        
        public static int DoTheMultiplyAlgorithm(int[] inputArray)
        {
            int mult = 1;
            foreach (int i in inputArray)
                mult *= i;
            return mult;
        }
        
        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new MultiplyAlgorythm());
        }
    }
    
    public class SumAlgorythm : IExecutable
    {

        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            DoTheSumAlgorithm(randomArray);
        }

        public Func<double, double> GetComplexityFunction() => num => num;

        public static int DoTheSumAlgorithm(int[] inputArray) 
        { 
            int sum = 0;
            foreach (int i in inputArray)
                sum += i;
            return sum;
        }

        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new SumAlgorythm());
        }
    }
    
    public class GornersMethod : IExecutable
    {
        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            DoTheGornersMethod(randomArray);
        }

        public Func<double, double> GetComplexityFunction() => num => num;
        
        public static double DoTheGornersMethod(int[] inputArray)
        {
            return GornersStepInto(inputArray);
        }
        
        private static double GornersStepInto(int[] inputArray)
        {
            int stepNumber = inputArray.Length - 1;
            double sum = 0;
            while (stepNumber > 0) 
            {
                sum *= 1.5;
                sum += inputArray[stepNumber];
                stepNumber--;
            }
            return sum;

        }
        
        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new GornersMethod());
        }
    }
}
