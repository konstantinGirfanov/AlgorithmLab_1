using AlgorithLab_1;
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
    public class TimeMaesures
    {
        public long ReflexChooseAlg(string name, int variablesCount)
        {
            string[] algClassAndMeth = name.Split('.');
            string className = $"AlgorithLab_1.{algClassAndMeth[0]}";
            string methodName = algClassAndMeth[1];
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetType(className);
            MethodInfo methodInfo = type.GetMethod(methodName, new Type[] { typeof(int) });
            object instance = Activator.CreateInstance(type);
            return (long)methodInfo.Invoke(instance, new object[] { variablesCount });
        }

        public static Type ReflexGetAlgType(string name)
        {
            string[] classAndMethodNames = name.Split('.');
            string className = $"AlgorithLab_1.{classAndMethodNames[0]}";
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetType(className);


        }

        public Data MeasureTheTime(string name, int variablesCount, int testsCount, int steps, string savePath)
        {
            long[] timeNotes = new long[testsCount];
            List<double> doubleTimeNotes = new List<double>();
            string[] times = new string[variablesCount];
            List<double> stepList = new List<double>();
            for (int i = steps; i <= variablesCount; i += steps)
            {
                for (int j = 0; j < testsCount; j++)
                {
                    timeNotes[j] = ReflexChooseAlg(name, i);
                    
                }
                stepList.Add(i);
                long avarageTime = timeNotes.Sum() / testsCount;
                times[i/steps - 1] = $"{i} {avarageTime}";
                doubleTimeNotes.Add((double)avarageTime);
            }
            string path = $"{savePath}\\{name}measures.png";
            return new Data(stepList, doubleTimeNotes, name, ReflexGetAlgType(name));
            //File.WriteAllLines(path, times);
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
