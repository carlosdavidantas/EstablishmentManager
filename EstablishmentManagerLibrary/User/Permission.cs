using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.User
{
    internal class Permission
    {
        private int _id;
        private int _level;

        public int Id { get => _id; set => _id = value; }
        public int Level { get => _level; set => _level = value; }
    }
}
