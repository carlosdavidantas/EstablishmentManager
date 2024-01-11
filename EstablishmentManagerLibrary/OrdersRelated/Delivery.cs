using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    internal class Delivery
    {
        private int _id;
        private int _id_deliveryman_employee;
        private int _id_orders;
        private int _id_client;
        private int _tax_value;
        private DateTime _date;
        private DateTime _time;
        private DateTime _time_delivery_man_arrived;
        private DateTime _schedule_date;

        public int Id { get => _id; set => _id = value; }
        public int Id_deliveryman_employee { get => _id_deliveryman_employee; set => _id_deliveryman_employee = value; }
        public int Id_orders { get => _id_orders; set => _id_orders = value; }
        public int Id_client { get => _id_client; set => _id_client = value; }
        public int Tax_value { get => _tax_value; set => _tax_value = value; }
        public DateTime Time { get => _time; set => _time = value; }
        public DateTime Time_delivery_man_arrived { get => _time_delivery_man_arrived; set => _time_delivery_man_arrived = value; }
        public DateTime Schedule_date { get => _schedule_date; set => _schedule_date = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
