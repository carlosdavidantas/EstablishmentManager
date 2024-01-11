using System;

namespace EstablishmentManagerLibrary.MoneyRelated
{
    internal class Transaction
    {
        private string _id;
        private string _id_payment_method;
        private string _id_type;
        private DateTime _date;
        private DateTime _hour;

        public string Id { get => _id; set => _id = value; }
        public string Id_payment_method { get => _id_payment_method; set => _id_payment_method = value; }
        public string Id_type { get => _id_type; set => _id_type = value; }
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
