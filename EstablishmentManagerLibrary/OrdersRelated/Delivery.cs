using System;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    public class Delivery
    {
        private string _id;
        private string _id_deliveryman_employee;
        private string _id_orders;
        private string _id_client;
        private string _tax_value;
        private DateTime _creation_date;
        private DateTime _creation_time;
        private DateTime _time_deliveryman_arrived;
        private DateTime _schedule_date;

        public Delivery()
        {
            
        }

        public Delivery(string id_deliveryman_employee, string id_orders, string id_client, string tax_value, 
            DateTime time_deliveryman_arrived)
        {
            Id_deliveryman_employee = id_deliveryman_employee;
            Id_orders = id_orders;
            Id_client = id_client;
            Tax_value = tax_value;
            Creation_date = DateTime.Now;
            Creation_time = DateTime.Now;
            _time_deliveryman_arrived = time_deliveryman_arrived;
        }

        public string Id { get => _id; set => _id = value; }
        public string Id_deliveryman_employee { get => _id_deliveryman_employee; set => _id_deliveryman_employee = value; }
        public string Id_orders { get => _id_orders; set => _id_orders = value; }
        public string Id_client { get => _id_client; set => _id_client = value; }
        public string Tax_value { get => _tax_value; set => _tax_value = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Creation_time { get => _creation_time; set => _creation_time = value; }
        public DateTime Time_deliveryman_arrived { get => _time_deliveryman_arrived; set => _time_deliveryman_arrived = value; }
        public DateTime Schedule_date { get => _schedule_date; set => _schedule_date = value; }
    }
}
