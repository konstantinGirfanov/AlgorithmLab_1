using AlgorithLab_1;
using System.Diagnostics;

namespace AlgorythmLab1;

public class BubbleSort : IExecutable
{
    public void Execute(int n)
    {
        int[] randomArray = Program.RandomArray(n);
        Sort(randomArray);
    }
    
    public static int[] Sort(int[] arr)
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

        return arr;
    }
    public static long Timer(int variableCount)
    {
        return TimeMesures.Timer(variableCount, new BubbleSort());
    }
}
   