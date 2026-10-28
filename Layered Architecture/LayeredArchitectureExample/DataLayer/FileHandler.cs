using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//import namespace
using System.IO;

namespace LayeredArchitectureExample.DataLayer
{
    internal class FileHandler
    {
        public FileHandler() { }

        public Boolean store(int sum)
        {
            File.WriteAllText("text.txt", sum.ToString());
            return true;
        }
    }
}
