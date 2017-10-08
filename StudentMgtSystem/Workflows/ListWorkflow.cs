using Data;
using Helpers;
using Models;
using System;
using System.Collections.Generic;

namespace Workflows
{
    public class ListWorkflow
    {
        public static StudentRepo studentRepository = new StudentRepo();

        public void Exe()
        {
            List<Student> students = studentRepository.GetAll();

            Console.Clear();
            Console.WriteLine("Student List: ");
            ConsoleIO.PrintHeader();
            foreach (var items in students)
            {
                Console.WriteLine(ConsoleIO.StudentLineFormat, items.LastName + ", " +items.FirstName,items.Major,items.GPA);
            }
            Console.WriteLine();
            Console.WriteLine(ConsoleIO.Bar);
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
