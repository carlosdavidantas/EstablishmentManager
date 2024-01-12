using System;

namespace EstablishmentManagerLibrary.InventoryRelated
{
    public class Stock
    {
        private string _id;
        private string _id_product;
        private string _quantity;
        private DateTime _added_to_stock;

        public Stock()
        {
            
        }

        public Stock(string id_product, string quantity, DateTime added_to_stock)
        {
            Id_product = id_product;
            Quantity = quantity;
            Added_to_stock = added_to_stock;
        }

        public string Id { get => _id; set => _id = value; }
        public string Id_product { get => _id_product; set => _id_product = value; }
        public string Quantity { get => _quantity; set => _quantity = value; }
        public DateTime Added_to_stock { get => _added_to_stock; set => _added_to_stock = value; }
    }
}
