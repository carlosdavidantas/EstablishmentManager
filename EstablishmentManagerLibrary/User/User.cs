namespace EstablishmentManagerLibrary.User
{
    public class User
    {
        private string _id;
        private string _id_permission;
        private string _login;
        private string _password;

        public string Id { get => _id; set => _id = value; }
        public string Id_permission { get => _id_permission; set => _id_permission = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
