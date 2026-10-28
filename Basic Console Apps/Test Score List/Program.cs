using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Score_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;

            // accepts eight int values representing student test scores.
            int[] testScores = new int[8];

            Console.WriteLine("Enter the test scores: ");

            for (int i = 0; i < testScores.Length; i++)
            {
                Console.Write($"Score {i + 1}: ");
                int score = int.Parse(Console.ReadLine());
                testScores[i] = score;
            }

            // calculate sum
            foreach (int score in testScores)
            {
                sum += score;
                
            }

            // caluculate average
            int average = sum/ testScores.Length;

            Console.WriteLine($"The average is: {average.ToString()}%");

            // Display each of the values along with a message that indicates how far it is from the average.

            foreach (int score in testScores)
            {
                int difference = average - score;
                if (difference < 0)
                {
                    difference *= -1;
                    Console.WriteLine($"Score: {score} is {difference}% \tabove from the average.");
                }
                else if (difference == average){
                    Console.WriteLine($"Score: {score} is equal to the average.");

                }
                else
                {
                    Console.WriteLine($"Score: {score} is {difference}% \tbelow from the average.");
                }

            }

            Console.ReadKey();
        }
    }
}
