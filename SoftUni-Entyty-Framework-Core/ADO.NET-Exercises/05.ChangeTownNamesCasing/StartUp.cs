namespace ChangeTownNamesCasing
{
    using Microsoft.Data.SqlClient;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            string inputCity = Console.ReadLine();

            var updateTownsQuery = @"UPDATE Towns
                                     SET Name = UPPER(Name)
            WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

            var townNameQuery = @"SELECT t.Name 
                                 FROM Towns as t
                                 JOIN Countries AS c ON c.Id = t.CountryCode
                                WHERE c.Name = @countryName";

            int rowsAffected = UpdateTownToUpperCase(connection, inputCity, updateTownsQuery);
            SqlDataReader reader = PrintTowns(connection, inputCity, townNameQuery);
            CheckIfRowsAreAffected(rowsAffected, reader);
        }

        private static void CheckIfRowsAreAffected(int rowsAffected, SqlDataReader reader)
        {
            if (rowsAffected == 0)
            {
                Console.WriteLine("No town names were affected.");
            }
            else
            {
                var towns = new List<string>();

                Console.WriteLine($"{rowsAffected} town names were affected.");

                while (reader.Read())
                {
                    towns.Add((string)reader[0]);
                }

                Console.WriteLine($"[{string.Join(", ", towns)}]");
            }
        }

        private static SqlDataReader PrintTowns(SqlConnection connection, string inputCity, string townNameQuery)
        {
            using var sqlCommand = new SqlCommand(townNameQuery, connection);
            sqlCommand.Parameters.AddWithValue("@countryName", inputCity);
            using var reader = sqlCommand.ExecuteReader();

            return reader;
        }

        private static int UpdateTownToUpperCase(SqlConnection connection, string inputCity, string updateTownsQuery)
        {
            using var sqlCommand = new SqlCommand(updateTownsQuery, connection);
            sqlCommand.Parameters.AddWithValue("@countryName", inputCity);
            int rowsAffected = sqlCommand.ExecuteNonQuery();
            return rowsAffected;
        }
    }
}
