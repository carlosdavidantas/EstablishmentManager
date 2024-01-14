namespace Models.UserRelated
{
    public class Employee
    {
        private int _employeeId;
        private int _id_user;
        private DateOnly _birthday;
        private string _name;
        private string _cpf;
        private DateOnly _creation_date;

        public Employee() { }
        

        public Employee(int id_user, DateOnly birthday, string name, string cpf)
        {
            Id_user = id_user;
            Birthday = birthday;
            Name = name;
            Cpf = cpf;
            Creation_date = DateOnly.Parse(DateTime.Now.ToString());
        }

        public int EmployeeId { get => _employeeId; set => _employeeId = value; }
        public int Id_user { get => _id_user; set => _id_user = value; }
        public DateOnly Birthday { get => _birthday; set => _birthday = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => _cpf; set => _cpf = value; }
        public DateOnly Creation_date { get => _creation_date; set => _creation_date = value; }
    }
}
