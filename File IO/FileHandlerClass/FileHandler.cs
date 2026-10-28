using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandlerClass
{
    internal class FileHandler
    {
        public void write(List<Person> pList)
        {
            string outPath = @"C:\Users\Karabo\OneDrive - belgiumcampus.ac.za\2026\PRG282\DAY3- File Handler\FileHandlerClass\out.txt";

            List<string> outContents = new List<string>();

            foreach (Person p in pList)
            {
                outContents.Add(p.ToString());
            }

            File.WriteAllLines(outPath, outContents);
            Console.WriteLine("Written formatted data. Check {0}.", outPath);
        }
    }
}
