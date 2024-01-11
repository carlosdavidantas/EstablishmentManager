using EstablishmentManagerLibrary.Client_related;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Edit
    {
        public static void Client(string id, Client client)
        {
            string queryString = $"update [Client] set [name] = '{client.Name}', [cpf] = '{client.Cpf}'," +
                $" [birthday] = '{client.Birthday}', [rg] = '{client.Rg}', [modified_date] = '{client.Modified_date}'," +
                $" [credit_on_establishment] = '{client.Credit_on_establishment}', [debit_on_establishment] = '{client.Debit_on_establishment}'" +
                $" where [id] = '{id}';";

            QueryFunction.Execute(queryString, Database_query_strings.Establishment_connection_string);
        }
    }
}
