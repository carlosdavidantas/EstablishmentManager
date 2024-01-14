namespace Models.UserRelated
{
    public class User
    {
        private int _userId;
        private int _id_permission;
        private string _login;
        private string _password;
        private DateOnly _creation_date;

        public ICollection<Permission> Permissions { get; set; }

        public User()
        {
            Permissions = new List<Permission>();
        }
        

        public User(int id_permission, string login, string password)
        {
            Id_permission = id_permission;
            Login = login;
            Password = password;
            Permissions = new List<Permission>();
            Creation_date = DateOnly.Parse(DateTime.Now.ToString());
        }

        public int UserId { get => _userId; set => _userId = value; }
        public int Id_permission { get => _id_permission; set => _id_permission = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
    }
}
