using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.MoneyRelated
{
    internal class Payment_method
    {
        private int _id;
        private string _type;
        private string _name;

        public int Id { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
