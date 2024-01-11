using System;

namespace EstablishmentManagerLibrary.Client_related
{
    internal class Client_address
    {
        private string _id;
        private string _street_name;
        private string _cep;
        private string _complement;
        private string _reference;
        private string _number;
        private string _description;
        private DateTime _creation_date;
        private DateTime _modified_date;

        public string Id { get => _id; set => _id = value; }
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
