﻿namespace Models.InventoryRelated
{
    public class Product
    {
        private int _productId;
        private string _name;
        private string _description;
        private string _category;
        private decimal _cost_price;
        private decimal _sell_price;
        private DateOnly _creation_date;

        public ICollection<Product_addon> Product_addons { get; set; }
        public ICollection<Product_observation> Product_observations { get; set; }


        //Foreign key for Group_of_product
        public int Group_of_productId { get; set; }
        public Group_of_product Group_of_product { get; set; }

        //Foreign key for Promotion
        public int PromotionId { get; set; }
        public Promotion Promotion { get; set; }


        public Product()
        {
            Product_addons = new List<Product_addon>();
            Product_observations = new List<Product_observation>();
        }
        

        public Product(string name, string description, string category, decimal cost_price, decimal sell_price)
        {
            Name = name;
            Description = description;
            Category = category;
            Cost_price = cost_price;
            Sell_price = sell_price;
            Creation_date = DateOnly.FromDateTime(DateTime.Today);
            Product_addons = new List<Product_addon>();
            Product_observations = new List<Product_observation>();
        }

        public int ProductId { get => _productId; set => _productId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Cost_price { get => _cost_price; set => _cost_price = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
    }
}
