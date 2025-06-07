using ConsoleApp1.Interface;
using ConsoleApp1.Faculty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Student;

namespace ConsoleApp1.Staff
{
    public class Professor: FacultyBase, IRefer
    {
        public void ReferTheJob(List<StudentBase> students)
        {
            foreach(var student in students)
            {
                if(student.Grade == "A")
                {
                    Console.WriteLine("Professor refer you a job.");
                } else
                {
                    Console.WriteLine("You got nothing from Professor");
                }
            }            
        }

        public override void PlanLearningMethod()
        {
            Console.WriteLine("Learning in a professor way");
        }

        public override void DefineLearningObjectives()
        {
            Console.WriteLine("Professor defineing learning objectives");
        }

    }
}
