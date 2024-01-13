namespace Models.MoneyRelated
{
    public class Transaction
    {
        private int _transactionId;
        private DateTime _date;
        private DateTime _hour;

        public ICollection<Payment> Payments { get; set; }


        public Transaction()
        {
            Payments = new List<Payment>();
        }


        public Transaction(DateTime date, DateTime hour)
        {
            Date = date;
            Hour = hour;
            Payments = new List<Payment>();
        }

        public int TransactionId { get => _transactionId; set => _transactionId = value; }    
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
