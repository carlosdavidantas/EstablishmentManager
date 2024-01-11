namespace EstablishmentManagerLibrary.Database
{
    internal static class Connection_string
    {
        internal static string String = $@"Server=localhost\SQLEXPRESS;Database={Database_setup.Database_name};Trusted_Connection=True";
    }
}
