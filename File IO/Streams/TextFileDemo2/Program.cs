using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextFileDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string FileDir = @"C:\Users\Karabo\OneDrive - belgiumcampus.ac.za\2026\PRG282\DAY1 - Advanced File IO\Streams\demoFile.txt";

            List<string> TextLines = new List<string>();

            TextLines = File.ReadAllLines(FileDir).ToList();

            foreach (string line in TextLines)
            {
                Console.WriteLine(line);
            }
            TextLines.Add("AquaLad, MCU");
            File.WriteAllLines(FileDir, TextLines);
            Console.ReadLine();

        }
    }
}
