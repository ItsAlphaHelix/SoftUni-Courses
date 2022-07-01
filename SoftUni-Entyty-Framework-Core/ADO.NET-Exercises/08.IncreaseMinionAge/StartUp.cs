namespace IncreaseMinionAge
{
    using Microsoft.Data.SqlClient;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            string[] ids = Console.ReadLine()
                .Split(' ');

            string updateMinionsQuery = @"UPDATE Minions
          SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
        WHERE Id = @Id";

            string selectMinionsQuery = "SELECT Name, Age FROM Minions";

            for (int i = 0; i < ids.Length; i++)
            {
                int id = int.Parse(ids[i]);
                IncreaseMinionsAges(connection, updateMinionsQuery, id);
            }

            PrintNamesAndAgesOfMinions(connection, selectMinionsQuery);
        }

        private static void PrintNamesAndAgesOfMinions(SqlConnection connection, string selectMinionsQuery)
        {
            var sqlCommand = new SqlCommand(selectMinionsQuery, connection);
           using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} ${reader[1]}");
            }
        }

        private static void IncreaseMinionsAges(SqlConnection connection, string selectQuery, int id)
        {
            using var sqlCommand = new SqlCommand(selectQuery, connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
        }
    }
}