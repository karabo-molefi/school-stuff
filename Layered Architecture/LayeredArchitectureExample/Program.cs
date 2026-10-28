using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import namespaces
using LayeredArchitectureExample.PresentationLayer;
using LayeredArchitectureExample.BusinessLogicLayer;
using LayeredArchitectureExample.DataLayer;


namespace LayeredArchitectureExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UserInput pl = new UserInput(); // Presentation Layer Object

                Logic bl = new Logic(); // Logic Layer object
                int sum = bl.Calculate(pl.GetFirstInput(), pl.GetSecondInput());

                FileHandler dl = new FileHandler(); // Data Layer object

                Boolean output = dl.store(sum);

                pl.DisplaySum(output);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ");
            }
            Console.ReadLine();
        }
    }
}
