using Helpers;
using System;
using Workflows;

namespace StudentMgtSystem
{
    public class MainMenu
    {
        private static void Display()
        {
            Console.Clear();
            Console.WriteLine(ConsoleIO.Bar);
            Console.WriteLine("1. List Students");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Update student info");
            Console.WriteLine("4. Remove student");
            Console.WriteLine("");
            Console.WriteLine("Q to quit");
            Console.WriteLine("");
            Console.WriteLine("Enter choice");
        }

        private static bool Process()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ListWorkflow lwf = new ListWorkflow();
                    lwf.Exe();
                    break;
                case "2":
                    AddWorkflow awf = new AddWorkflow();
                    awf.Exe();
                    break;
                case "3":
                    UpdateWorkflow uwf = new UpdateWorkflow();
                    uwf.Exe();
                    break;
                case "4":
                    DeleteWorkflow dwf = new DeleteWorkflow();
                    dwf.Exe();
                    break;
                case "Q":
                    return false;
                default:
                    Console.WriteLine("This is not a valid choice.  Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
            return true;
        }

        public static void Show()
        {
            bool keepRun = true;
            while (keepRun)
            {
                Display();
                keepRun = Process();
            }
        }
    }
}
