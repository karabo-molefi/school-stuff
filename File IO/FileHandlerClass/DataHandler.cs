using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandlerClass
{
    internal class DataHandler
    {
        List<Person> people = new List<Person>();

        // format file

        public List<Person> format(List<string> lst)
        {
            foreach (var line in lst)
            {
                string[] item = line.Split(',');
                Person p = new Person(item[0], item[1], item[2]);
                people.Add(p);
            }
            return people;
        }

        public void print()
        {
            Console.WriteLine("formatted Data");
            Console.WriteLine("=============================================");
            foreach (var p in people)
            {
                Console.WriteLine(p);
            }
            Console.WriteLine("=============================================");
            Console.WriteLine();
        }
    }
}
