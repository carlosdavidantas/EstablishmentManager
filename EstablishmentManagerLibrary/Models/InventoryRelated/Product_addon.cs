using System;

namespace EstablishmentManagerLibrary.Models.InventoryRelated
{
    public class Product_addon
    {
        private int _product_addon_id;
        private string _name;
        private string _description;
        private string _category;
        private decimal _cost_price;
        private decimal _sell_price;
        private DateTime _created;

        //Foreign key for product
        public int Product_id { get; set; }
        public virtual Product Product { get; set; }

        public Product_addon()
        {
            
        }

        public Product_addon(string name, string description, string category, decimal cost_price, decimal sell_price)
        {
            Name = name;
            Description = description;
            Category = category;
            Cost_price = cost_price;
            Sell_price = sell_price;
            Created = DateTime.Now;
        }

        public int Product_addon_id { get => _product_addon_id; set => _product_addon_id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Cost_price { get => _cost_price; set => _cost_price = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
