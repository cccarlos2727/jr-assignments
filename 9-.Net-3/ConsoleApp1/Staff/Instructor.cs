using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Staff
{
    class Instructor: INotify
    {
        public void Notification()
        {
            Console.WriteLine("Instructor notify you to come to class");
        }
    }
}
