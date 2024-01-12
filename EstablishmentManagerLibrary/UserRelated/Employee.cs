﻿using System;

namespace EstablishmentManagerLibrary.UserRelated
{
    public class Employee
    {
        private string _id;
        private string _id_user;
        private DateTime _birthday;
        private string _name;
        private string cpf;
        private DateTime _created;

        public Employee()
        {
            
        }

        public Employee(string id_user, DateTime birthday, string name, string cpf)
        {
            Id_user = id_user;
            Birthday = birthday;
            Name = name;
            Cpf = cpf;
            Created = DateTime.Now;
        }

        public string Id { get => _id; set => _id = value; }
        public string Id_user { get => _id_user; set => _id_user = value; }
        public DateTime Birthday { get => _birthday; set => _birthday = value; }
        public string Name { get => _name; set => _name = value; }
        public string Cpf { get => cpf; set => cpf = value; }
        public DateTime Created { get => _created; set => _created = value; }
    }
}
