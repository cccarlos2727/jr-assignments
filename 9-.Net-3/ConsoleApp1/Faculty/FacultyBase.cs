using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Faculty
{
    public abstract class FacultyBase
    {
        public List<string> Activities { get; set; } = new List<string> { };
        public List<string> Lectures { get; set; } = new List<string> { };

        public abstract void PlanLearningMethod();

        public virtual void DefineLearningObjectives()
        {
            Console.WriteLine("Define Learning Objectives plz");
        }

    }
}
