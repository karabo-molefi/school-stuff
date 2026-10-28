using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandlerClass
{
    internal class Person
    {
        string name {  get; set; }
        string surname { get; set; }
        string job {  get; set; }

        public Person(string name, string surname, string job)
        {
            this.name = name;
            this.surname = surname;
            this.job = job;
        }

        public override string ToString()
        {
            return $"First Name: {name} | Last Name: {surname} | Job: {job}";
        }
    }
}
