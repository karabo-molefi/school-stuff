using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaShop
{
    internal class Program
    {
        enum Menu
        {
            S=1,
            M,
            L,
            XL
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Pizza Size: \tPrices:");

            string[,] pizzaPrices = new string[4, 2];
            pizzaPrices[0, 0] = ("S");
            pizzaPrices[1, 0] =("M");
            pizzaPrices[2, 0]=("L");
            pizzaPrices[3, 0]=("XL");

            pizzaPrices[0, 1] = ("R40");
            pizzaPrices[1, 1] = ("R59");
            pizzaPrices[2, 1] = ("R89");
            pizzaPrices[3, 1] = ("R99");

            for (int row = 0; row < pizzaPrices.GetLength(0); row++)
            {
                for (int col = 0; col < pizzaPrices.GetLength(1); col++)
                {
                    string mystring = pizzaPrices[row, col];
                    Console.WriteLine(mystring);

                }
                Console.WriteLine();
            }

        }
    }
}
