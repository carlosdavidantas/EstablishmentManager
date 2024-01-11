using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Client
{
    internal class Client_address
    {
        private int _id;
        private string _street_name;
        private int _cep;
        private string _complement;
        private string _reference;
        private int _number;
        private string _description;

        public int Id { get => _id; set => _id = value; }
        public string Street_name { get => _street_name; set => _street_name = value; }
        public int Cep { get => _cep; set => _cep = value; }
        public string Complement { get => _complement; set => _complement = value; }
        public string Reference { get => _reference; set => _reference = value; }
        public int Number { get => _number; set => _number = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
