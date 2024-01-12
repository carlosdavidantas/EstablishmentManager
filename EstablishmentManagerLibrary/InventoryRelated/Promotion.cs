using System;

namespace EstablishmentManagerLibrary.InventoryRelated
{
    public class Promotion
    {
        private string _id;
        private string _id_product;
        private string _id_group_od_product;
        private string _name;
        private string _description;
        private decimal _sell_price;
        private string category;
        private DateTime _created;

        public string Id { get => _id; set => _id = value; }
        public string Id_product { get => _id_product; set => _id_product = value; }
        public string Id_group_od_product { get => _id_group_od_product; set => _id_group_od_product = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public decimal Sell_price { get => _sell_price; set => _sell_price = value; }
        public string Category { get => category; set => category = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
