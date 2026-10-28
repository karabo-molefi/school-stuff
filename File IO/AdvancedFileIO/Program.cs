using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdvancedFileIO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fileName;

            Console.WriteLine("Enter a filename >> ");

            fileName = Console.ReadLine();  

            if (File.Exists(fileName))
            {
                Console.WriteLine("File Exists");
                Console.WriteLine("File was created " + File.GetCreationTime(fileName));
                Console.WriteLine("File was last accessed " + File.GetLastAccessTime(fileName));
                Console.WriteLine("File was last written to " + File.GetLastWriteTime(fileName));
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            Console.ReadKey();

            // create folder
            string directoryName;
            string[] listOfFiles;

            // get user path
            Console.WriteLine("Enter folder path >>");
            directoryName = Console.ReadLine();
            Console.WriteLine();


            // check if folder existes
            if (Directory.Exists(directoryName))
            {
                Console.WriteLine("Folder Exists");
                Console.WriteLine("Folder had the following files: ");

                // get list of files
                listOfFiles = Directory.GetFiles(directoryName);

                foreach (var item in listOfFiles)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
