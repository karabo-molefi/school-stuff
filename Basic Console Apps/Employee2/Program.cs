using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Employee2
{
    internal class Program
    {
        enum Menu
        {
            CaptureDetails = 1,
            Sort,
            HighestSalary,
            LowestSalary,
            Search,
            Exit

        }

        // global list 
        static List<string> employeeDetails = new List<string>();
        static int numberOfEmployees;

        static void Main(string[] args)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("1. Capture Details");
                Console.WriteLine("2. Sort");
                Console.WriteLine("3. Display Highest salary.");
                Console.WriteLine("4. Display Lowest Salary.");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. Exit");
                Console.Write("\nEnter option (1-6): ");

                int userChoice = int.Parse(Console.ReadLine());

                switch((Menu)userChoice)
                {
                    case Menu.CaptureDetails:
                        Caputure();
                        break;
                    case Menu.Sort:
                        Sort();
                        break;
                    case Menu.HighestSalary:
                        break;
                    case Menu.LowestSalary:
                        break;
                    case Menu.Search:
                        Search();
                        break;
                    case Menu.Exit:
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }
            }
        }

        static void Caputure()
        {
            Console.Write("Enter Number of employees to add: ");

            // get number of employees to capture
            numberOfEmployees = int.Parse(Console.ReadLine());

            // loop for number of employees
            for (int i = 0; i < numberOfEmployees; i++)
            {
                Console.WriteLine($"Employee {i+1}:");
                // ask for name, add to employee details
                Console.Write("Name: ");
                employeeDetails.Add(Console.ReadLine());

                // ask for salary, add to employee dtails
                Console.Write("Salary: ");
                employeeDetails.Add(Console.ReadLine());

            }

            Console.ReadLine();
            Console.Clear();
        }

        static void Search()
        {
            // prompt for search term
            Console.Write("Enter name to search: ");
            string searchTerm = Console.ReadLine();


            // bool for existing employeee
            bool found = false;

            for ( int i = 0; i < employeeDetails.Count; i++)
            {
                if (searchTerm == employeeDetails[i])
                {
                    Console.WriteLine($"Name: {employeeDetails[i]}, Salary: {employeeDetails[i + 1]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not found.");
            }

            Console.WriteLine(employeeDetails[1].GetType());

            Console.ReadLine();
            Console.Clear();

        }

        static void Sort()
        {
            // get all numeric values
            Console.ReadKey();

        }
    }
}
