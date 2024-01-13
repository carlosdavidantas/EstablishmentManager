using EstablishmentManagerLibrary.Models.OrdersRelated;

namespace EstablishmentManagerLibrary.Models.MoneyRelated
{
    public class Payment
    {
        private int _payment_id;
        private string _payment_type;
        private string _payment_info;
        private decimal _value;

        //Foreign key for Transaction
        public int Transaction_id { get; set; }
        public virtual Transaction Transaction { get; set; }

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

        public int Payment_id { get => _payment_id; set => _payment_id = value; }
        public string Payment_type { get => _payment_type; set => _payment_type = value; }
        public string Payment_info { get => _payment_info; set => _payment_info = value; }
        public decimal Value { get => _value; set => _value = value; }
    }
}
