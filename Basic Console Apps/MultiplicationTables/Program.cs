using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get multiplier
            Console.Write("Enter the multiplier: ");
            int multiplier = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= 10; i++)
            {
                int ans = multiplier * i;
                Console.WriteLine($"{i}\t x\t {multiplier}\t =\t {ans}\t");
                Console.WriteLine();
            }
        }
    }
}
