using System.Diagnostics;

namespace AlgorithLab_1
{
    internal class Program
    {
        static void Main()
        {
            MeasureTheTime(2000);
        }
        static void MeasureTheTime (int variablesCount)
        {
            const int testCount = 5;

            long[] timeNotes = new long[testCount];
            Random randomNum = new();
            string[] times = new string[variablesCount];
            Stopwatch timer = new();
            string path = string.Format("C:\\Users\\User\\Desktop\\Рабочая среда\\Алгоритмы\\mesures.txt");
            for (int i = 1; i <= variablesCount; i++)
            {
                int[] randomVariables = new int[i];
                for (int n=0; n<i;n++)
                    randomVariables[n] = randomNum.Next();
                
                for (int j = 0; i < testCount; j++)
                {
                    timer.Start();
                    ///Тут вызвать метод, принмает randomVariables
                    timer.Stop();
                    timeNotes[j] = timer.ElapsedMilliseconds;
                }
                long avarageTime = timeNotes.Sum() / testCount;
                times[i] = avarageTime.ToString();
            }
            File.WriteAllLines(path, times);

           
        }
    }
}

        