using AlgorithLab_1;
using System.Diagnostics;

namespace AlgorythmLab1;

public class BubbleSort : ISortable
{
    public static void Sort(int[] arr)
    {
        var n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    var tempVar = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = tempVar;
                }
            }
        }
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
   