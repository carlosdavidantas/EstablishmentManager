using System;
using System.Data.SqlClient;
using EstablishmentManagerLibrary.Client_related;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public  class Select
    {
        //This method translate the client info from the database to the Client class.
        private static Client ClientMethod(string query)
        {
            Client ClientFound = new Client();

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
                            ClientFound.Id = reader[0].ToString();
                            ClientFound.Name = reader[1].ToString();
                            ClientFound.Cpf = reader[2].ToString();
                            ClientFound.Birthday = DateTime.Parse(reader[3].ToString());
                            ClientFound.Rg = reader[4].ToString();
                            ClientFound.Creation_date = DateTime.Parse(reader[5].ToString());
                            ClientFound.Modified_date = DateTime.Parse(reader[6].ToString());
                            ClientFound.Credit_on_establishment = decimal.Parse(reader[7].ToString());
                            ClientFound.Debit_on_establishment = decimal.Parse(reader[8].ToString());
                        }
                        Console.WriteLine("Query executed successfully!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    if (ClientFound.Name == null)
                    {
                        return null;
                    }
                    return ClientFound;
                }
            }
        }

        public static Client Client(string id)
        {
            string query = $"select * from [Client] where [id] = '{id}';";
            return ClientMethod(query);
        }
        
        public static Client Client(Client client)
        {
            string query = $"select * from [Client] where [name] = '{client.Name}' and [cpf] = '{client.Cpf}' and [birthday] = '{client.Birthday}' and" +
                $" [rg] = '{client.Rg}' and [modified_date] = '{client.Modified_date}' and [creation_date] = '{client.Creation_date}' and" +
                $" [credit_on_establishment] = '{client.Credit_on_establishment}' and [debit_on_establishment] = '{client.Debit_on_establishment}';";
            return ClientMethod(query);

        }

    }
}
