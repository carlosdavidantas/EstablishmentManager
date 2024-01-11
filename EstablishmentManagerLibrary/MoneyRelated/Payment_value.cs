using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentManagerLibrary.MoneyRelated
{
    internal class Payment_value
    {
        private int _id;
        private int _id_payment_method;
        private int _value;

        public int Id { get => _id; set => _id = value; }
        public int Id_payment_method { get => _id_payment_method; set => _id_payment_method = value; }
        public int Value { get => _value; set => _value = value; }
    }
}
