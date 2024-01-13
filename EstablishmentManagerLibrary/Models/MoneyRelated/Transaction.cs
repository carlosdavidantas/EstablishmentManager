using EstablishmentManagerLibrary.Models.OrdersRelated;
using System;
using System.Collections.Generic;

namespace EstablishmentManagerLibrary.Models.MoneyRelated
{
    public class Transaction
    {
        private int _transaction_id;
        private DateTime _date;
        private DateTime _hour;

        public ICollection<Payment> Payment { get; set; }

        public Transaction()
        {
            
        }

        public Transaction(DateTime date, DateTime hour)
        {
            Date = date;
            Hour = hour;
        }

        public int Transaction_id { get => _transaction_id; set => _transaction_id = value; }    
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
