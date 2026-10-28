using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // get account number
            Console.Write("Enter the account number: ");
            string accountNumber = Console.ReadLine();

            if (accountNumber.Length != 4)
            {
                Console.WriteLine("Invalid account number!");
                return;
            }
            
            char lastDigit = accountNumber[3];

            string firstThree = accountNumber.Remove(3);

            int firstThreeNums = Convert.ToInt32(firstThree);

            // mod by 7
            int remainder = firstThreeNums % 7;
            int last = int.Parse(lastDigit.ToString());

            if (last == remainder)
            {
                Console.WriteLine("valid");
            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.ReadKey();


        }

    }
}
