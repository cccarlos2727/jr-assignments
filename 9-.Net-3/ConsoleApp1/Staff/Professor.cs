using ConsoleApp1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Staff
{
    class Professor: IRefer
    {
        public void ReferTheJob(string grade)
        {
            if(grade == "A")
            {
                Console.WriteLine("Professor refer you a job.");
            }
        }
    }
}
