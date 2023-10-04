using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace AlgorithLab_1
{
    public class MenuActions
    {
        public static void MoveThrough(Menu menu)
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                ShowTheMenu(menu);
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.DownArrow:
                        if (menu.SelectedItemIndex == menu.Items.Count - 1)
                            menu.SelectedItemIndex = 0;
                        else
                            menu.SelectedItemIndex++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (menu.SelectedItemIndex == 0)
                            menu.SelectedItemIndex = menu.Items.Count - 1;
                        else
                            menu.SelectedItemIndex--;
                        break;
                    case ConsoleKey.Enter:
                        if (menu.Items[menu.SelectedItemIndex].ClassFullName == "exit") Environment.Exit(0);
                        if(menu.Items[menu.SelectedItemIndex].ClassFullName == "path")
                        {
                            Program.ChangeTheSavePath();
                            foreach(MenuItem item in menu.Items)
                            {
                                if(item.ClassFullName == "path")
                                {
                                    item.Caption = $"Change save path (Current path: {Program.SavePath})";
                                }
                            }
                            break;
                        }
                        ConsoleHelper.ClearScreen();
                        Console.WriteLine("Введите максимальный размер входных данных, шаг и количество проверок(через одиночные пробелы)");
                        Program.RequestTheData(menu.Items[menu.SelectedItemIndex].ClassFullName);
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowTheMenu(Menu menu)
        {
            if (menu.Items.Count > 0)
            {
                for (int i = 0; i < menu.Items.Count; i++)
                {
                    if (i == menu.SelectedItemIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(menu.Items[i].Caption);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.WriteLine(menu.Items[i].Caption);
                    }
                }
            }
        }
    }
}
