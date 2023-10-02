using AlgorythmLab1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithLab_1
{
    public class ExchangeSort : Sorter
    {
        public static int[] Sort(int[] inputArray) 
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

            return inputArray;
        }
        public static long Timer(int variableCount) 
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            Sort(randomArray);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
    }
}
