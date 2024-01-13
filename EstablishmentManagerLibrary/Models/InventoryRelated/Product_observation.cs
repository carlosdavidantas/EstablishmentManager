using EstablishmentManagerLibrary.Models.ClientRelated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Models.InventoryRelated
{
    public class Product_observation
    {
        private int _product_observation_id;
        private string _info;
        private string _category;

        //Foreign key for product
        public int Product_id { get; set; }
        public virtual Product Product { get; set; }

        public Product_observation()
        {
            
        }

        public Product_observation(string info, string category)
        {
            Info = info;
            Category = category;
        }

        public int Product_observation_id { get => _product_observation_id; set => _product_observation_id = value; }
        public string Info { get => _info; set => _info = value; }
        public string Category { get => _category; set => _category = value; }
    }
}
