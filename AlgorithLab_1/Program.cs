using System.Diagnostics;
using System.IO;

namespace AlgorithLab_1
{
    internal class Program
    {
        public static string SavePath = "C:\\Users\\User\\Desktop";
        static void Main()
        {
            
            Console.CursorVisible = false;
            List<MenuItem> menuItems = new List<MenuItem>()
            {
                new MenuItem("Constant algorithm", "const"),
                new MenuItem("Sum algorithm", "sum"),
                new MenuItem("Multiply algorithm", "mult"),
                new MenuItem("Naive Polynomial algorithm", "sum"),
                new MenuItem("Gorner's Method", "gorner"),
                new MenuItem("ExchangeSort algorithm", "exchange"),
                new MenuItem("QuickSort algorithm", "quick"),
                new MenuItem("BubbleSort algorithm", "bubble"),
                new MenuItem("Change save path", "path"),
                new MenuItem("Exit", "exit")
            };
            Menu menu = new Menu(menuItems);

            MenuActions.MoveThrough(menu);
        }

        public static void RequestTheData(string tag)
        {
            string[] input = Console.ReadLine().Split(" ");
            if (IsInputCorrect(input) == false) 
            {
                Console.WriteLine("Некоректный ввод, попробуйте снова");
                RequestTheData(tag);
                return;
            }
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            int testsCount = Int32.Parse(input[2]);
            TimeMesures.MeasureTheTime(tag, variablesCount, testsCount, steps, SavePath);
        }


        private static bool IsInputCorrect(string[] input)
        {

            if (input.Count() != 3)
            {
                return false;
            }
            foreach (string s in input)
            {
                if (Int32.TryParse(s, out int _) == false)
                {
                    return false;
                }
            }
            return true;
        }
        private static void ChangeTheSavePath()
        {
            //сделать
        }
        public static int[] RandomArray(int length)
        {
            Random randomNum = new();
            int[] randomVariables = new int[length];
            for (int n = 0; n < length; n++)
                randomVariables[n] = randomNum.Next();
            return randomVariables;
        }

    }
}

        