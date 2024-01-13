using System;
using System.Collections.Generic;

namespace EstablishmentManagerLibrary.Models.InventoryRelated
{
    public class Group_of_product
    {
        private int _group_of_product_id;
        private string _name;
        private string _description;
        private string _category;
        private decimal _cost_price;
        private decimal _sell_price;
        private DateTime _created;

        public ICollection<Product> Products { get; set; }

        //Foreign key for Promotion
        public int Promotion_id { get; set; }
        public virtual Promotion Promotion { get; set; }


        public Group_of_product()
        {
            
        }

        public Group_of_product(string name, string description, string category, decimal cost_price, decimal sell_price)
        {
            Name = name;
            Description = description;
            Category = category;
            Cost_price = cost_price;
            Sell_price = sell_price;
            Created = DateTime.Now;

        }

        public int Group_of_product_id { get => _group_of_product_id; set => _group_of_product_id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Cost_price { get => _cost_price; set => _cost_price = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
