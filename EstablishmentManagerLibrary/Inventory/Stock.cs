using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Inventory
{
    internal class Stock
    {
        private int _id;
        private int _id_product;
        private int _quantity;

        public int Id { get => _id; set => _id = value; }
        public int Id_product { get => _id_product; set => _id_product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
    }
}
