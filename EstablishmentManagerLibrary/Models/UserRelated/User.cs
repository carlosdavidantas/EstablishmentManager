using System.Collections.Generic;

namespace EstablishmentManagerLibrary.Models.UserRelated
{
    public class User
    {
        private int _user_id;
        private int _id_permission;
        private string _login;
        private string _password;

        public ICollection<Permission> Permissions { get; set; }

        public User()
        {
            
        }

        public User(int id_permission, string login, string password)
        {
            Id_permission = id_permission;
            Login = login;
            Password = password;
        }

        public int User_id { get => _user_id; set => _user_id = value; }
        public int Id_permission { get => _id_permission; set => _id_permission = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
