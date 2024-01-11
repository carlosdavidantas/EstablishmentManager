using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.User
{
    internal class Employee
    {
        private int _id;
        private int _id_user;
        private DateTime _birthday;
        private string _name;
        private int cpf;

        public int Id { get => _id; set => _id = value; }
        public int Id_user { get => _id_user; set => _id_user = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Name { get => _name; set => _name = value; }
        public int Cpf { get => cpf; set => cpf = value; }
    }
}
