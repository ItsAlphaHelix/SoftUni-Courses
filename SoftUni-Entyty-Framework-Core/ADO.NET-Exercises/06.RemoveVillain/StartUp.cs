namespace RemoveVillain
{
    using Microsoft.Data.SqlClient;
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(InitialSetup.Config.ConnectionString);

            connection.Open();

            int id = int.Parse(Console.ReadLine());

            string eveliName = "SELECT Name FROM Villains WHERE Id = @villainId";

            string deleteMinionsFromVillein = @"DELETE FROM MinionsVillains 
                                                    WHERE VillainId = @villainId";

            string deleteVilleins = @"DELETE FROM Villains
                                             WHERE Id = @villainId";


            var evilName = EvilName(connection, id, eveliName);
            DeleteVillein(connection, id, deleteVilleins);

            if (evilName == null)
            {
                Console.WriteLine("No such villain was found.");
                return;
            }

            Console.WriteLine($"{evilName} was deleted.");
            int countOfDeletetMinons = DeleteMinionsFromVillein(connection, id, deleteMinionsFromVillein);

            if (countOfDeletetMinons == 0)
            {
                Console.WriteLine($"{countOfDeletetMinons} minions were released.");
            }
        }

        private static void DeleteVillein(SqlConnection connection, int id, string deleteVilleins)
        {
            using var sqlCommand = new SqlCommand(deleteVilleins, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", id);
            sqlCommand.ExecuteNonQuery();
        }

        private static int DeleteMinionsFromVillein(SqlConnection connection, int id, string deleteMinionsFromVilleins)
        {
            using var sqlCommand = new SqlCommand(deleteMinionsFromVilleins, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", id);
            var count = sqlCommand.ExecuteNonQuery();

            return (int)count;
        }

        private static string EvilName(SqlConnection connection, int id, string nameOfVelleinQuery)
        {
            using var sqlCommand = new SqlCommand(nameOfVelleinQuery, connection);
            sqlCommand.Parameters.AddWithValue("@villainId", id);
            var reader = sqlCommand.ExecuteScalar();

            return (string)reader;
        }
    }
}