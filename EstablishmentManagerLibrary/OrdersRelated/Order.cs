namespace EstablishmentManagerLibrary.OrdersRelated
{
    public class Order
    {
        private string _id;
        private string _id_table;
        private string _id_delivery;
        private string _id_payment_value;
        private string _client_name_note;
        private string _observation;

        public string Id { get => _id; set => _id = value; }
        public string Id_table { get => _id_table; set => _id_table = value; }
        public string Id_delivery { get => _id_delivery; set => _id_delivery = value; }
        public string Id_payment_value { get => _id_payment_value; set => _id_payment_value = value; }
        public string Client_name_note { get => _client_name_note; set => _client_name_note = value; }
        public string Observation { get => _observation; set => _observation = value; }
    }
}
