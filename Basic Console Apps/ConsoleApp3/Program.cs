using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        enum Menu
        {
            Add_Student = 1,
            Display_StudentMark,
            Delete_Student,
            Exit
        }

        public static void AddStudent(List<List<string>> allStudents)
        {

            List<string> newStudent = new List<string>();// list for 1 student

            Console.Write("\nStudent number: ");
            string studentNumber = Console.ReadLine();
            newStudent.Add(studentNumber);

            Console.Write("Name: ");
            string name = Console.ReadLine();
            newStudent.Add(name);

            Console.Write("PRG181 mark: ");
            string mark1 = Console.ReadLine();
            newStudent.Add(mark1);

            Console.Write("MAT181 mark: ");
            string mark2 = Console.ReadLine();
            newStudent.Add(mark2);

            Console.Write("LPR181 mark: ");
            string mark3 = Console.ReadLine();
            newStudent.Add(mark3);

            // calculate averages 
            int average =  (int.Parse(mark1) + int.Parse(mark2) + int.Parse(mark3) / 3);

            newStudent.Add(average.ToString());

            // add pass/fail to list
            string standing;

            if (average < 50)
            {
                standing = "Fail";
            }
            else
            {
                standing = "Pass";
            }

            newStudent.Add(standing);

            allStudents.Add(newStudent); // add to list of lists

            Console.WriteLine("\nStudent added successfully!\n");
        }

        public static void DeleteStudent(List<List<string>> AllStudents)
        {
            // display all students
            Console.WriteLine("\nList of Students:");
            Console.WriteLine("--------------");

            foreach (List<string> student in AllStudents)
            {
                string studentNumber = student[0];
                string name = student[1];
                int counter = AllStudents.IndexOf(student) + 1;
                Console.WriteLine($"{counter}. {name} ({studentNumber})");
            }
            int numberOfStudents = AllStudents.Count;
            Console.WriteLine($"Enter number of student to delete (1-{numberOfStudents}): ");

            int choice = int.Parse(Console.ReadLine()) - 1;

            foreach (List<string> student in AllStudents.ToList())
            {
                if (choice == AllStudents.IndexOf(student))
                {
                    AllStudents.RemoveAt(choice);
                }
            }

            Console.WriteLine("Removed Student Successfully!");

            Console.WriteLine("Remaining Students: ");
            Console.WriteLine("--------------");

            foreach (List<string> student in AllStudents)
            {
                string studentNumber = student[0];
                string name = student[1];
                int counter = AllStudents.IndexOf(student) + 1;
                Console.WriteLine($"{counter}. {name} ({studentNumber})");
            }
        }


        public static void DisplayStudentMarks(List<List<string>> students)
        {
            //foreach( var student in students)
            //{
            //   for ( int i = 0; i < student.Count; i++ )
            //    {
            //        Console.WriteLine($"Student number: {student[0]} \tStanding: {student[6]}");
            //        break;
            //    }
            //}

            foreach (List<string> student in students)
            {
                string studentNumber = student[0];
                string name = student[1];
                string mark1 = $"PRG182: {student[2]}";
                string mark2 = $"MAT181: {student[3]}";
                string mark3 = $"LPR181: {student[4]}";
                string average = $"Average: {student[5]}";
                string standing = $"Standing: {student[6].ToUpper()}";

                Console.WriteLine($"\n{name} ({studentNumber})");
                Console.WriteLine("--------------");
                Console.WriteLine($"Marks: {mark1}, {mark2}, {mark3}");
                Console.WriteLine($"{standing}\n");
            }
        }

        static void Main(string[] args)
        {
            List<List<string>> allStudents = new List<List<string>>
            {
                new List<string> { "S001", "Alice", "80", "85", "90", "80", "pass" },
                new List<string> { "S002", "Bob", "75", "70", "78", "90", "pass" },
                new List<string> { "S003", "Charlie", "8", "12", "25", "22", "fail" }
            }; // list of lists for all students

            bool active = true;
            while (active)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("===========================");
                Console.WriteLine($"1: Add a student.");
                Console.WriteLine($"2: Display Student Marks.");
                Console.WriteLine($"3: Delete a student.");
                Console.WriteLine($"4: Exit");
                Console.Write("Please select a menu option (1-4): ");

                int userInput = int.Parse(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        AddStudent(allStudents);
                        break;
                    case 2:
                        DisplayStudentMarks(allStudents);
                        break;
                    case 3:
                        DeleteStudent(allStudents);
                        break;
                    case 4:
                        Console.WriteLine("\nExiting..");
                        active = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            Console.ReadKey();
        }
        
    }
}
