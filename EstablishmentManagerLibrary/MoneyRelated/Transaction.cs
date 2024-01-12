using System;

namespace EstablishmentManagerLibrary.MoneyRelated
{
    public class Transaction
    {
        private string _id;
        private string _id_payment_method;
        private string _id_order;
        private DateTime _date;
        private DateTime _hour;

        public string Id { get => _id; set => _id = value; }
        public string Id_payment_method { get => _id_payment_method; set => _id_payment_method = value; }
        public string Id_order { get => _id_order; set => _id_order = value; }
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
