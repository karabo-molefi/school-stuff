using ADO.NET;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ADO_NET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler handler = new DataHandler();
            handler.getNumberofCategories();

            Console.ReadLine();
        }
    }
}
