using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Inventory
{
    internal class Promotion
    {
        private int _id;
        private int _id_product;
        private string _name;
        private string _description;
        private decimal _sell_value;
        private string category;

        public int Id { get => _id; set => _id = value; }
        public int Id_product { get => _id_product; set => _id_product = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Sell_value { get => _sell_value; set => _sell_value = value; }
        public string Category { get => category; set => category = value; }
    }
}
