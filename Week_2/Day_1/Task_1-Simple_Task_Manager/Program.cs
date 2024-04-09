using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using task_component;

namespace MainProgram
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Using object initializers to create objects
            List<Tasks> TaskManager = [
                new (){Name = "Day-1", Description = "Meditate for 1 hour", Category = TaskCategory.personal},
                new (){Name = "Day-2", Description = "Finish development phase tasks", Category = TaskCategory.work},
                new (){Name = "Day-3", Description = "Hit the gym at 9:00pm", Category = TaskCategory.gym, IsCompleted = false}
            ];

            char inputChoice = 'a';

            Console.WriteLine("Hey there! Welcome to this simple console app to manage and track your day-to-day tasks");
            Console.WriteLine("Select any of the options below to begin right away:\n");

            do
            {
                Console.WriteLine("0 - Add task to Task Manager");
                Console.WriteLine("1 - Update task in Task Manager");
                Console.WriteLine("2 - Filter tasks by category");
                Console.WriteLine("3 - View all tasks");
                Console.WriteLine("4 - Import tasks from csv file");
                Console.WriteLine("5 - Export/store tasks to csv file\n");

                int ans = ReadNumber("Please enter your choice - ", 0, 5);

                switch (ans)
                {
                    case 0:
                        Console.WriteLine("Please enter name of task, description, category of task (Personal, Work, Meetings, Gym, or Learning) with spaces between:");
                        string[] input = Console.ReadLine().Split();

                        if (input.Length != 3 || !Enum.TryParse(input[2].ToLower(), out TaskCategory category))
                        {
                            Console.WriteLine("Invalid input. User entered an invalid input.");
                        }
                        else
                        {
                            Tasks task = new() { Name = input[0], Description = input[1], Category = category };
                            AddTask(ref TaskManager, task);
                        }
                        break;

                    case 1:
                        Console.WriteLine("Please enter name of task to be updated, the field to be updated and the new value with spaces between:");
                        string[] inp = Console.ReadLine().Split();
                        UpdateTasks(ref TaskManager, inp[0], inp[1], inp[2]);
                        break;

                    case 2:
                        Console.Write("Enter category name: ");
                        string cat = Console.ReadLine();
                        if (!Enum.TryParse(cat, out TaskCategory categ))
                        {
                            Console.WriteLine("Invalid category");
                        }
                        else
                        {
                            DisplayTasks(TaskManager, categ);
                        }
                        break;

                    case 3:
                        DisplayTasks(TaskManager);
                        break;

                    case 4:
                        Console.Write("Enter csv file name (make sure it is available in current directory): ");
                        string path = Console.ReadLine();
                        TaskManager = await ReadFromCSV(path);
                        break;

                    case 5:
                        Console.WriteLine("Outputting entire tasks in Task Manager into csv file (output.csv)...");
                        await StoreInCSV(TaskManager);
                        break;
                }

                Console.Write("\nPress 'q' To Exit App or Any Key To Continue... ");
                inputChoice = (char)Console.Read();
                Console.WriteLine();

            } while (inputChoice != 'q');
        }

        public static void AddTask(ref List<Tasks> task_manager, Tasks task)
        {
            task_manager.Add(task);
            Console.WriteLine("Task successfully added.");
        }

        public static void DisplayTasks(List<Tasks> tasks, TaskCategory? category = null)
        {
            Console.WriteLine("\nList of tasks available.\n-----------------------\n");
            int complete = 0;
            int incomplete = 0;

            var ResultSearch = tasks.Where((t) => category == null | category == t.Category);

            foreach (Tasks task in ResultSearch)
            {
                Console.WriteLine($"Name: {task.Name}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Category: {task.Category}");
                Console.WriteLine($"Completion Status: {task.IsCompleted}\n");

                if (!task.IsCompleted)
                    incomplete++;
                else
                    complete++;
            }

            Console.WriteLine($"Total tasks: {complete + incomplete} | Completed: {complete} | Incomplete: {incomplete}");
        }

        public static void UpdateTasks(ref List<Tasks> tasks, string name, string editChoice, string value)
        {
            int pos = -1;
            int idx = -1;

            while (idx < tasks.Count)
            {
                if (tasks[idx].Name == name)
                {
                    pos = idx;
                    break;
                }
                else
                {
                    idx++;
                }
            }

            if (pos == -1)
            {
                Console.WriteLine("Task not found in manager.");
            }
            else
            {
                Tasks tsk = tasks[pos];
                string choice = editChoice.ToLower();
                if (choice == "name")
                {
                    tsk.Name = value;
                }
                else if (choice == "description")
                {
                    tsk.Description = value;
                }
                else if (choice == "category")
                {
                    if (!Enum.TryParse(value, out TaskCategory category))
                    {
                        Console.WriteLine("Error: Invalid update");
                        return;
                    }
                    else
                    {
                        tsk.Category = category;
                    }
                }
                else if (choice == "iscompleted")
                {
                    tsk.IsCompleted = Convert.ToBoolean(value);
                }
                else
                {
                    Console.WriteLine("No such field available.");
                    return;
                }

                Console.WriteLine("Task updated successfully\n");
            }
        }

        public static async Task StoreInCSV(List<Tasks> tasks)
        {
            using StreamWriter file = new("output.csv");
            string separator = ",";

            foreach (Tasks task in tasks)
            {
                // Array to store record to be written to file
                string?[] newLine = [task.Name, task.Description, task.Category.ToString(), task.IsCompleted.ToString()];
                // Write to file, the new line, followed by a line terminator asynchronously
                await file.WriteLineAsync(string.Join(separator, newLine));
            }

            // Flush any buffered data to the file asynchronously
            await file.FlushAsync();
            Console.WriteLine("Tasks successfully stored in csv file named output.csv");
        }

        public static async Task<List<Tasks>> ReadFromCSV(string name)
        {
            List<Tasks> Results = [];

            try
            {
                using StreamReader reader = new(@name);
                while (!reader.EndOfStream)
                {
                    string? line = await reader.ReadLineAsync() ?? "";
                    string[] entry = line.Split(",");

                    if (entry.Length != 4 || !Enum.TryParse(entry[2], out TaskCategory category))
                    {
                        continue;
                    }
                    Tasks newTask = new() { Name = entry[0], Description = entry[1], Category = category };
                    Results.Add(newTask);
                }

                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found!\n");
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred while accessing the file: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
            finally
            {
                Console.WriteLine($"\nFile reading finished and closed...\n");
            }

            return Results;
        }

        // Function to handle reading of input integers
        public static int ReadNumber(string msg, int lower, int upper)
        {
            int res = 0;
            string? val = "";
            bool start = false;

            do
            {
                if (start)
                    Console.WriteLine($"\nPlease enter a number between {lower} and {upper} inclusive!\n");

                Console.Write(msg);
                val = Console.ReadLine();
                start = true;
            } while (!int.TryParse(val, out res) || res < lower || res > upper); // if input is not an integer or is out of bounds, ask for input again

            return res;
        }
    }
}