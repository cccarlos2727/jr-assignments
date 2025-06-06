using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Faculty
{
    public class Coding: Faculty
    {
        public override void PlanLearningMethod()
        {
            Console.WriteLine("This was an abstract method, now i have added logic for it");
        }

        public override void DefineLearningObjectives()
        {
            base.DefineLearningObjectives();
        }

    }
}
