using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Student
{
    public class StudentBase
    {
        public int StudentId { get; set; }
        public string Grade { get; set; }

        public StudentBase(int studentId, string grade)
        {
            StudentId = studentId;
           Grade = grade;
        }

        public override string ToString()
        {
            return $"StudentId: {StudentId}, Grade: {Grade}";
        }

    }
}
