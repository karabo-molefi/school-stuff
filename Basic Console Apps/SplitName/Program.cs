using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter name and surname: ");
            string nameSurname = Console.ReadLine();
            string result = ""; 

            for (int i = 0; i < nameSurname.Length; i++)
            {
                if (i > 0 && char.IsUpper(nameSurname[i]))
                {
                    result += " ";
                }
                result += nameSurname[i];
            }

            Console.WriteLine(result);


            Console.WriteLine("Enter name and surname: ");
            //string nameSurname = Console.ReadLine();
            string[] results = new string[2];

            for(int i = 0; i < nameSurname.Length; i++)
            {
                if(i > 0 && char.IsUpper(nameSurname[i]))
                {
                    results = nameSurname.Split(nameSurname[i]);
                    string capital = Convert.ToString(nameSurname[i]);
                    results[1] =  capital += results[1];
                }
            }

            Console.WriteLine($"{results[0]} {results[1]}");
        }
    }
}
