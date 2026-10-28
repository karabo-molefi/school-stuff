using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// import namespaces
using LayeredArchitectureExample.BusinessLogicLayer;
using LayeredArchitectureExample.DataLayer;

namespace LayeredArchitectureExample.PresentationLayer
{
    internal class UserInput
    {
        int num1, num2;

        public UserInput() { }

        public UserInput(int a, int b)
        {
            this.num1 = a; this.num2 = b;
        }

        public int GetFirstInput()
        {
            Console.WriteLine("Enter first number: ");
            this.num1 = int.Parse(Console.ReadLine());
            return this.num1;
        }

        public int GetSecondInput()
        {
            Console.WriteLine("Enter second number: ");
            this.num2 = int.Parse(Console.ReadLine());
            return this.num2;
        }

        public void DisplaySum(Boolean output)
        {
            if (output)
            {
                Console.WriteLine("Please check file in bin folder with sum");
            }
            else
            {
                Console.WriteLine("Could not calculate and write to file");
            }
        }
    }
}
