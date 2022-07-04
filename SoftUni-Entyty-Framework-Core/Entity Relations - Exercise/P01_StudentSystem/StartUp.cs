namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();
            db.Database.EnsureCreated();
        }
    }
}
