using System.Diagnostics;
using System.IO;
using System.Xml.Linq;

namespace AlgorithLab_1
{
    class Program
    {
        public static string SavePath = "C:\\Users\\User\\Desktop";

        static void Main()
        {
            
            Console.CursorVisible = false;
            List<MenuItem> menuItems = new List<MenuItem>()
            {
                new MenuItem("Constant algorithm", "ConstAlgorythm.Timer"),
                new MenuItem("Sum algorithm", "SumAlgorythm.Timer"),
                new MenuItem("Multiply algorithm", "MultiplyAlgorythm.Timer"),
                new MenuItem("Naive Polynomial algorithm", "NaivePolynomial.Timer"),
                new MenuItem("Gorner's Method", "GornersMethod.Timer"),
                new MenuItem("ExchangeSort algorithm", "ExchangeSort.Timer"),
                new MenuItem("QuickSort algorithm", "QuickSort.Timer"),
                new MenuItem("BubbleSort algorithm", "BubbleSort.Timer"),
                new MenuItem("TimSort algorithm", "TSort.Timer"),
                new MenuItem("ObviousPow algorithm", "ObviousPow.Timer"),
                new MenuItem("RecPow algorithm", "RecPow.Pow"),
                new MenuItem("QuickPow algorithm", "QuickPow.Pow"),
                new MenuItem("ClassicQuickPow algorithm", "ClassicQuickPow.Pow"),
                new MenuItem("MatrixMultiply algorithm", "MultiplyMatrix.Timer"),
                new MenuItem("Li algorithm", "Li.Timer"),
                new MenuItem("Sieve Eratosphenes", "SieveEratosphenes.Timer"),
                new MenuItem("Simple Numbers", "SimpleNumbers.Timer"),
                new MenuItem("ChooseAlgs", "MenuActions.ChooseAlgs"),
                new MenuItem("RunAlgs", "Program.RunFewAlgs"),
                new MenuItem($"Change save path (Current path: {SavePath})", "path"),
                new MenuItem("Exit", "exit")
            };
            Menu menu = new Menu(menuItems);
            MenuActions.MoveThrough(menu);
        }

        public static void RunFewAlgs(List<string> algs)
        {
            ConsoleHelper.ClearScreen();
            Console.WriteLine("Введите максимальный размер входных данных, шаг и количество проверок(через одиночные пробелы)");
            List<Data> FewData = new();
            foreach(string item in algs)
            {
                FewData.Add(RequestTheData(item));
            }
            string path = $"{SavePath}\\FewAlgsMeasures.png";
            Drawer.Draw("FewAlgs", path, FewData);
            /*Console.WriteLine($"Замеры произведены, результат сохранён по адресу: {Program.SavePath}. Для возврата в меню нажмите любую клавишу... ");
            Console.ReadKey();*/
        }

        public static Data RequestTheData(string name)
        {
            string[] input = Console.ReadLine().Split(" ");
            if (IsInputCorrect(input) == false) 
            {
                Console.WriteLine("Некоректный ввод, попробуйте снова");
                RequestTheData(name);
            }
            int variablesCount = Int32.Parse(input[0]);
            int steps = Int32.Parse(input[1]);
            int testsCount = Int32.Parse(input[2]);
            TimeMaesures timeMesures = new TimeMaesures();
            return timeMesures.MeasureTheTime(name, variablesCount, testsCount, steps, SavePath);
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

        public static void ChangeTheSavePath()
        {
            Console.Clear();
            Console.WriteLine("Введите новый путь для сохранения данных:");

            string newPath = Console.ReadLine();
            while(!IsCorrectPath(newPath))
            {
                Console.Clear();
                Console.WriteLine("Введённый путь не существует, введите заново:");
                newPath = Console.ReadLine();
            }

            SavePath = newPath;
        }

        private static bool IsCorrectPath(string input)
        {
            return Directory.Exists(input);

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

        