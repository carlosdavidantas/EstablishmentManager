using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Client
{
    internal class Client_telephone
    {
        private int _id;
        private int _number;
        private string _description;

        public int Id { get => _id; set => _id = value; }
        public int Number { get => _number; set => _number = value; }
        public string Description { get => _description; set => _description = value; }
    }
}
