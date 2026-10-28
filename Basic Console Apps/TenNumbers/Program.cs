using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = 10;
            int[] numbers = new int[length];

            Console.WriteLine("Enter 10 numbers:");

            for (int i = 0; i < length; i++)
            {
                Console.Write("no {0}: ", i+1);
                numbers[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < length; i++)
            {
                for (int j = 0;  j < length-1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Sorted list: ");
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            // Reverse 
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length - 1; j++)
                {
                    if (numbers[j] < numbers[j + 1])
                    {
                        int temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Reversed: ");
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // smallest 
            Console.WriteLine("Smallest: ");
            Console.Write(numbers[length - 1]);
            Console.WriteLine();

            // largest
            Console.WriteLine("Largest: ");
            Console.Write(numbers[0]);

            Console.ReadKey();
        }
    }
}
