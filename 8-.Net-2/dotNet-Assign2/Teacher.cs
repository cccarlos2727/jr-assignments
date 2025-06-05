using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dotNet_Assign2.CourseModels;

namespace dotNet_Assign2
{
    class Teacher
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }
        public List<int> TeachingCoursesId { get; set; }

        public Teacher(int teacherId, string name, List<int> teachingCoursesId)
        {
            this.TeacherId = teacherId;
            this.Name = name;
            this.TeachingCoursesId = teachingCoursesId;
        }

        public static void PrintTeacherInfo(List<Teacher> teachers, List<Course> courses, List<Student> students)
        {
            foreach(var teacher in teachers)
            {
                Console.WriteLine($"Teacher: {teacher.Name}");
                foreach(var courseId in teacher.TeachingCoursesId)
                {
                    foreach(var course in courses)
                    {
                        if(course.CourseId == courseId)
                        {
                            Console.WriteLine($"Teaches Course {course.CourseName}");

                            foreach (var student in students)
                            {
                                if (student.EnrolledCourseId.Contains(courseId))
                                {
                                    Console.WriteLine($"Student {student.Name}, Age: {student.Age}");
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
