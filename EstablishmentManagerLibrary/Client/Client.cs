using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Client
{
    internal class Client
    {
        private int _id;
        private string _name;
        private int _cpf;
        private DateTime _birthday;
        private int _rg;
        private DateTime _creation_date;

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public int Cpf { get => _cpf; set => _cpf = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public int Rg { get => _rg; set => _rg = value; }
        internal DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
    }

}
