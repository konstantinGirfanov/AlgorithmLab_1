using System.Diagnostics;
using AlgorythmLab1;

namespace AlgorithLab_1
{
    internal class Program
    {
        static void Main()
        {
            List<Func<int[], int[]>> sorts = new List<Func<int[], int[]>>()
            {
                QuickSort.Sort,
                BubbleSort.Sort
            };

            foreach (var sort in sorts)
            {
                MeasureTheTime(2000, sort);
            }
        }
        static void MeasureTheTime (int variablesCount, Func<int[], int[]> sort)
        {
            const int testCount = 5;

            long[] timeNotes = new long[testCount];
            Random randomNum = new();
            string[] times = new string[variablesCount];
            Stopwatch timer = new();
            string path = string.Format("C:\\Users\\User\\Desktop\\measures.txt");
            for (int i = 1; i <= variablesCount; i++)
            {
                int[] randomVariables = new int[i];
                for (int n=0; n<i;n++)
                    randomVariables[n] = randomNum.Next();
                
                for (int j = 0; j < testCount; j++)
                {
                    timer.Start();
                    sort(randomVariables);
                    timer.Stop();
                    timeNotes[j] = timer.ElapsedMilliseconds;
                }
                long avarageTime = timeNotes.Sum() / testCount;
                times[i-1] = avarageTime.ToString();
            }
            File.WriteAllLines(path, times);

           
        }
    }
}

        