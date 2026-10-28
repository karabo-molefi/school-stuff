using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // array
            int[] numbers = { 8, 6, 4, 1, 9, 12, 5, 7 };
            int n = numbers.Length;
            int temp;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0;  j < n - 1; j++)
                {
                    if (numbers[j] > numbers[j + 1])
                    {
                        temp = numbers[j];
                        numbers[j] = numbers[j + 1];
                        numbers[j + 1] = temp;
                    }
                }
            }

            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
        }
    }
}
