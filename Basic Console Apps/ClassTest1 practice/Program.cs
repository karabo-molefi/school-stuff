using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassTest1_practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1;
            num1 = 50;

            double num2 = (double)num1;

            short num3;

            num3 = Convert.ToInt16(num1);

            Console.WriteLine($"{num1}, {num2}, {num3}");

            int num4;

            string number = Console.ReadLine();

            num4 = Convert.ToInt32(number);

            Console.WriteLine(num4);

            double num5 = Convert.ToDouble($"{number:2}");

            Console.WriteLine(num5);
        }
    }
}
