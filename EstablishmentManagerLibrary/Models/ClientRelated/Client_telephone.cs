using System;

namespace EstablishmentManagerLibrary.Models.ClientRelated
{
    public class Client_telephone
    {
        private int _client_telephone_id;
        private string _number;
        private string _description;
        private DateTime _creation_date;
        private DateTime _modified_date;

        //Foreign key for client
        public int Client_id { get; set ; }
        public virtual Client Client {  get; set; }


        public Client_telephone()
        {
            
        }

        public Client_telephone(string number, string description)
        {
            Number = number;
            Description = description;
            Creation_date = DateTime.Now;
            Modified_date = DateTime.Now;
        }

        public int Client_telephone_id { get => _client_telephone_id; set => _client_telephone_id = value; }
        public string Number { get => _number; set => _number = value; }
        public string Description { get => _description; set => _description = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Modified_date { get => _modified_date; set => _modified_date = value; }
    }
}
