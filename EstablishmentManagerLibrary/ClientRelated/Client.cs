using System;

namespace EstablishmentManagerLibrary.ClientRelated
{
    public class Client
    {
        private string _id;
        private string _name;
        private string _cpf;
        private DateTime _birthday;
        private string _rg;
        private DateTime _creation_date;
        private DateTime _modified_date;
        private decimal _credit_on_establishment;
        private decimal _debit_on_establishment;

        public Client() { }

        public Client(string name, string cpf, DateTime birthday, string rg, decimal credit_on_establishment, decimal debit_on_establishment)
        {
            Name = name;
            Cpf = cpf;
            Birthday = birthday;
            Rg = rg;
            Creation_date = DateTime.Today;
            Modified_date = DateTime.Today;
            Credit_on_establishment = credit_on_establishment;
            Debit_on_establishment = debit_on_establishment;
        }

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Rg { get => _rg; set => _rg = value; }
        public DateTime Creation_date { get => _creation_date; set => _creation_date = value; }
        public DateTime Modified_date { get => _modified_date; set => _modified_date = value; }
        public decimal Credit_on_establishment { get => _credit_on_establishment; set => _credit_on_establishment = value; }
        public decimal Debit_on_establishment { get => _debit_on_establishment; set => _debit_on_establishment = value; }
    }

}
