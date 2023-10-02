using AlgorythmLab1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithLab_1
{
    public class TimeMesures
    {


        public static long StartAlgFromTag(int variablesCount, string tag)
        {
            switch (tag)
            {
                case "const":
                        return SimpleAlgorithms.ConstTimer(variablesCount);
                case "sum":
                        return SimpleAlgorithms.SumTimer(variablesCount);
                case "mult":
                        return SimpleAlgorithms.MultTimer(variablesCount);
                case "naivePol":
                        return SimpleAlgorithms.NaivePolynomialTimer(variablesCount);
                case "gorner":
                        return SimpleAlgorithms.GornersTimer(variablesCount);
                case "exchange":
                        return ExchangeSort.Timer(variablesCount);
                case "quick":
                        return QuickSort.Timer(variablesCount);
                case "bubble":
                        return BubbleSort.Timer(variablesCount);
                default:
                    return 0;
            }
        }
        public static void  MeasureTheTime(string tag, int variablesCount, int testsCount, int steps, string savePath)
        {
            long[] timeNotes = new long[testsCount];
            string[] times = new string[variablesCount];
            

            for (int i = steps; i <= variablesCount; i+=steps)
            {
                for (int j = 0; j < testsCount; j++)
                {
                    timeNotes[j] = StartAlgFromTag(variablesCount, tag);
                }
                long avarageTime = timeNotes.Sum() / testsCount;
                times[i - 1] = avarageTime.ToString();
            }
            File.WriteAllLines(savePath + "\\" + tag + "measures.txt", times);
        }
    }
}
