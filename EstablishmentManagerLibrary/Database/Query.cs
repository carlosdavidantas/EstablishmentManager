using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Database
{
    internal static class Query
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
