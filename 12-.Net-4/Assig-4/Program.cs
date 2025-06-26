
namespace Assig_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            //Task 1
            HashSet<int> csharpScores = new HashSet<int> {70, 80, 90, 95, 96, 99, 99 };
            HashSet<int> htmlScores = new HashSet<int> { 75, 75, 81, 94, 96, 98, 99 };
            HashSet<int> reactScores = new HashSet<int> { 85, 88, 64, 76, 99, 100, 100 };

            Dictionary<string, HashSet<int>> courseScores = new Dictionary<string, HashSet<int>>
            {
                {"csharp", csharpScores},
                {"html", htmlScores},
                {"react", reactScores}
            };

            foreach(var courseScore in courseScores)
            {
                Console.WriteLine($"{courseScore.Key}, scores are {courseScore.Value}");
            }

        }
    }
}
