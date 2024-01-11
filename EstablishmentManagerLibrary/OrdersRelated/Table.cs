using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.OrdersRelated
{
    internal class Table
    {
        private int _id;
        private int _id_orders;
        private string _name;
        private DateTime _date;
        private DateTime _time;

        public int Id { get => _id; set => _id = value; }
        public int Id_orders { get => _id_orders; set => _id_orders = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime Time { get => _time; set => _time = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
