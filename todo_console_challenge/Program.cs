using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

//Create a.NET Core Console app that has the following
//actions available to it: Add<todo>, Print(top 3),
//PrintAll, and Done (with todo number). Just store the
//data in memory. No need to store it in a database.
//Add a method called ReOrder that moves a todo up
//or down in priority by the user identifying the new
//number it should be.

namespace todo_console_challenge
{
    internal class Program
    {
        private static List<string> todos = new List<string>();

        enum MenuActions
        {
            Add,
            Print,
            Done,
            Help,
            Exit,
            Clear,
            Swap
        }

        static void Main()
        {
            MenuActions menuActions = MenuActions.Help;
            string param = string.Empty;
            Console.WriteLine();

            do
            {
                Console.Write("What is your action? : ");
                string? fullAction = Console.ReadLine();
                (menuActions, param) = GetMenuAction(fullAction);

                switch (menuActions)
                {
                    case MenuActions.Add:
                        AddTodo(param);
                        break;
                    case MenuActions.Print:
                        PrintTodos(param);
                        break;
                    case MenuActions.Done:
                        MarkAsDone(param);
                        break;
                    case MenuActions.Help:
                        PrintHelp();
                        break;
                    case MenuActions.Exit:
                        break;
                    case MenuActions.Clear:
                        ClearConsole();
                        break;
                    case MenuActions.Swap:
                        SwapPositions(param);
                        break;
                    default:
                        break;
                }
                Console.WriteLine();
            }
            while (menuActions != MenuActions.Exit);
        }

        static void AddTodo(string todo)
        {
            string pattern = @"^[^\s][^\s]*(\s+[^\s]+)*$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(todo))
            {
                Console.WriteLine("Specified item name is not valid.");
                return;
            }

            todos.Add(todo);
            Console.WriteLine($"Successfully added {todo} to the list at position {todos.Count}.");
        }

        static void PrintTodos(string param)
        {
            if (param.Equals("All", StringComparison.OrdinalIgnoreCase))
            {
                for (int i = 0; i < todos.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] - {todos[i]}");
                }
                return;
            }

            if (int.TryParse(param, out int count))
            {
                for (int i = 0; i < count && i < todos.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] - {todos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Specify a number of todos to print.");
            }
        }

        static void PrintHelp()
        {
            Console.WriteLine("Allowed actions:");
            Console.WriteLine("[Add] [item name] - Adds an item to the list.");
            Console.WriteLine("[Print] [amount / All] - Prints the specified amount of todos / all todos.");
            Console.WriteLine("[Done] [item id] - Marks an item as done.");
            Console.WriteLine("[Help] - Get help.");
            Console.WriteLine("[Exit] - Exit the application.");
            Console.WriteLine("[Clear] - Clear the console.");
            Console.WriteLine("[Swap] [index1] [index2] - Swap positions of two todos.");
        }

        static void ClearConsole()
        {
            Console.Clear();
        }

        static void MarkAsDone(string param)
        {
            if (int.TryParse(param, out int index) && index > 0 && index <= todos.Count)
            {
                Console.WriteLine($"[{todos[index - 1]}] - Removed from todos.");
                todos.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid todo index.");
            }
        }

        static void SwapPositions(string parameters)
        {
            var paramSet = parameters.Split(' ');

            if (paramSet.Length == 2 && int.TryParse(paramSet[0], out int indexA) && int.TryParse(paramSet[1], out int indexB))
            {
                if (indexA > 0 && indexA <= todos.Count && indexB > 0 && indexB <= todos.Count)
                {
                    Swap(todos, indexA - 1, indexB - 1);
                    Console.WriteLine("Successfully swapped positions.");
                }
                else
                {
                    Console.WriteLine("Indexes are out of range.");
                }
            }
            else
            {
                Console.WriteLine("Invalid indexes specified.");
            }
        }

        static (MenuActions action, string param) GetMenuAction(string fullAction)
        {
            var splitAction = fullAction.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

            if (splitAction.Length == 0)
            {
                return (MenuActions.Help, string.Empty);
            }

            TextInfo info = CultureInfo.CurrentCulture.TextInfo;
            string actionStr = info.ToTitleCase(splitAction[0].ToLower());

            if (Enum.TryParse(actionStr, out MenuActions action))
            {
                string param = splitAction.Length > 1 ? splitAction[1] : string.Empty;
                return (action, param);
            }

            return (MenuActions.Help, string.Empty);
        }

        public static void Swap<T>(IList<T> list, int indexA, int indexB)
        {
            T tmp = list[indexA];
            list[indexA] = list[indexB];
            list[indexB] = tmp;
        }
    }
}
