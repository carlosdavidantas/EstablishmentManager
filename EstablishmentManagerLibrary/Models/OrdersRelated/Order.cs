using EstablishmentManagerLibrary.Models.MoneyRelated;
using System.Collections.Generic;

namespace EstablishmentManagerLibrary.Models.OrdersRelated
{
    public class Order
    {
        private int _order_id;
        private int _id_table;
        private int _id_delivery;
        private string _client_name_note;
        private string _observation;

        public ICollection<Payment> Payments { get; set; }

        //Foreign key for Delivery
        public int Delivery_id { get; set; }
        public virtual Delivery Delivery { get; set; }

        //Foreign key for Table
        public int Table_id { get; set; }
        public virtual Table Table { get; set; }

        public Order()
        {
            
        }

        public Order(int id_table, int id_delivery, string client_name_note, string observation)
        {
            Id_table = id_table;
            Id_delivery = id_delivery;
            Client_name_note = client_name_note;
            Observation = observation;
        }

        public int Order_id { get => _order_id; set => _order_id = value; }
        public int Id_table { get => _id_table; set => _id_table = value; }
        public int Id_delivery { get => _id_delivery; set => _id_delivery = value; }
        public string Client_name_note { get => _client_name_note; set => _client_name_note = value; }
        public string Observation { get => _observation; set => _observation = value; }
    }
}
