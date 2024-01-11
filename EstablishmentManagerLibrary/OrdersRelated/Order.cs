using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    internal class Order
    {
        private int _id;
        private int _id_type;
        private int _id_payment_value;
        private string _client_name;
        private string _observation;

        public int Id { get => _id; set => _id = value; }
        public int Id_type { get => _id_type; set => _id_type = value; }
        public int Id_payment_value { get => _id_payment_value; set => _id_payment_value = value; }
        public string Client_name { get => _client_name; set => _client_name = value; }
        public string Observation { get => _observation; set => _observation = value; }
    }
}
