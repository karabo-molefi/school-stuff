using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        enum Menu
        {
            CaputureDetails = 1,
            Sort,
            DisplayHighestSalary,
            DisplayLowestSalary,
            Search,
            Exit
        }
        // global variable
        static string[,] employeeDetails = new string[4, 2];



        static void Main(string[] args)
        {

            bool active = true;//bool to continue printing menu

            while (active)
            {
                Console.Clear();    
                Console.WriteLine("Menu");
                Console.WriteLine("1. Capture details");
                Console.WriteLine("2. Sort in Accending order");
                Console.WriteLine("3. Display highest salary");
                Console.WriteLine("4. Display lowest salary");
                Console.WriteLine("5. Search");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option (1-4): ");

                int choice = int.Parse(Console.ReadLine());
                
                switch ((Menu)choice)
                {
                    case Menu.CaputureDetails:
                        CaptureDetails();
                        break;
                    case Menu.Sort:
                        SortAscending();
                        break;
                    case Menu.DisplayHighestSalary:
                        DisplayHighest();
                        break;
                    case Menu.DisplayLowestSalary:
                        DisplayLowest();
                        break;
                    case Menu.Search:
                        Search();
                        break;
                    case Menu.Exit:
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        Console.ReadKey();
                        break;

                }
            }
        }

        static void CaptureDetails()
        {
          for (int i = 0; i < 4 ; i++)
            {
                //input name
                Console.Write("Name: ");
                employeeDetails[i, 0] = Console.ReadLine();

                Console.Write("Salary: ");
                employeeDetails[i, 1] = Console.ReadLine();
            }
          Console.ReadKey();
        }

        static void SortAscending()
        {
            if (employeeDetails[0,0] == null)
            {
                Console.WriteLine("Please Caputure details.");
                Console.ReadKey();
                return;
            }

            int[] sorted = new int[4];

            for (int i = 0;i < 4 ; i++)
            {
                sorted[i] = int.Parse(employeeDetails[i, 1]);
            }

            Array.Sort(sorted);

            // match to original array
            string[,] sortedArr = new string[4, 2];
     
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (sorted[i] == int.Parse(employeeDetails[j, 1]))
                    {
                        sortedArr[i, 0] = employeeDetails[j, 0];
                        sortedArr[i, 1] = sorted[i].ToString();
                    }
                }
            }

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Name: {sortedArr[i,0]}, Salary: R{sortedArr[i,1]}");
            }

            // make emplyee details the sorted array

            employeeDetails = sortedArr;

            Console.ReadKey();

        }

        static void DisplayHighest()
        {

            Console.WriteLine($"Highest earning is {employeeDetails[3,0]}, R{employeeDetails[3,1]}");
            Console.ReadKey();

        }

        static void DisplayLowest()
        {
            Console.WriteLine($"Lowest earning is {employeeDetails[0, 0]}, R{employeeDetails[0, 1]}");
            Console.ReadKey();
        }

        static void Search()
        {
            // get search term
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();
            bool found = false;
            // iterate over array 
            for (int i = 0; i < 4; i++)
            {
                if (name == employeeDetails[i, 0])
                {
                    Console.WriteLine($"Name: {employeeDetails[i, 0]}, Salary: {employeeDetails[i,1]}");
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("Not found.");
            }

            Console.ReadKey();
        }

    }
}
