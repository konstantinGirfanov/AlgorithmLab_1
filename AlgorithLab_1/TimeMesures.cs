using AlgorythmLab1;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithLab_1
{
    public class TimeMesures
    {
        private Dictionary<string, string> methodSelector = new Dictionary<string, string>()
        {
             {"const", "SimpleAlgorithms.ConstTimer" },
             {"sum", "SimpleAlgorithms.SumTimer" },
             {"mult", "SimpleAlgorithms.MultTimer" },
             {"naivePol", "SimpleAlgorithms.NaivePolynomialTimer" },
             {"gorner", "SimpleAlgorithms.GornersTimer" },
             {"exchange", "ExchangeSort.Timer" },
             {"quick", "QuickSort.Timer" },
             {"bubble", "BubbleSort.Timer" },
             {"obv", "Pow.ObviousPow" },
             {"rec", "Pow.RecPow" },
             {"qPow", "Pow.QuickPow" },
             {"clas", "ClassicQuickPow" },
             {"tim", "TSort.Timer" },
             {"multy", "MultiplyMatrix.Timer" },
             {"li", "Li.Timer" },
        };
        public long ReflexChooseAlg(string tag, int variablesCount)
        {
            string[] classAndMethodNames = methodSelector[tag].Split('.');
            string className = $"AlgorithLab_1.{classAndMethodNames[0]}";
            string methodName = classAndMethodNames[1];
            Type classType = Type.GetType(className);
            object classInstance = Activator.CreateInstance(classType);
            object[] methodParams = new object[] { variablesCount };
            MethodInfo methodInfo = classType.GetMethod(methodName);
            return (long)methodInfo.Invoke(classInstance, methodParams);

        }
        public void MeasureTheTime(string tag, int variablesCount, int testsCount, int steps, string savePath)
        {
            long[] timeNotes = new long[testsCount];
            string[] times = new string[variablesCount];
            

            for (int i = steps; i <= variablesCount; i += steps)
            {
                for (int j = 0; j < testsCount; j++)
                {
                    timeNotes[j] = ReflexChooseAlg(tag, i);
                }
                long avarageTime = timeNotes.Sum() / testsCount;
                times[i/steps - 1] = $"{i} {avarageTime}";
            }
            string path = $"{savePath}\\{tag}measures.txt";
            File.WriteAllLines(path, times);
        }
        public static long Timer(int variableCount, IExecutable executable)
        {
            int[] randomArray = Program.RandomArray(variableCount);
            Stopwatch timer = new();

            timer.Start();
            executable.Execute(variableCount);
            timer.Stop();

            return timer.ElapsedMilliseconds;
        }
    }
}
