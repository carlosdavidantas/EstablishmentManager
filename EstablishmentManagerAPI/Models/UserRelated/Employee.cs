namespace EstablishmentManagerLibrary.Models.UserRelated
{
    public class Employee
    {
        private int _employeeId;
        private int _id_user;
        private DateTime _birthday;
        private string _name;
        private string _cpf;
        private DateTime _created;

        public Employee()
        {
            
        }

        public Employee(int id_user, DateTime birthday, string name, string cpf)
        {
            Id_user = id_user;
            Birthday = birthday;
            Name = name;
            Cpf = cpf;
            Created = DateTime.Now;
        }

        public int EmployeeId { get => _employeeId; set => _employeeId = value; }
        public int Id_user { get => _id_user; set => _id_user = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
