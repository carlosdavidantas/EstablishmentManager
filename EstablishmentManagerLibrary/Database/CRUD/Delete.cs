namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Delete
    {
        public static void Client(string id)
        {
            string queryString = $"delete from [Client] where [id] = '{id}';";
            QueryFunction.Execute(queryString, Database_query_strings.Establishment_connection_string);
        }
    }
}
