using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentApp2
{
    internal class Program
    {
        enum Menu
        {
            Add =1,
            Remove,
            Update,
            Display,
            Exit

        }

        static SortedList<string, string> studentDetails = new SortedList<string, string>();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Add a student.");
                Console.WriteLine("2. Remove a student.");
                Console.WriteLine("3. Update a student details.");
                Console.WriteLine("4. Display student report.");
                Console.WriteLine("5. Exit.");

                int userInput = int.Parse(Console.ReadLine());

                switch ((Menu)userInput)
                {
                    case Menu.Add:
                        Capture();
                        break;
                    case Menu.Remove:
                        Remove();
                        break;
                    case Menu.Update:
                        Update();
                        break;
                    case Menu.Display:
                        Display();
                        break;
                    case Menu.Exit:
                        return;
                    default:
                        Console.WriteLine("invalid Option!");
                        break;
                }
                Console.ReadKey();
            }
        }

        static int studentCount;

        static void Capture()
        {
            Console.Clear();
            // ask amount of students to add
            Console.WriteLine("How many students to add?: ");
            int numberToAdd = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberToAdd; i++)
            {
                // asign student number
                int studentNumber = studentCount+1;
                studentCount++;

                //get name and surname
                Console.WriteLine("Name: ");
                string fName = Console.ReadLine();

                Console.WriteLine("Surname: ");
                string lName = Console.ReadLine();

                Console.WriteLine("Average: ");
                string average = Console.ReadLine();

                string key = studentNumber.ToString();
                string values = String.Join("|", fName, lName, average);

                studentDetails.Add(key, values);

                Console.WriteLine("Success");
            }
        }

        static void Remove()
        {
            Console.WriteLine("Which student do you want to remove?");
            Console.Write("Enter student number: ");

            string studentNumber = Console.ReadLine();

            // if its a key in the list remove from list

            if (studentDetails.ContainsKey(studentNumber))
            {
                Console.WriteLine($"Student: {studentDetails[studentNumber].Replace('|', ',')} Removed!");
                studentDetails.Remove(studentNumber);

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void Update()
        {
            Console.Clear ();

            Console.WriteLine("Which student do you want to update?");
            Console.Write("Enter student number: ");

            string studentNumber = Console.ReadLine();

            if (studentDetails.ContainsKey(studentNumber))
            {
                // unpack details from list
                string details = studentDetails[studentNumber];
                string[] detail = details.Split('|');

                string fName, lName, average;

                fName = detail[0];
                lName = detail[1];
                average = detail[2];

                // which detail do you want to update?
                Console.WriteLine($"1. Name" +
                    $"\n2. Surname" +
                    $"\n3. Average");

                Console.WriteLine("Enter number only: ");

                int choice = int.Parse(Console.ReadLine());

                // if 
                Console.WriteLine("what do you want to update it to?");

                string updated = Console.ReadLine();
                studentDetails.Remove(studentNumber);

                if (choice == 1)
                {
                    Console.WriteLine($"Name updated from {fName} to {updated}!");
                    fName = updated;
                }
                else if (choice == 2)
                {
                    Console.WriteLine($"Surname updated from {lName} to {updated}!");
                    lName = updated;

                }
                else if (choice == 3)
                {
                    Console.WriteLine($"Average updated from {average} to {updated}!");
                    average = updated;
                }
                else
                {
                    Console.WriteLine("Invalid number.");
                }
                studentDetails.Add(studentNumber, String.Join("|", fName, lName, average));

            }
            else
            {
                Console.WriteLine("Not found!");
            }
        }

        static void Display()
        {
            Console.Clear();
            Console.WriteLine("Which student do you want a report for?");
            Console.Write("Enter student number: ");
            string studentNumber = Console.ReadLine();
            if (studentDetails.ContainsKey(studentNumber))
            {
                // upack details
                string details = studentDetails[studentNumber];
                string[] detail = details.Split('|');

                string fName, lName, average, standing;

                fName = detail[0];
                lName = detail[1];
                average = detail[2];

                if (Convert.ToInt32(average) > 50)
                {
                    standing = "PASS";
                }
                else
                {
                    standing = "FAIL";
                }

                Console.WriteLine($"Name: {fName} Surname: {lName}" +
                    $"\nStanding: {standing}");

            }
            else
            {
                Console.WriteLine("not found!");
            }
        }
    }
}
