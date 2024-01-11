using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Client_related
{
    public class Client
    {
        private int _id;
        private string _name;
        private string _cpf;
        private DateTime _birthday;
        private string _rg;
        private DateTime _creation_date;

        public Client()
        {
            
        }

        public Client(string name, string cpf, DateTime birthday, string rg, DateTime creation_date)
        {
            Name = name;
            Cpf = cpf;
            Birthday = birthday;
            Rg = rg;
            Creation_Date = creation_date;
        }

        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Rg { get => _rg; set => _rg = value; }
        public DateTime Creation_Date { get => _creation_date; set => _creation_date = value; }
    }

}
