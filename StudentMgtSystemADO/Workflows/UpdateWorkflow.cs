using Data;
using Helpers;
using Models;
using System;
using System.Collections.Generic;

namespace Workflows
{
    public class UpdateWorkflow
    {
        public static StudentRepo studentRepository = new StudentRepo();

        public void Exe()
        {
            Console.Clear();
            Console.WriteLine("Edit Student information: ");
            Console.WriteLine(ConsoleIO.Bar);

            List<Student> students = studentRepository.GetAll();
            Console.WriteLine("Student List: ");
            ConsoleIO.PrintPickList(students);
            Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("What Id do you want to update? ");
            //Console.ReadLine();

            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("1. First Name");
            Console.WriteLine("2. Last Name");
            Console.WriteLine("3. Major");
            Console.WriteLine("4. GPA");
            int ch = Convert.ToInt32(Console.ReadLine());
            Student s1 = studentRepository.GetById(id);
            //String Name = null;

            switch (ch)
            {
                case 1:
                    Console.WriteLine("First Name: ");
                    string fname = Console.ReadLine();
                    s1.FirstName = fname;
                    //Name = "FirstName";
                    studentRepository.Update(s1);
                    GetID(id);
                    break;
                case 2:
                    Console.WriteLine("Last Name: ");
                    string lname = Console.ReadLine();
                    s1.LastName = lname;
                    //Name = "LastName";
                    studentRepository.Update(s1);
                    GetID(id);
                    break;
                case 3:
                    Console.WriteLine("Major");
                    string major = Console.ReadLine();
                    s1.Major = major;
                    //Name = "Major";
                    studentRepository.Update(s1);
                    GetID(id);
                    break;
                case 4:
                    Console.WriteLine("GPA");
                    decimal gpa = decimal.Parse(Console.ReadLine());
                    s1.GPA = gpa;
                    //Name = "GPA";
                    studentRepository.Update(s1);
                    GetID(id);
                    break;


                default:
                    Console.WriteLine("Please select a choice");
                    break;
            }
        }

        public void GetID(int id)
        {
            Console.WriteLine(ConsoleIO.Bar);
            Student s1 = studentRepository.GetById(id);
            if (s1 != null)
            {
                Console.WriteLine(s1.StudentId + " " + s1.FirstName + " " + s1.LastName + " " + s1.Major + " " + s1.GPA);
            }
        }
    }
}
