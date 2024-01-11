using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstablishmentManagerLibrary.Client_related;

namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Edit
    {
        public static void Client(string id, Client client)
        {
            string queryString = $"update [Client] set [name] = '{client.Name}', [cpf] = '{client.Cpf}'," +
                $" [birthday] = '{client.Birthday}', [rg] = '{client.Rg}' " +
                $" where [id] = '{id}';";

            Query.Execute(queryString, Connection_string.String);
        }
    }
}
