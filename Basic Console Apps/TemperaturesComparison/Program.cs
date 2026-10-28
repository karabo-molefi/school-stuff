using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemperaturesComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = 5;
            // input five daily Fahrenheit temperatures that must range from −30 to 130

            Console.WriteLine("Input daily temperatures:");
            int temp = 0;
            int[] temperatures = new int[length];

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Day {i + 1}: ");
                temp = int.Parse(Console.ReadLine());

                while (temp < -31 || temp > 130)
                {
                    Console.WriteLine("Temperature out of bounds. Enter a temperature between -30 and 130.");
                    Console.Write($"Temperature {i + 1}: ");
                    temp = int.Parse(Console.ReadLine());
                }

                temperatures[i] = temp;
            }


            int[] sortedTemps = new int[length];
            int[] reversedTemps = new int[length];
            Array.Copy(temperatures, sortedTemps, length);
            Array.Sort(sortedTemps);
            Array.Copy(sortedTemps, reversedTemps, length);
            Array.Reverse(reversedTemps);
            bool condition = true;
            bool condition2 = true;
            
            Console.WriteLine(" ");
            Console.Write("Condition: ");

            // check for warmer 
            for (int i = 0; i < length; i++)
            {
                if (temperatures[i] != sortedTemps[i])
                {
                    condition = false;
                    break;
                }
                else
                {
                    condition = true;
                }
            }

            if (condition)
            {
                Console.WriteLine("Getting Warmer!");
            }
            else
            {
                for (int i = 0;i < length;i++)
                {
                    if (temperatures[i] != reversedTemps[i])
                    {
                        condition2 = false;
                        break;
                    }
                    else
                    {
                        condition2 = true;
                    }
                }

                if (condition2)
                {
                    Console.WriteLine("Getting Cooler!");
                }
                else
                {
                    Console.WriteLine("It's a mixed bag!");

                }
            }

            Console.WriteLine(" ");
            Console.Write("Temperatures: ");
            foreach (int t in temperatures)
            {
                Console.Write($"{t}, ");
            }

            int sum = 0;
            foreach (int t in temperatures)
            {
                sum += t;
            }
            int average = sum / length;

            Console.WriteLine(" ");
            Console.WriteLine($"Avaerage Temperature: {average}");

            Console.ReadKey();
        }
    }
}
