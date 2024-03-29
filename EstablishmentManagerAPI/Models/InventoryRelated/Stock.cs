﻿namespace Models.InventoryRelated
{
    public class Stock
    {
        private int _stockId;
        private int _id_product;
        private int _quantity;
        private DateOnly _added_to_stock;

        public Stock() { }
        

        public Stock(int id_product, int quantity, DateOnly added_to_stock)
        {
            Id_product = id_product;
            Quantity = quantity;
            Added_to_stock = added_to_stock;
        }

        public int StockId { get => _stockId; set => _stockId = value; }
        public int Id_product { get => _id_product; set => _id_product = value; }
        public int Quantity { get => _quantity; set => _quantity = value; }
        public DateOnly Added_to_stock { get => _added_to_stock; set => _added_to_stock = value; }
    }
}
