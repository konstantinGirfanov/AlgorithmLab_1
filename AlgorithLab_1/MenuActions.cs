using System.Diagnostics;
using System.Runtime.ExceptionServices;

namespace AlgorithLab_1
{
    public class MenuActions
    {
        public static void MoveThrough(Menu menu)
        {
            List<string> algs = new();
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
                        if (menu.Items[menu.SelectedItemIndex].ClassFullName == "exit")
                            Environment.Exit(0);
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

                        if (menu.Items[menu.SelectedItemIndex].ClassFullName == "MenuActions.ChooseAlgs")
                        {
                            ChooseAlgs(menu, algs);
                        }

                        if (menu.Items[menu.SelectedItemIndex].ClassFullName != "Program.RunFewAlgs")
                        {
                            ConsoleHelper.ClearScreen();
                            
                            Data algData = Program.RequestTheData(menu.Items[menu.SelectedItemIndex].ClassFullName);
                            Drawer.Draw(menu.Items[menu.SelectedItemIndex].ClassFullName, Program.SavePath, new List<Data> { algData });

                            Console.WriteLine($"Замеры произведены, результат сохранён по адресу: {Program.SavePath}. Для возврата в меню нажмите любую клавишу... ");
                            Console.ReadKey();
                        }
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

        private static void ChooseAlgs(Menu menu, List<string> algs)
        {
            while (true)
            {
                ConsoleHelper.ClearScreen();
                Console.WriteLine("Выберите несколько алгоритмов:");
                ShowTheMenu(menu);
                ShowAlgs(algs);
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
                        if (menu.Items[menu.SelectedItemIndex].ClassFullName == "exit")
                        {
                            Environment.Exit(0);
                        }
                        if (menu.Items[menu.SelectedItemIndex].ClassFullName == "Program.RunFewAlgs")
                        {
                            Program.RunFewAlgs(algs);
                            algs.Clear();
                            break;
                        }
                        if(menu.Items[menu.SelectedItemIndex].ClassFullName != "path" &&
                            menu.Items[menu.SelectedItemIndex].ClassFullName != "MenuActions.ChooseAlgs")
                        {
                            if(!algs.Contains(menu.Items[menu.SelectedItemIndex].ClassFullName))
                                algs.Add(menu.Items[menu.SelectedItemIndex].ClassFullName);
                        }
                        break;
                }
            }
        }

        private static void ShowAlgs(List<string> algs)
        {
            foreach(string al in algs)
            {
                Console.Write(al + ", ");
            }
        }
    }
}
