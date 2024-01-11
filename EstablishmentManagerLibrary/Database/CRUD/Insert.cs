using EstablishmentManagerLibrary.Client_related;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Insert
    {
        public static void Client(Client client)
        {
            string query = $"insert into [Client] " +
                $"([name], [cpf], [birthday], [rg], [creation_date]) " +
                $"values ('{client.Name}', '{client.Cpf}','{client.Birthday}', '{client.Rg}', '{client.Creation_date}, '{client.Modified_date}', '{client.Credit_on_establishment}', '{client.Debit_on_establishment}');";
            Query.Execute(query, Connection_string.String);
        }
    }
}
