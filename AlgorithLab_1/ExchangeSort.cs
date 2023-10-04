using AlgorythmLab1;
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
        public long Timer(int variableCount)
        {
            return TimeMesures.Timer(variableCount, new ExchangeSort());
        }
    }
}
