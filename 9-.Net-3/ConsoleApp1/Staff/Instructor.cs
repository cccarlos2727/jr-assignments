using ConsoleApp1.Faculty;
using ConsoleApp1.Interface;
using ConsoleApp1.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Staff
{
    class Instructor:FacultyBase, INotify
    {
        public void Notification(List<StudentBase> students)
        {
            foreach(var student in students)
            {
                if(student.StudentId % 2 == 0)
                {
                    Console.WriteLine("You dont hv to go to class today.");
                }
                else
                {
                    Console.WriteLine("Plz go to class today.");
                }
            }
        }

        public override void PlanLearningMethod()
        {
            Console.WriteLine("Learning in a instructor way");
        }

        public void DefineLearningObjectives()
        {
            Console.WriteLine("Professor defineing learning objectives");
        }
    }
}
