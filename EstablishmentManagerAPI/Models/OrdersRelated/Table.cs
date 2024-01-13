namespace EstablishmentManagerLibrary.Models.OrdersRelated
{
    public class Table
    {
        private int _tableId;
        private string _name;
        private DateTime _usage_date;
        private DateTime _initial_time;
        private DateTime _time_spent;
        
        public ICollection<Order> Orders { get; set; }


        public Table()
        {
            
        }

        public Table(string name, DateTime initial_time)
        {
            Name = name;
            Usage_date = DateTime.Now;
            Initial_time = initial_time;
        }

        public int TableId { get => _tableId; set => _tableId = value; }
        public string Name { get => _name; set => _name = value; }
        public DateTime Usage_date { get => _usage_date; set => _usage_date = value; }
        public DateTime Initial_time { get => _initial_time; set => _initial_time = value; }
        public DateTime Time_spent { get => _time_spent; set => _time_spent = value; }
    }
}
