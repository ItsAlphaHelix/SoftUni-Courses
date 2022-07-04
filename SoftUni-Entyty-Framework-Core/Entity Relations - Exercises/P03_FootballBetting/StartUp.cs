namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new FootballBettingContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
