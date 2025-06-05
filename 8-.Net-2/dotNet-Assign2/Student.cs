using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_Assign2
{
    class Student
    {
        public int StudentId{ get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public List<int> EnrolledCourseId { get; set; }

        public Student(int studentId, string name, int age, List<int> enrolledCourseId)
        {
            this.StudentId = studentId;
            this.Name = name;
            this.Age = age;
            this.EnrolledCourseId = enrolledCourseId;
        }
    }
}
