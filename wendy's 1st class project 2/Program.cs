using System;
using System.Collections.Generic;

namespace wendy_s_1st_class_project_2
{
    class Program
    {
        static void Main(string[] args)
        {
           



            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            bool run = true;
            List<(string, int)> tasks = new List<(string, int)>(); //every task will have a string and the


            while (run)
            {
                Console.Clear();
                //Display header first
                Program.Header(tasks);

                //Main menu
                Program.Menu(tasks);

                //Footer
                Program.Footer();

                if (tasks.Count != 0)
                {
                    Program.DisplayTasks(tasks);
                }
                else if (tasks.Count > 20)
                {
                    Program.DisplayTasks(tasks);

                    //Need to complete 
                    int currentPage = 1;
                    int totalPages = tasks.Count / 20;

                    Console.WriteLine($"Page : {currentPage} out of {totalPages}");
                }

                ConsoleKey key = Console.ReadKey().Key;

                //delete later:
                if (key == ConsoleKey.Escape)
                {
                    run = false;
                }

                else
                {
                    Program.Menu(tasks, key);
                }
            }
        }
        
        static void Footer()
        {
            Console.WriteLine("\n\nChoose from the following: Press 1 - Add, 2 - Complete task");
            Console.WriteLine("###########################################################\n\n");
        }

        static void Header(List<(string, int)> tasks)
        {
            Console.WriteLine("###########################################################\n");
            Console.WriteLine("\t\tWelcome to Task tracker\n");
            Console.WriteLine($"\t\tCurrent tasks: {tasks.Count}");
        }

        static void Menu(List<(string, int)> tasks, ConsoleKey action = 0, int page = 1)
        {
            if (action == ConsoleKey.D1)
            {
                Add(tasks);
            }

            else if (action == ConsoleKey.D2)
            {
                //complete method Complete() 
                Console.WriteLine("Complete");
            }
            else
            {
                // nothing
            }

        }
        static List<(string, int)> Add(List<(string, int)> tasks)
        {
            List<(string, int)> updatedList = tasks;

            Console.Clear();

            Console.WriteLine("###########################################################\n");
            Console.WriteLine("\t\tEnter a task\n");

            string toDo = "";
            while (toDo == "")
            {
                Console.WriteLine("Task cannot be empty");
                toDo = Console.ReadLine();
            }

            tasks.Add((toDo, 0));
            return updatedList;
        }

        static void DisplayTasks(List<(string, int)> tasks)
        {
            Console.WriteLine("Current tasks:");
            int count = 1;

            foreach ((string, int) task in tasks)//passed thar
            {

                Console.WriteLine($"{count}. {task.Item1}");
                count++;
                if (count == 20)
                    break;
            }
        }
    }
}
