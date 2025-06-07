using ConsoleApp1.Faculty;
using ConsoleApp1.Interface;
using ConsoleApp1.Staff;
using ConsoleApp1.Student;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Overload Method
            //Calculator.Add(3, 5);
            //Calculator.Add(3.3, 4.4);
            #endregion

            #region Faculty
            //Coding codingCourse = new Coding();
            //codingCourse.PlanLearningMethod();
            //codingCourse.DefineLearningObjectives();
            #endregion

            #region Creating Student List
            List<StudentBase> studentList = new List<StudentBase>();
            for(var i = 0; i < 10; i++)
            {
                studentList.Add(new StudentBase(i, "null"));                
            }
            #endregion

            #region Setting up DI
            var services = new ServiceCollection();
            services.AddTransient<INotify, Instructor>();
            services.AddTransient<Instructor>();

            services.AddTransient<IRefer, Professor>();
            services.AddTransient<Professor>();

            services.AddTransient<IAcess, Tutor>();
            services.AddTransient<Tutor>();

            var serviceProvider = services.BuildServiceProvider();
            var instructor = serviceProvider.GetRequiredService<Instructor>();
            var professor = serviceProvider.GetRequiredService<Professor>();
            var tutor = serviceProvider.GetRequiredService<Tutor>();
            #endregion

            #region Staff action
            instructor.Notification(studentList);
            tutor.AssessStudentGrade(studentList);                        
            professor.ReferTheJob(studentList);
            #endregion

        }
    }
}
