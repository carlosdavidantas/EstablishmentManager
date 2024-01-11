namespace EstablishmentManagerLibrary.Database.CRUD
{
    public class Delete
    {
        public static void Client(string id)
        {
            string queryString = $"delete from [Client] where [id] = '{id}';";
            Query.Execute(queryString, Connection_string.String);
        }
    }
}
