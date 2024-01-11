using System;
using System.Data.SqlClient;
using EstablishmentManagerLibrary.Client_related;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public  class Select
    {
        
        public static Client Client(string id)
        {
            string query = $"select * from [Client] where [id] = '{id}';";
            Client client = new Client();

            using (SqlConnection connection = new SqlConnection(Database_query_strings.Establishment_connection_string))
            using (SqlCommand myCommand = new SqlCommand(query, connection))
            {
                connection.Open();
                using (SqlDataReader reader = myCommand.ExecuteReader())
                {
                    try
                    {
                        while (reader.Read())
                        {
                            client.Id = reader[0].ToString();
                            client.Name = reader[1].ToString();
                            client.Cpf = reader[2].ToString();
                            client.Birthday = DateTime.Parse(reader[3].ToString());
                            client.Rg = reader[4].ToString();
                            client.Creation_date = DateTime.Parse(reader[5].ToString());
                            client.Modified_date = DateTime.Parse(reader[6].ToString());
                            client.Credit_on_establishment = decimal.Parse(reader[7].ToString());
                            client.Debit_on_establishment = decimal.Parse(reader[8].ToString());
                        }
                        Console.WriteLine("Query executed successfully!");
                    }
                    catch (Exception EX)
                    {
                        Console.WriteLine(EX);
                    }
                    if (client.Name == null)
                    {
                        return null;
                    }
                    return client;
                }
            }
            
        }

    }
}
