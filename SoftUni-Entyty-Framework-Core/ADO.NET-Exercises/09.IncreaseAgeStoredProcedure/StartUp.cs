namespace IncreaseAgeStoredProcedure
{
    using Microsoft.Data.SqlClient;
    using System.Data;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            int id = int.Parse(Console.ReadLine());

            string storedProcedureQuery = "usp_GetOlder";

            string minionsSelectQuery = "SELECT Name, Age FROM Minions WHERE Id = @Id";

            UsingStoredProcedure(connection, id, storedProcedureQuery);
            PrintNameAndAgeOfMinion(connection, id, minionsSelectQuery);
        }

        private static void UsingStoredProcedure(SqlConnection connection, int id, string storedProcedureQuery)
        {
            var sqlCommand = new SqlCommand(storedProcedureQuery, connection);

            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Id", id);
            sqlCommand.ExecuteNonQuery();
        }

        private static void PrintNameAndAgeOfMinion(SqlConnection connection, int id, string minionsSelectQuery)
        {
            using var sqlCommand = new SqlCommand(minionsSelectQuery, connection);
            sqlCommand.Parameters.AddWithValue("@Id", id);
            using var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader[0]} – {reader[1]} years old");
            }
        }
    }
}