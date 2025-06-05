using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet_Assign2.CourseModels
{
    class CourseReact : Course
    {
        public CourseReact(int CourseId, string CourseName, int Credit, List<int> StudentIdList, int CourseDuration)
        {
            this.CourseId = CourseId;
            this.CourseName = CourseName;
            this.Credit = Credit;
            this.StudentIdList = StudentIdList;
            this.CourseDuration = CourseDuration;
        }

    }
}
