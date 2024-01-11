using EstablishmentManagerLibrary.Client_related;
using EstablishmentManagerLibrary.Inventory;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Insert
    {
        public static void Client(Client client)
        {
            string query = $"insert into [Client] " +
                $"([name], [cpf], [birthday], [rg], [creation_date], [modified_date], [credit_on_establishment], [debit_on_establishment]) " +
                $"values ('{client.Name}', '{client.Cpf}','{client.Birthday}', '{client.Rg}', '{client.Creation_date}, '{client.Modified_date}', '{client.Credit_on_establishment}', '{client.Debit_on_establishment}');";
            QueryFunction.Execute(query, Database_query_strings.Master_connection_string);
        }

        public static void Client_Address(Client_address client_address)
        {
            string query = $"insert into [client_address] " +
                $"([street_name], [cep], [complement], [reference], [number], [description], [creation_date], [modified_date]) " +
                $"values ('{client_address.Street_name}', '{client_address.Cep}','{client_address.Complement}', '{client_address.Reference}', " +
                $"'{client_address.Number}, '{client_address.Description}', '{client_address.Creation_date}', '{client_address.Modified_date}');";
            QueryFunction.Execute(query, Database_query_strings.Master_connection_string);
        }

        public static void Client_Telephone(Client_telephone client_telephone)
        {
            string query = $"insert into [client_telephone] " +
                $"([number], [description], [creation_date], [modified_date]) " +
                $"values ('{client_telephone.Number}', '{client_telephone.Description}','{client_telephone.Creation_date}', '{client_telephone.Modified_date}');";
            QueryFunction.Execute(query, Database_query_strings.Master_connection_string);
        }
    }
}
