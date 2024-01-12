namespace EstablishmentManagerLibrary.MoneyRelated
{
    public class Payment_value
    {
        private string _id;
        private string _id_payment_method;
        private decimal _value;

        public Payment_value()
        {
            
        }

        public Payment_value(string id_payment_method, decimal value)
        {
            Id_payment_method = id_payment_method;
            Value = value;
        }

        public string Id { get => _id; set => _id = value; }
        public string Id_payment_method { get => _id_payment_method; set => _id_payment_method = value; }
        public decimal Value { get => _value; set => _value = value; }
    }
}
