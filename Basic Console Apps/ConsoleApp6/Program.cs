using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Program
    {
        enum Menu
        {
            Add=1,
            Remove,
            Update,
            Search,
            Display,//displays student info grade and pass mark
            Exit
        }

        static Dictionary<string,(string name, string surname, double mark1, double mark2, double mark3, double average, string standing)> StudentDetails = new Dictionary<string, (string name, string surname, double mark1, double mark2, double mark3, double average, string standing)>();

        static string tableHead = $"{"Student Number",-15}| {"Name",-10}| {"Surname",-10}| {"Average (%)",-15} | {"Standing",-10}|" +
            $"\n----------------------------------------------------------------------";

        static void Main(string[] args)
        {
            // display menu
            //bool active = true;
            while (true)
            {
                Console.Clear();
                Console.WriteLine(
                    $"1. Add a student" +
                    $"\n2. Remove a student" +
                    $"\n3. Update student details" +
                    $"\n4. Search for a student" +
                    $"\n5. Display student reports" +
                    $"\n6. Exit"
                    );
                Console.Write("Choose an option (1-6): ");
                int userInput = int.Parse(Console.ReadLine() );

                switch ((Menu)userInput)
                {
                    case Menu.Add:
                        AddStudent();
                        break;
                    case Menu.Remove:
                        Remove();
                        break;
                    case Menu.Update:
                        Update();
                        break;
                    case Menu.Search:
                        DisplaySearchResult();
                        break;
                    case Menu.Display:
                        Display();
                        break;
                    case Menu.Exit:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }
        static void Update()
        {
            var (found, key) = Search();
            ArrayList values = new ArrayList();

            if (found)
            {
                // make a copy 
                foreach (var student in StudentDetails)
                {
                    if (student.Key == key)
                    {
                        values.Add(student.Key);
                        values.Add(student.Value.name);
                        values.Add(student.Value.surname);
                        values.Add(student.Value.mark1);
                        values.Add(student.Value.mark2);
                        values.Add(student.Value.mark3);
                    }
                }
                // ask which detail to change
                Console.WriteLine("Student Details: ");

                Console.WriteLine(tableHead);
                foreach (var student in StudentDetails)
                {
                    if (student.Key.Equals(key))
                    {
                        Console.WriteLine($"{student.Key,-15}| {student.Value.name,-10}| {student.Value.surname,-10}| {student.Value.average,-15}| {student.Value.standing,-10}|");
                    }
                }
                Console.WriteLine("\nWhich detail do you want to update?");

                Console.WriteLine(
                    $"1. Student Number" +
                    $"\n2. Name" +
                    $"\n3. Surname" +
                    $"\n4. Mark1" +
                    $"\n5. Mark2" +
                    $"\n6. Mark3"
                    );
                Console.Write("Enter number (1-6): ");
                int choice = int.Parse( Console.ReadLine() );
                Console.WriteLine("Replace to: ");
                string replacedTerm = Console.ReadLine();
                bool keyChanged = false;


                switch ( choice )
                {
                    case 1:
                        Console.WriteLine($"{values[0]} updated to {replacedTerm}");
                        values[0] = replacedTerm;
                        keyChanged = true;
                        break;
                    case 2:
                        Console.WriteLine($"{values[1]} updated to {replacedTerm}");
                        values[1] = replacedTerm;
                        break;
                    case 3:
                        Console.WriteLine($"{values[2]} updated to {replacedTerm}");
                        values[2] = replacedTerm;
                        break;
                    case 4:
                        Console.WriteLine($"{values[3]} updated to {double.Parse(replacedTerm)}");
                        values[3] = replacedTerm;
                        break;
                    case 5:
                        Console.WriteLine($"{values[4]} updated to {double.Parse(replacedTerm)}");
                        values[4] = replacedTerm;
                        break;
                    case 6:
                        Console.WriteLine($"{values[5]} updated to {double.Parse(replacedTerm)}");
                        values[5] = replacedTerm;
                        break;
                }

                StudentDetails.Remove(key);

                if (keyChanged)
                {
                    key = replacedTerm;
                }

                // remove 

                string name = Convert.ToString(values[1]);
                string surname = Convert.ToString(values[2]);
                double mark1 = Convert.ToDouble(values[3]);
                double mark2 = Convert.ToDouble(values[4]);
                double mark3 = Convert.ToDouble(values[5]);

                var (average, standing) = CalculateAverage(mark1, mark2, mark3);

                StudentDetails[key] = (name, surname, mark1, mark2, mark3, average, standing);

            }
            else
            {
                Console.WriteLine("Not found");
            }

        }
        static ValueTuple<bool, string> Search()
        {
            Console.Clear();
            Console.WriteLine("Enter name or student number: ");
            string searchTerm = Console.ReadLine();
            bool resultsFound = false;
            string key = "";
            // if student number serach keys
            if (StudentDetails.ContainsKey(searchTerm))
            {
                resultsFound = true;
                key = searchTerm;
            }

            // if search term is name
            foreach (var student in StudentDetails)
            {
                if (student.Value.name == searchTerm)
                {
                    resultsFound = true;
                    key = student.Key;
                }
            }

            return (resultsFound, key);

        }

        static void DisplaySearchResult()
        {
            var (found, key) = Search();

            if (found)
            {
                Console.WriteLine(tableHead);
                foreach (var student in StudentDetails)
                {
                    if (student.Key.Equals(key))
                    {
                        Console.WriteLine($"{student.Key,-15}| {student.Value.name,-10}| {student.Value.surname,-10}| {student.Value.average,-15}| {student.Value.standing,-10}|");
                    }
                }
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }
        static void Remove()
        {
            // search for person
            var (found, key) = Search();

            if (found)
            {
                StudentDetails.Remove(key);
                Console.WriteLine("Removed Successfully!");
            }
            else
            {
                Console.WriteLine("Not found");
            }
           
                
        }
        static void Display()
        {
            Console.Clear();
            Console.WriteLine(tableHead);
            // loop through dict
            foreach (var student in StudentDetails)
            {
                Console.WriteLine($"{student.Key, -15}| {student.Value.name,-10}| {student.Value.surname, -10}| {student.Value.average, -15}| {student.Value.standing, -10}|");
            }
        }


        static void AddStudent()
        {
            Console.Clear();
            // enter name and surname with a space
            string studentNumber = Convert.ToString(StudentDetails.Count + 1);
            Console.WriteLine("Pernsonal Details");
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();

            Console.WriteLine("Surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine("Marks");
            Console.WriteLine("PRG181:");
            double mark1 = double.Parse(Console.ReadLine());
            Console.WriteLine("PRG182:");
            double mark2 = double.Parse(Console.ReadLine());
            Console.WriteLine("PRG183:");
            double mark3 = double.Parse(Console.ReadLine());

            // calculate average
            var (average, standing) = CalculateAverage(mark1, mark2, mark3);

            StudentDetails[studentNumber] = (name, surname, mark1, mark2, mark3, average, standing);

            Console.WriteLine("Added Successfully!");
        }
        static ValueTuple<double, string> CalculateAverage(double mark1, double mark2, double mark3)
        {
            double average = (mark1 + mark2 + mark3) / 3;
            average = Math.Round(average, 2);
            string standing = (average > 50) ? "PASS" : "FAIL";
            return (average, standing);
        }

    }
}