namespace EstablishmentManagerLibrary.MoneyRelated
{
    public class Payment_method
    {
        private string _id;
        private string _type;
        private string _name;

        public Payment_method()
        {
            
        }

        public Payment_method(string type, string name)
        {
            Type = type;
            Name = name;
        }

        public string Id { get => _id; set => _id = value; }
        public string Type { get => _type; set => _type = value; }
        public string Name { get => _name; set => _name = value; }
    }
}
