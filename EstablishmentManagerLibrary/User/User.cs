using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.User
{
    internal class User
    {
        private int _id;
        private int _id_permission;
        private string _login;
        private string _password;

        public int Id { get => _id; set => _id = value; }
        public int Id_permission { get => _id_permission; set => _id_permission = value; }
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }
    }
}
