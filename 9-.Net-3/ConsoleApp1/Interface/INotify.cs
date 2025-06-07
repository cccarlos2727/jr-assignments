using ConsoleApp1.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interface
{
    interface INotify
    {
        public void Notification(List<StudentBase> students);
    }
}
