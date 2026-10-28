using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentApp
{
    internal class Program
    {
        enum Menu
        {
            Caputure = 1,
            DisplayAllStudents,
            Update,
            DisplaySummary,
            Exit
        }

        static List<string> studentDetails = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Capture Student Details.");
                Console.WriteLine("2. Display All Students.");
                Console.WriteLine("3. Update Student Details");
                Console.WriteLine("4. Display Summary");
                Console.WriteLine("5. Exit");

                int userInput = int.Parse(Console.ReadLine());

                switch ((Menu)userInput)
                {
                    case Menu.Caputure:
                        Capture();
                        break;
                    case Menu.DisplayAllStudents:
                        DisplayAllStudents();
                        break;
                    case Menu.DisplaySummary:
                        DisplaySummary();
                        break;
                    case Menu.Exit:
                        return;
                    default:
                        Console.WriteLine("Invalid please try again!");
                        break;

                }

                Console.ReadLine();

            }
        }

        static void Capture()
        {
            Console.Clear();
            Console.WriteLine("How many students do you want to capture?");
            
            int counter = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("Student Number: ");
                string studentNumber = Console.ReadLine();
           
                Console.WriteLine("First Name: ");
                string firstName = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                string lastName = Console.ReadLine();
                Console.WriteLine("Math mark: ");
                int mark1 = int.Parse(Console.ReadLine());
                Console.WriteLine("Physics mark: ");
                int mark2 = int.Parse(Console.ReadLine());
                Console.WriteLine("English mark");
                int mark3 = int.Parse(Console.ReadLine());

                int average = Calculate(mark1, mark2, mark3);


                string details = String.Join("|", studentNumber ,firstName, lastName, mark1, mark2, mark3, average.ToString());

                studentDetails.Add(details);

            }
        }

        static void DisplayAllStudents()
        {
            Console.Clear();

            // headings
            // loop through student details
            foreach (string s in studentDetails)
            {
                string[] details = s.Split('|');
                Console.WriteLine($"Student Number: {details[0]}, Name: {details[1]} Surname: {details[2]}.");
            }
            // print name surname and student number
        }

        static int  Calculate(int mark1, int mark2, int mark3)
        {

            return (mark1 + mark2 + mark3) / 3;

        }

        static void DisplaySummary()
        {
            Console.Clear();
            foreach (string student in studentDetails)
            {
                string[] details = student.Split('|');
                // write student number, name and surname
                Console.Write($"Student Number: {details[0]} Name: {details[1]} Surname: {details[2]} " +
                    $"\nMath mark: {details[3]} Physics mark: {details[4]} English mark: {details[5]} " +
                    $"\nAverage: {details[6]} Standing: ");

                // if they passed 
                if (Convert.ToInt32(details[6]) > 5)
                    Console.Write("PASS");
                else
                    Console.Write("FAIL");
            }
        }
    }
}
