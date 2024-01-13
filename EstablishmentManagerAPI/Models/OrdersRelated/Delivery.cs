﻿using System.ComponentModel.DataAnnotations;

namespace EstablishmentManagerLibrary.Models.OrdersRelated
{
    public class Delivery
    {
        private int _deliveryId;
        private int _id_deliveryman_employee;
        private int _id_client;
        private decimal _tax_value;
        private DateTime _creation_date;
        private DateTime _creation_time;
        private DateTime _time_deliveryman_arrived;
        private DateTime _schedule_date;

        public ICollection<Order> Orders { get; set; }

        public Delivery()
        {
            
        }

        public Delivery(int id_deliveryman_employee, int id_client, decimal tax_value, 
            DateTime time_deliveryman_arrived)
        {
            Id_deliveryman_employee = id_deliveryman_employee; 
            Id_client = id_client;
            Tax_value = tax_value;
            Creation_date = DateTime.Now;
            Creation_time = DateTime.Now;
            _time_deliveryman_arrived = time_deliveryman_arrived;
        }

        public int DeliveryId { get => _deliveryId; set => _deliveryId = value; }
        public int Id_deliveryman_employee { get => _id_deliveryman_employee; set => _id_deliveryman_employee = value; }
        public int Id_client { get => _id_client; set => _id_client = value; }
        public decimal Tax_value { get => _tax_value; set => _tax_value = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Creation_time { get => _creation_time; set => _creation_time = value; }
        public DateTime Time_deliveryman_arrived { get => _time_deliveryman_arrived; set => _time_deliveryman_arrived = value; }
        public DateTime Schedule_date { get => _schedule_date; set => _schedule_date = value; }
    }
}
