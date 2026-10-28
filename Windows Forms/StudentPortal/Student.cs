using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortal
{
    internal class Student
    {
        string courseID {  get; set; }
        string name {  get; set; }
        int studentID { get; set; }
        string surname {  get; set; }

        public Student(string courseID, string name, int studentID, string surname)
        {
            this.courseID = courseID;
            this.name = name;
            this.studentID = studentID;
            this.surname = surname;
        }

    }
}
