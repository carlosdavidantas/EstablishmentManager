using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.Database
{
    internal static class Connection_string
    {
        internal static string String = $@"Server=localhost\SQLEXPRESS;Database={Database_setup.Database_name};Trusted_Connection=True";
    }
}
