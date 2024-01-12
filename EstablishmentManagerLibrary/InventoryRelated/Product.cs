using System;

namespace EstablishmentManagerLibrary.InventoryRelated
{
    public class Product
    {
        private string _id;
        private string _name;
        private string _description;
        private string _category;
        private decimal _cost_price;
        private decimal _sell_price;
        private DateTime _created;

        public Product()
        {
            
        }

        public Product(string name, string description, string category, decimal cost_price, decimal sell_price)
        {
            Name = name;
            Description = description;
            Category = category;
            Cost_price = cost_price;
            Sell_price = sell_price;
            Created = DateTime.Now;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Cost_price { get => _cost_price; set => _cost_price = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
