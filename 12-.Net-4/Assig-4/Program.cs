
namespace Assig_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //Task 1
            HashSet<int> csharpScores = new HashSet<int> {70, 80, 90, 95, 96, 99};
            HashSet<int> htmlScores = new HashSet<int> { 75, 81, 94, 96, 98, 99 };
            HashSet<int> reactScores = new HashSet<int> { 85, 88, 64, 76, 99, 100};

            Dictionary<string, HashSet<int>> courseScores = new Dictionary<string, HashSet<int>>
            {
                {"csharp", csharpScores},
                {"html", htmlScores},
                {"react", reactScores}
            };

            //foreach(var courseScore in courseScores)
            //{
            //    Console.WriteLine($"{courseScore.Key}, scores are {courseScore.Value}");
            //}

            //Task 2
            Dictionary<string, int> studentCourseScores = new Dictionary<string, int>();
            studentCourseScores.Add("Carlos C#", 80);
            studentCourseScores.Add("Alice C#", 60);
            studentCourseScores.Add("David C#", 79);

            //Duplicated Key pair can not be added to Dictionary
            try
            {
                studentCourseScores.Add("Carlos C#", 80);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Duplicated Key can not exist in Dictionary");
            }

            foreach(var studentScore in studentCourseScores)
            {
                Console.WriteLine($"Student name: {studentScore.Key}, Score: {studentScore.Value}");
            }

            //Task 3


        }
    }
}
