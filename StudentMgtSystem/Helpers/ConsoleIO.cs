using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Helpers
{
    public class ConsoleIO
    {
        public const string Bar = "-----------------------------------------------------";

        public const string StudentLineFormat = "{0,-20}{1,-15}{2,5}";
        public const string PickStudentLineFormat = "{0,2}{1,-20}{2,-15}{3,5}";

        public static void PrintHeader()
        {
            Console.WriteLine(Bar);
            Console.WriteLine(StudentLineFormat, "Name","Major","GPA");
            Console.WriteLine(Bar);
        }

        public static void PrintPickList(List<Student> studentList)
        {
            Console.WriteLine(Bar);
            Console.WriteLine(PickStudentLineFormat," ","Name","Major","GPA");
            Console.WriteLine(Bar);
            for (int i = 0; i < studentList.Count(); i++)
            {
                Console.WriteLine(PickStudentLineFormat, studentList[i].StudentId + " ", studentList[i].LastName + " ," + studentList[i].FirstName,studentList[i].Major,studentList[i].GPA);
            }
            Console.WriteLine();
            Console.WriteLine(Bar);
        }

        public static string GetRequiredStringFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter valid text");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    return input;
                }
            }
        }

        public static decimal GetRequiredDecmialFromUser(string prompt)
        {
            decimal output;
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();

                if (!decimal.TryParse(input,out output))
                {
                    Console.WriteLine("You must enter valid decimal");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (output < 0 || output > 4)
                    {
                        Console.WriteLine("GPA must be between 0 and 4");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        continue;
                    }
                    return output;
                }
            }
        }

        public static string GetYesNoFromUser(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("You must enter Y/N");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    if (input != "Y" && input != "N")
                    {
                        Console.WriteLine("You must enter Y/N");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                    return input;
                }
            }
        }
    }
}
