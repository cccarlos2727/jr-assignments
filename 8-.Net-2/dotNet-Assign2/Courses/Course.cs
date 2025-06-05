using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_Assign2.CourseModels
{
    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int Credit { get; set; }

        public List<int>? StudentIdList { get; set; }
        public int CourseDuration { get; set; }

        //public Course()
        //{
        //    StudentIdList = new List<int>();
        //}

    }
}
