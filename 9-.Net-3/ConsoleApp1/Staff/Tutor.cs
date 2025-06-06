using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Staff
{
    class Tutor: IAcess
    {
        public void AssessStudentGrade()
        {
            Console.WriteLine("Instructor assign you a grade.");
        }
    }
}
