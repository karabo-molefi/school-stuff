using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamPractice
{
    internal class Program
    {
        enum Menu
        {
            S = 1,
            M,
            L,
            XL
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Menu:" +
                $"\n----------------" +
                $"\n1. Small   - R40" +
                $"\n2. Medium  - R59" +
                $"\n3. Large   - R89" +
                $"\n4. X-Large - R99");

            // string array
            string[,] prices = new string[4, 2] { { "SMALL", "49" }, { "MEDIUM", "59" }, { "LARGE", "89" }, { "XLARGE", "99" } };

            int numberOfPizza = 0;
            int cost = 0;

            while (true)
            {
                Console.WriteLine("Size (S/M/L/XL): ");
                string size = Console.ReadLine();
                size = size.ToUpper();
                //Console.WriteLine("Flavour: ");
                //string flavour = Console.ReadLine();

                for (int rows = 0; rows < 4; rows++)
                {
                    for (int column = 0; column < 2; column++)
                    {
                        if (size.Equals(prices[rows, 0]))
                        {
                            cost += Convert.ToInt32(prices[rows,1]);
                        }
                    }
                }
                

                Console.WriteLine($"Pizza added!" +
                    $"\nDo yo want to order another pizza? (y/n)");
                char choice = char.Parse(Console.ReadLine());

                if (choice == 'y')
                {
                    numberOfPizza++;
                    continue;
                }
                else
                {
                    Console.WriteLine("Order complete!");
                    break;
                }
            }
            // discount
            int discount = 0;

            if (numberOfPizza == 2)
            {
                discount = 10;
            }
            else if (numberOfPizza == 3)
            {
                discount = 15;
            }
            else if (numberOfPizza >= 4)
            {
                discount = 20;
            }

            // total and discount
            Console.WriteLine($"Subtotal: R{cost} ");
            int discountapplied = (discount / 100) * cost; 
            int total = cost - discountapplied;
            Console.WriteLine($"Discounts: -R{discountapplied} ");
            Console.WriteLine($"Total: R{total}");


        }
    }
}

