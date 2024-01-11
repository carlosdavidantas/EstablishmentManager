﻿using System;

namespace EstablishmentManagerLibrary.Inventory
{
    public class Stock
    {
        private string _id;
        private string _id_product;
        private string _quantity;
        private DateTime _added_to_stock;

        public string Id { get => _id; set => _id = value; }
        public string Id_product { get => _id_product; set => _id_product = value; }
        public string Quantity { get => _quantity; set => _quantity = value; }
        public DateTime Added_to_stock { get => _added_to_stock; set => _added_to_stock = value; }
    }
}
