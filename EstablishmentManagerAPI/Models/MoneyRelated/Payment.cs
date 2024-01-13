using Models.OrdersRelated;

namespace EstablishmentManagerLibrary.Models.MoneyRelated
{
    public class Payment
    {
        private int _paymentId;
        private string _payment_type;
        private string _payment_info;
        private decimal _value;

        //Foreign key for Transaction
        public int TransactionId { get; set; }
        public Transaction Transaction { get; set; }

        //Foreign key for Order
        public int Order_id { get; set; }
        public virtual Order Order { get; set; }


        public Payment()
        {
            
        }

        public Payment(string payment_type, string payment_info, decimal value)
        {
            Payment_type = payment_type;
            Payment_info = payment_info;
            Value = value;
        }

        public int PaymentId { get => _paymentId; set => _paymentId = value; }
        public string Payment_type { get => _payment_type; set => _payment_type = value; }
        public string Payment_info { get => _payment_info; set => _payment_info = value; }
        public decimal Value { get => _value; set => _value = value; }
    }
}
