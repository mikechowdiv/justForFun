using Data;
using Helpers;
using Models;
using System;

namespace Workflows
{
    public class AddWorkflow
    {
        public static StudentRepo studentRepository = new StudentRepo();

        public void Exe()
        {
            Console.Clear();
            Console.WriteLine("Add Student");
            Console.WriteLine(ConsoleIO.Bar);
            Console.WriteLine("");

            Student s1 = new Student();
            s1.FirstName = ConsoleIO.GetRequiredStringFromUser("First Name: ");
            s1.LastName = ConsoleIO.GetRequiredStringFromUser("Last Name: ");
            s1.Major = ConsoleIO.GetRequiredStringFromUser("Major: ");
            s1.GPA = ConsoleIO.GetRequiredDecmialFromUser("GPA: ");

            Console.WriteLine("");
            ConsoleIO.PrintHeader();
            Console.WriteLine(ConsoleIO.StudentLineFormat, s1.LastName + ", " + s1.FirstName, s1.Major, s1.GPA);

            Console.WriteLine("");
            if (ConsoleIO.GetYesNoFromUser("Add the following information (Y/N)") == "Y")
            {
                studentRepository.Add(s1);
                Console.WriteLine("Student added");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Action cancelled");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();
            }
        }
    }
}
