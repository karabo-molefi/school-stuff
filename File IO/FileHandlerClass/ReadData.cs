using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandlerClass
{
    internal class ReadData
    {
        public string filepath = @"C:\Users\Karabo\OneDrive - belgiumcampus.ac.za\2026\PRG282\DAY3- File Handler\FileHandlerClass\info.txt";

        public List<string> read()
        {
            List<string> mylist = new List<string>();

            mylist = File.ReadAllLines(filepath).ToList();
            Console.WriteLine("=====================================");

            foreach (string line in mylist)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("=====================================");
            return mylist;
        }
    }
}
