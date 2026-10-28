using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandler
{
    internal class Program
    {
        // read text file and display in console
        string filepath = @"C:\Users\Karabo\OneDrive - belgiumcampus.ac.za\2026\PRG282\DAY3- File Handler\FileHandler\file.txt";

        // list of people from people class
        List<Person> people = new List<Person>();


        public void format(List<string> lst)
        {
            foreach (var line in lst)
            {
                string[] items = line.Split(',');
                Person p = new Person(items[0], items[1], items[2]);

                people.Add(p);
            }
        }

        public void print()
        {
            //output formatted
            Console.WriteLine("Formatted Data");
            Console.WriteLine("=======================================");

            foreach (Person p in people)
            {
                Console.WriteLine($"{p.id} {p.name} {p.title}");
            }

            Console.WriteLine("=======================================");
            Console.WriteLine();
            
        }

        public void write()
        {
            string outPath = "out.txt";

            List<string> outContents = new List<string>();

            foreach (Person p in people)
            {
                outContents.Add($"{p.id} {p.name} {p.title}");
            }

            File.WriteAllLines(outPath, outContents);
            Console.WriteLine("Written formatted data to {0} please check", outPath);

        }





        public List<string> read()
        {
            List<string> myList = new List<string>();

            myList = File.ReadAllLines(filepath).ToList();

            // loop through list to display to console
            Console.WriteLine("Original data in text file");
            Console.WriteLine("======================================");

            foreach (string line in myList)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("======================================");


            return myList;
        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            obj.format(obj.read());

            obj.print();

            obj.write();

            Console.ReadLine();
        }
    }
}
