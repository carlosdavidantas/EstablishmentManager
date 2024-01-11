using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    internal class Delivery
    {
        private string _id;
        private string _id_deliveryman_employee;
        private string _id_orders;
        private string _id_client;
        private string _tax_value;
        private DateTime _creation_date;
        private DateTime _creation_time;
        private DateTime _time_delivery_man_arrived;
        private DateTime _schedule_date;

        public string Id { get => _id; set => _id = value; }
        public string Id_deliveryman_employee { get => _id_deliveryman_employee; set => _id_deliveryman_employee = value; }
        public string Id_orders { get => _id_orders; set => _id_orders = value; }
        public string Id_client { get => _id_client; set => _id_client = value; }
        public string Tax_value { get => _tax_value; set => _tax_value = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Creation_time { get => _creation_time; set => _creation_time = value; }
        public DateTime Time_delivery_man_arrived { get => _time_delivery_man_arrived; set => _time_delivery_man_arrived = value; }
        public DateTime Schedule_date { get => _schedule_date; set => _schedule_date = value; }
    }
}
