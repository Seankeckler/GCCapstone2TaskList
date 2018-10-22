using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCCapstone2TaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Task> Tasks = new List<Task>();
            string deleteTaskInput;
            string sure;
            
            bool quit = true;
            Console.WriteLine("Welcome to the List Manager \n");
            Console.WriteLine("Lets Add Your First Task");
            Task newTask = newTaskInfo();
            Tasks.Add(newTask);
            do
            {
                MainMenu();
                string answer;
                answer = Console.ReadLine();
                if (answer == "1")
                {
                    newTask = newTaskInfo();
                    Tasks.Add(newTask);
                    

                }
                else if (answer == "2")
                {
                    Console.WriteLine("Complete?" + "\t" +  "Name" + "\t" + "Date Due" + "\t" + "Description" );
                    foreach (Task task in Tasks)
                    {
                        Console.WriteLine(newTask.Complete + "\t \t"+ newTask.MemberName + " \t " + newTask.DueDate + "\t" + newTask.TaskDesc + "\n");
                        
                    }


                }
                else if (answer == "3")
                {
                    Console.WriteLine("Which do you want to delete?");
                    foreach (Task task in Tasks)
                    {
                        Console.WriteLine(Tasks.IndexOf(task) + 1 + ") " + newTask.MemberName + "\t" + newTask.DueDate + "\t" + newTask.TaskDesc + "\t"     +newTask.Complete + "\n");
                    }
                    deleteTaskInput = Console.ReadLine();

                    int.TryParse(deleteTaskInput, out int buhByeTask);
                    buhByeTask = buhByeTask - 1;
                    Console.WriteLine("Are you sure you want to delete that?");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "y")
                    {
                        DeleteIt(Tasks, buhByeTask);
                    }
                    else if (input.ToLower() == "n")
                    {
                        MainMenu();
                    }
                    else
                    {
                        Console.WriteLine("That is not an acceptable answer");
                    }
                    
                    
                }
                else if (answer == "4")
                {
                    Console.WriteLine("Which do you want to change completion status of ?");
                    foreach (Task task in Tasks)
                    {
                        Console.WriteLine(Tasks.IndexOf(task) + 1 + ") " + newTask.MemberName + "\t" + newTask.DueDate + "\t" + newTask.TaskDesc + "\t" + newTask.Complete + "\n");
                    }
                    string index = Console.ReadLine();
                    int.TryParse(index, out int Index);
                    
                    var selectedTask = Tasks[Index - 1];
                    
                    selectedTask.Complete = !selectedTask.Complete;
                    

                    
                }
                else if (answer == "5")
                {
                    Console.WriteLine("Are you sure? y/n ");
                    sure = Console.ReadLine();
                    quit = Quit(sure);
                }
                else
                {
                    Console.WriteLine("That was not one of the options...");
                    
                }

                Console.ReadKey();
            } while (quit == true);

    {

            }
        }

        static void MainMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("\t 1. Add a Task");
            Console.WriteLine("\t 2. List Tasks");
            Console.WriteLine("\t 3. Delete A Task");
            Console.WriteLine("\t 4. Mark Task Uncomplete/Complete");
            Console.WriteLine("\t 5. Quit");
            Console.Write("What would you like to do? : ");
        }

        

        // Takes in the information to add
        static Task newTaskInfo()
        {
            
            string name;
            string date;
            string desc;
            
            Console.WriteLine("Please enter Name, a Description, and a Due Date");
            Console.WriteLine("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Description: ");
            desc = Console.ReadLine();
            Console.WriteLine("Due Date: ");
            date = Console.ReadLine();
            DateTime enteredDate = validDate(date);
            string convertedDate = enteredDate.ToShortDateString();

            Task task = addTask(name, convertedDate, desc);
                return task;
        }   

        // converts the information to what the Task constructor needs
        static Task addTask(string name, string date, string desc)
        {
            Task newTask = new Task(name, desc, date);
            return newTask;
        }

        //Validates entered date for adding is an actual date
        static DateTime validDate(string isIt)
        {
            string[] dateFormats = new string[] { "MM/dd/yyyy","M/d/yy" };

            DateTime enteredDate;
            DateTime ThatAintATime = new DateTime();
            bool validDate = DateTime.TryParseExact(
            isIt,
            dateFormats,
            DateTimeFormatInfo.InvariantInfo,
            DateTimeStyles.None,
            out enteredDate);
            
            if (validDate)
            {
                    return enteredDate;
            }
            else
            {
                Console.WriteLine("thats not a valid date");
                return ThatAintATime;
            }
            

        }

        //quits the program
        static bool Quit (string input)
        {
            if (input.ToLower() == "y")
            {
                Console.WriteLine("Have a Great Day!");
                Console.ReadKey();
                return false;
            }
            else if (input.ToLower() == "n")
            {
                return true;
            }
            else
            {
                Console.WriteLine("That is not an acceptable answer");
                return true;
            }

        }
        //deletes the task at Index that has been chosen
        static void DeleteIt(List<Task> tasklist, int index)
        {
            if (index > tasklist.Count || index <= -1)
            {
                Console.WriteLine("that is not an acceptable number");
            }
            else
            {
                tasklist.RemoveAt(index);
            }
        }
      





    }
}
