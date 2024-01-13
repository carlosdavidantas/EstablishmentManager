namespace Models.ClientRelated
{
    public class Client_address
    {
        private int _client_addressId;
        private string _street_name;
        private string _cep;
        private string _complement;
        private string _reference;
        private string _number;
        private string _description;
        private DateTime _creation_date;
        private DateTime _modified_date;

        //Foreign key for client
        public int ClientId { get; set; }
        public Client Client { get; set; }


        public Client_address()
        {
            
        }

        public Client_address(string street_name, string cep, string complement, string reference, 
            string number, string description)
        {
            Street_name = street_name;
            Cep = cep;
            Complement = complement;
            Reference = reference;
            Number = number;
            Description = description;
            Creation_date = DateTime.Now;
            Modified_date = DateTime.Now;
        }

        public int Client_addressId { get => _client_addressId; set => _client_addressId = value; }
        public string Street_name { get => _street_name; set => _street_name = value; }
        public string Cep { get => _cep; set => _cep = value; }
        public string Complement { get => _complement; set => _complement = value; }
        public string Reference { get => _reference; set => _reference = value; }
        public string Number { get => _number; set => _number = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Modified_date { get => _modified_date; set => _modified_date = value; }
    }
}
