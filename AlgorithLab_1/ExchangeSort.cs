using AlgorithLab_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithLab_1
{
    public class ExchangeSort : IExecutable
    {
        public void Execute(int n)
        {
            int[] randomArray = Program.RandomArray(n);
            Sort(randomArray);
        }

        public Func<double, double> GetComplexityFunction() => num => num * num;
        
        public static void Sort(int[] inputArray) 
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = i; j < inputArray.Length; j++)
                {
                    if (inputArray[j] < inputArray[i])
                    {
                        int container = inputArray[j];
                        inputArray[j] = inputArray[i];
                        inputArray[i] = container;
                    }
                }
            }
        }
        public static long Timer(int variableCount)
        {
            return TimeMaesures.Timer(variableCount, new ExchangeSort());
        }
    }
}
