using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.MoneyRelated
{
    internal class Transaction
    {
        private int _id;
        private int _id_payment_method;
        private int _id_type;
        private DateTime _date;
        private DateTime _hour;

        public int Id { get => _id; set => _id = value; }
        public int Id_payment_method { get => _id_payment_method; set => _id_payment_method = value; }
        public int Id_type { get => _id_type; set => _id_type = value; }
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
