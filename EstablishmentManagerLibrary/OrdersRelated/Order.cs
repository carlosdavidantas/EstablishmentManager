namespace EstablishmentManagerLibrary.OrdersRelated
{
    public class Order
    {
        private string _id;
        private string _id_type;
        private string _id_payment_value;
        private string _client_name;
        private string _observation;

        public string Id { get => _id; set => _id = value; }
        public string Id_type { get => _id_type; set => _id_type = value; }
        public string Id_payment_value { get => _id_payment_value; set => _id_payment_value = value; }
        public string Client_name { get => _client_name; set => _client_name = value; }
        public string Observation { get => _observation; set => _observation = value; }
    }
}
