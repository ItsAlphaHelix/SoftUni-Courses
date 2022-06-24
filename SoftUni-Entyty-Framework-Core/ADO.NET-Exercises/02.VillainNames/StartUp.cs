namespace VillainNames
{
    using Microsoft.Data.SqlClient;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            string query = @"SELECT Name, COUNT(mv.MinionId)
                               FROM Villains AS v
                               JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                               GROUP BY v.Id, v.Name
                               HAVING COUNT(mv.MinionId) > 3";

            using SqlCommand commnad = new SqlCommand(query, connection);

            using SqlDataReader reader = commnad.ExecuteReader();

            while (reader.Read())
            {
                var name = reader[0];
                var count = reader[1];

                Console.WriteLine($"{name} - {count}");
            }
        }
    }
}