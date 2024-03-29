﻿namespace Models.ClientRelated
{
    public class Client
    {
        private int _clientId;
        private string _name;
        private string _cpf;
        private DateOnly _birthday;
        private string _rg;
        private DateOnly _creation_date;
        private DateOnly _modified_date;
        private decimal _credit_on_establishment;
        private decimal _debit_on_establishment;

        public ICollection<Client_telephone> Client_telephones { get; set; }
        public ICollection<Client_address> Client_addresses { get; set; }


        public Client()
        {
            Client_telephones = new List<Client_telephone>();
            Client_addresses = new List<Client_address>();
        }

        public Client(string name, string cpf, DateOnly birthday, string rg, decimal credit_on_establishment, 
            decimal debit_on_establishment)
        {
            Name = name;
            Cpf = cpf;
            Birthday = birthday;
            Rg = rg;
            Creation_date = DateOnly.FromDateTime(DateTime.Today);
            Modified_date = DateOnly.FromDateTime(DateTime.Today);
            Credit_on_establishment = credit_on_establishment;
            Debit_on_establishment = debit_on_establishment;
            Client_telephones = new List<Client_telephone>();
            Client_addresses = new List<Client_address>();
        }

        public int ClientId { get => _clientId; set => _clientId = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateOnly Birthday { get => _birthday; set => _birthday = value; }
        public string Rg { get => _rg; set => _rg = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateOnly Modified_date { get => _modified_date; set => _modified_date = value; }
        public decimal Credit_on_establishment { get => _credit_on_establishment; set => _credit_on_establishment = value; }
        public decimal Debit_on_establishment { get => _debit_on_establishment; set => _debit_on_establishment = value; }
    }

}
