using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeCastingExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Create a variable that stores a character, ‘A’. 
             * Using implicit conversion, print the chat value as:.*/

            char letter = 'A';

            Console.WriteLine((int)letter);
            Console.WriteLine((long)letter);
            Console.WriteLine($"{(float)letter:F2}");
            Console.WriteLine($"{(double)letter:F2}");
            Console.ReadLine();
        }
    }
}
