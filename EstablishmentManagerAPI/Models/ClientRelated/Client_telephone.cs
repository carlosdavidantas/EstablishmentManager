namespace Models.ClientRelated
{
    public class Client_telephone
    {
        private int _client_telephoneId;
        private string _number;
        private string _description;
        private DateOnly _creation_date;
        private DateOnly _modified_date;

        //Foreign key for client
        public int ClientId { get; set; }
        public Client Client { get; set; }


        public Client_telephone() { }
        

        public Client_telephone(string number, string description)
        {
            Number = number;
            Description = description;
            Creation_date = DateOnly.FromDateTime(DateTime.Today);
            Modified_date = DateOnly.FromDateTime(DateTime.Today);
        }

        public int Client_telephoneId { get => _client_telephoneId; set => _client_telephoneId = value; }
        public string Number { get => _number; set => _number = value; }
        public string Description { get => _description; set => _description = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateOnly Modified_date { get => _modified_date; set => _modified_date = value; }
    }
}
