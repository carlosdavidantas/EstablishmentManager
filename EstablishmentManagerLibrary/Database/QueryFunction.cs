using System;
using System.Data.SqlClient;

namespace EstablishmentManagerLibrary.Database
{
    internal static class QueryFunction
    {
        internal static void Execute(string queryString, string stringConnection)
        {
            using (SqlConnection connectionString = new SqlConnection(stringConnection))
            using (SqlCommand myCommand = new SqlCommand(queryString, connectionString))
                try
                {
                    connectionString.Open();
                    myCommand.ExecuteNonQuery();
                    Console.WriteLine("Query was executed successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
        }
    }
}
