using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem
{
    [Author("Mitacheto")]
    public class StartUp
    {
        [Author("Konq vihur")]
         static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            tracker.PrintMethodsByAuthor();
        }
    }
}
