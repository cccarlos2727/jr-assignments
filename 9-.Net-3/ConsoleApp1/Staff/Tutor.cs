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
    class Tutor: FacultyBase, IAcess
    {
        public void AssessStudentGrade(List<StudentBase> students)
        {
            foreach(var student in students)
            {
                if(student.StudentId % 2 == 0)
                {
                    student.Grade = "A";
                } else
                {
                    student.Grade = "B";
                }
            }
        }

        public override void PlanLearningMethod()
        {
            Console.WriteLine("Learning in a Tutor way");
        }

        public override void DefineLearningObjectives()
        {
            Console.WriteLine("Tutor defineing learning objectives");
        }
    }
}
