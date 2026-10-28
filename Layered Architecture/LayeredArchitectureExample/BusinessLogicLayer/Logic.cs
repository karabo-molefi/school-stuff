using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import DataLayer namespace
using LayeredArchitectureExample.DataLayer;

namespace LayeredArchitectureExample.BusinessLogicLayer
{
    internal class Logic
    {
        public int Calculate(int a, int b)
        {
            int sum = a + b;
            FileHandler db = new FileHandler();

            Boolean result = db.store(sum);
            if (result)
            {
                return sum;
            }
            else
            {
                return 0;
            }
        }
    }
}
