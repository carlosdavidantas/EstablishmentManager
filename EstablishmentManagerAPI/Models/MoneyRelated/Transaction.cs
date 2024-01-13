namespace EstablishmentManagerLibrary.Models.MoneyRelated
{
    public class Transaction
    {
        private int _transactionId;
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

        public int TransactionId { get => _transactionId; set => _transactionId = value; }    
        public DateTime Hour { get => _hour; set => _hour = value; }
        internal DateTime Date { get => _date; set => _date = value; }
    }
}
