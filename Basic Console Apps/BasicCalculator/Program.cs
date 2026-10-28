using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the expression: ");
            string expression = Console.ReadLine();

            // create array of valid operators
            char[] chars = { '+', '-', '*', '/'};
            char myOperator = ' ';
            bool operatorFound = false;
            double answer = 0;


            foreach (char e in expression)
            {
                foreach (char c in chars)
                {
                    if (c == e)
                    {
                        myOperator = c;
                        operatorFound = true;
                        break;
                    }
                }
            }

            if (operatorFound == true)
            {
                string[] newExpression = expression.Split(myOperator);
                double left = double.Parse(newExpression[0]);
                double right = double.Parse(newExpression[1]);

                switch (myOperator)
                {
                    case '+':
                        answer = left + right;
                        break;
                    case '-':
                        answer = left - right;
                        break;
                    case '*':
                        answer = left * right;
                        break;
                    case '/':
                        answer = left / right;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Not a valid Expression!");
            }

            Console.WriteLine("The answer is {0}", answer);

            Console.ReadKey();
        }
    }
}
