namespace PrintAllMinionNames
{
    using Microsoft.Data.SqlClient;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            string minionsQuery = "SELECT Name FROM Minions";

            using var sqlCommand = new SqlCommand(minionsQuery, connection);
            using var reader = sqlCommand.ExecuteReader();

            var minions = new List<string>();

            while (reader.Read())
            {
                minions.Add((string)reader[0]);
            }

            int counter = 0;

            for (int i = 0; i < minions.Count / 2; i++)
            {
                Console.WriteLine(minions[0 + counter]);
                Console.WriteLine(minions[minions.Count - 1 - counter]);
                counter++;
            }

            if(minions.Count % 2 != 0)
            {
                Console.WriteLine(minions[minions.Count / 2]);
            }
        }
    }
}