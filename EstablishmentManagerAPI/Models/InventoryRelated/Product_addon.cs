namespace Models.InventoryRelated
{
    public class Product_addon
    {
        private int _product_addonId;
        private string _name;
        private string _description;
        private string _category;
        private decimal _cost_price;
        private decimal _sell_price;
        private DateOnly _creation_date;

        //Foreign key for product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Product_addon() { }
       

        public Product_addon(string name, string description, string category, decimal cost_price, decimal sell_price)
        {
            Name = name;
            Description = description;
            Category = category;
            Cost_price = cost_price;
            Sell_price = sell_price;
            Creation_dat = DateOnly.FromDateTime(DateTime.Today);
        }

        public int Product_addonId { get => _product_addonId; set => _product_addonId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Cost_price { get => _cost_price; set => _cost_price = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public DateOnly Creation_dat { get => _creation_date; set => _creation_date = value; }
    }
}
