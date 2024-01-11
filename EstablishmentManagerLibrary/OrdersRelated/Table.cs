using System;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    public class Table
    {
        private string _id;
        private string _id_orders;
        private string _name;
        private DateTime _usage_date;
        private DateTime _initial_time;
        private DateTime _time_spent;

        public string Id { get => _id; set => _id = value; }
        public string Id_orders { get => _id_orders; set => _id_orders = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime Usage_date { get => _usage_date; set => _usage_date = value; }
        public DateTime Initial_time { get => _initial_time; set => _initial_time = value; }
        public DateTime Time_spent { get => _time_spent; set => _time_spent = value; }
    }
}
