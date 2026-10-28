using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileHandlerClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadData myReader = new ReadData();
            DataHandler myHandler = new DataHandler();

            List<Person> newList = new List<Person>();
            newList = myHandler.format(myReader.read());

            Thread.Sleep(3000);
            myHandler.print();

            FileHandler writer = new FileHandler();
            Thread.Sleep(3000);
            writer.write(newList);

            Console.ReadLine();
        }
    }
}
