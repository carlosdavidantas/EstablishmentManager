namespace Models.InventoryRelated
{
    public class Promotion
    {
        private int _promotionId;
        private string _name;
        private string _description;
        private decimal _sell_price;
        private string _category;
        private DateOnly _creation_date;

        public ICollection<Product> Products { get; set; }
        public ICollection<Group_of_product> Group_of_products { get; set; }


        public Promotion() 
        {
            Products = new List<Product>();
            Group_of_products = new List<Group_of_product>();
        }
        

        public Promotion(string name, string description, decimal sell_price, string category)
        {
            Name = name;
            Description = description;
            Sell_price = sell_price;
            Category = category;
            Creation_date = DateOnly.Parse(DateTime.Now.ToString());
            Products = new List<Product>();
            Group_of_products = new List<Group_of_product>();
        }

        public int PromotionId { get => _promotionId; set => _promotionId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public string Category { get => _category; set => _category = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
    }
}
