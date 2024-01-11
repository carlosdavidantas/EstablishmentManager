namespace EstablishmentManagerLibrary.Database
{
    public class Database_setup
    {
        public static bool CreatDataBase()
        {
            QueryFunction.Execute(Database_query_strings.CreateDataBase, Database_query_strings.Master_connection_string);
            QueryFunction.Execute(Database_query_strings.CreateTables, Database_query_strings.Establishment_connection_string);
            return true;
        }
    }
}
