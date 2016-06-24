using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummerSchool
{
    class Program
    {
        static string[] Students = new string[15];
        static int[] Tuitions = new int[15];

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the student enrollment system. Please choose from the following list of options...");

                PrintMenu();

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    EnrollStudent();
                }
                else if (choice == 2)
                {
                    UnenrollStudent();
                }
                else if (choice == 3)
                {
                    PrintStudents();
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {  
                    Console.WriteLine("Please enter a number 1-4");
                }
            }

            Console.ReadKey();
        }

        private static void PrintMenu()
        {
            Console.WriteLine();
            if (CountStudents() < Students.Length)
            {
                Console.WriteLine("1. Enroll a student");
            }
            if (CountStudents() > 0)
            {
                Console.WriteLine("2. Unenroll a student");
            }
            Console.WriteLine("3. Print out the list of enrolled students");
            Console.WriteLine("4. Exit");
        }

        private static void UnenrollStudent()
        {
            PrintStudents();

            Console.WriteLine("Which student would you like to unenroll?");

            int studentNumber = Convert.ToInt32(Console.ReadLine());

            int studentIndex = studentNumber - 1;

            Console.WriteLine("{0} has been unenrolled.", Students[studentIndex]);
 
            Students[studentIndex] = null;

        }

        static int GetNextAvailableSpot()
        {
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] == null)
                { 
                    return i;
                }
            }
            return -1;
        }

        static int CountStudents()
        {
            int counter = 0;
            for (int i = 0; i < Students.Length; i++)
            {
                if (Students[i] != null)
                {
                    counter++;
                }
            }
            return counter;
        }

        static void EnrollStudent()
        {
            Console.WriteLine("What's the name of the student to enroll?");
            string student = Console.ReadLine();

            string[] splitNames = student.Split(' ');

            string firstName = splitNames[0];
            string lastName = splitNames[splitNames.Length - 1];

            if (lastName.ToLower() == "malfoy")
            {
                Console.WriteLine("Malfoys may not be admitted!");
                return;
            }
            if (student.ToLower().Contains("tom") ||
                student.ToLower().Contains("riddle") ||
                student.ToLower().Contains("voldemort"))
            {
                Console.WriteLine("RED ALERT!!! HE WHO MUST NOT BE NAMED!!!");
            }

            
            int spot = GetNextAvailableSpot();

            Students[spot] = student;

            Console.WriteLine("{0} is now enrolled and will need to pay £{1}.",
                              student, CalculateEnrollmentCost(student));
        }


       
