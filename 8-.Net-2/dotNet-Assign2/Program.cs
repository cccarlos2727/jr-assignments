using dotNet_Assign2.CourseModels;

namespace dotNet_Assign2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region CourseId: C#:1, Html: 2, React: 3
            List<int> cSharpStuList = new List<int> { 1, 2, 3 };
            CourseCsharp courseCsharp = new CourseCsharp(1, "CourseCsharp", 3, cSharpStuList, 2);

            List<int> htmlStuList = new List<int> { 4,5,6 };
            CourseHTML courseHtml = new CourseHTML(2, "CourseHtml", 3, htmlStuList, 3);

            List<int> reactStuList = new List<int> { 7,8,9,10 };
            CourseReact courseReact = new CourseReact(3, "CourseReact", 3, reactStuList, 4);

            List<Course> coursesList = new List<Course> { courseCsharp, courseHtml, courseReact};            
            #endregion

            #region TeacherId: Carlos: 1, DD: 2, Kevin: 3
            List<int> teachingCourseCarlos = new List<int> { 1 };
            Teacher teacherCarlos = new Teacher(1, "Carlos", teachingCourseCarlos);

            List<int> teachingCourseDD = new List<int> { 2 };
            Teacher teacherDD = new Teacher(2, "DD", new List<int> { 2});

            List<int> teachingCourseKevin = new List<int> { 3 };
            Teacher teacherKevin = new Teacher(3, "Kevin", teachingCourseKevin);

            List<Teacher> teacherList = new List<Teacher> { teacherCarlos, teacherDD, teacherKevin };
            #endregion

            #region Student info
            Student studentPeter = new Student(1, "Peter", 18, new List<int> { 1, 2, 3 });
            Student studentAmy = new Student(2, "Amy", 19, new List<int> { 1, 3 });
            Student studentBen = new Student(3, "Ben", 20, new List<int> { 2 });
            Student studentClara = new Student(4, "Clara", 21, new List<int> { 1 });
            Student studentDavid = new Student(5, "David", 22, new List<int> { 2, 3 });
            Student studentElla = new Student(6, "Ella", 20, new List<int> { 3 });
            Student studentFinn = new Student(7, "Finn", 19, new List<int> { 1, 2 });
            Student studentGrace = new Student(8, "Grace", 21, new List<int> { 1, 2, 3 });
            Student studentHenry = new Student(9, "Henry", 23, new List<int> { 2 });
            Student studentIvy = new Student(10, "Ivy", 18, new List<int> { 3 });

            List<Student> studentList = new List<Student> { studentAmy, studentBen, studentClara, studentDavid, studentElla, studentFinn, studentGrace, studentGrace, studentHenry, studentIvy };
            #endregion

            Teacher.PrintTeacherInfo(teacherList, coursesList, studentList);





        }
    }
}
