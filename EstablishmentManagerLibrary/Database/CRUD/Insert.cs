using EstablishmentManagerLibrary.Client_related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Insert
    {
        public static void Client(Client client)
        {
            string query = $"insert into [Client] " +
                $"([name], [cpf], [birthday], [rg], [creation_date]) " +
                $"values ('{client.Name}', '{client.Cpf}','{client.Birthday}', '{client.Rg}', '{client.Creation_Date}');";
            Query.Execute(query, Connection_string.String);
        }
    }
}
