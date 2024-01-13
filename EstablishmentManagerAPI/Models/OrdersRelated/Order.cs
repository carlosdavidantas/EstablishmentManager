using Models.MoneyRelated;

namespace Models.OrdersRelated
{
    public class Order
    {
        private int _orderId;
        private int _id_table;
        private int _id_delivery;
        private string _client_name_note;
        private string _observation;

        public ICollection<Payment> Payments { get; set; }

        //Foreign key for Delivery
        public int DeliveryId { get; set; }
        public Delivery Delivery { get; set; }

        //Foreign key for Table
        public int Table_id { get; set; }
        public Table Table { get; set; }

        public Order() { }
        

        public Order(int id_table, int id_delivery, string client_name_note, string observation)
        {
            Id_table = id_table;
            Id_delivery = id_delivery;
            Client_name_note = client_name_note;
            Observation = observation;
        }

        public int OrderId { get => _orderId; set => _orderId = value; }
        public int Id_table { get => _id_table; set => _id_table = value; }
        public int Id_delivery { get => _id_delivery; set => _id_delivery = value; }
        public string Client_name_note { get => _client_name_note; set => _client_name_note = value; }
        public string Observation { get => _observation; set => _observation = value; }
    }
}
