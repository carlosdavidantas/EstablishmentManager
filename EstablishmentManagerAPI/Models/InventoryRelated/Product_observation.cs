namespace Models.InventoryRelated
{
    public class Product_observation
    {
        private int _product_observationId;
        private string _info;
        private string _category;

        //Foreign key for product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public Product_observation() { }
        

        public Product_observation(string info, string category)
        {
            Info = info;
            Category = category;
        }

        public int Product_observationId { get => _product_observationId; set => _product_observationId = value; }
        public string Info { get => _info; set => _info = value; }
        public string Category { get => _category; set => _category = value; }
    }
}
