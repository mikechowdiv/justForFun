using Data;
using Helpers;
using Models;
using System;
using System.Collections.Generic;

namespace Workflows
{
    public class DeleteWorkflow
    {
        public static StudentRepo studentRepository = new StudentRepo();

        public void Exe()
        {
            Console.Clear();

            Console.WriteLine("Remove Student");

            List<Student> s1 = studentRepository.GetAll();
            ConsoleIO.PrintPickList(s1);
            Console.WriteLine(ConsoleIO.Bar);
            Console.WriteLine("Select ID to remove");

            int id = Convert.ToInt32(Console.ReadLine());

            string input = ConsoleIO.GetYesNoFromUser($"Please confirm to remove(Y/N)");
            if (input == "Y")
            {
                studentRepository.Delete(id);
                Student removedStudent = studentRepository.GetById(3);
                Console.WriteLine("student removed");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Remove cancelled");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
