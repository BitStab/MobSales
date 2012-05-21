using System;
using System.Collections.Generic;
using System.Text;

namespace MobSales.Logic.Model
{
    public class Customer
    {
        public string No { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Post_Code { get; set; }

        public Customer(Customer _customer)
        {
            this.No = _customer.No;
            this.Name = _customer.Name;
            this.Address = _customer.Address;
            this.Post_Code = _customer.Post_Code;
        }

        public Customer() { }

        public override string ToString()
        {
            string objectString = No + " " + Name;
            return objectString;
        }
    }
}
