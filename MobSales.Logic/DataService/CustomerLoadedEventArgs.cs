using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobSales.Logic.Base;
using MobSales.Logic.Model;

namespace MobSales.Logic.DataService
{
    public class CustomerLoadedEventArgs:OperationEventArgs
    {
        public IEnumerable<Customer> Customers { get; set; }


        public CustomerLoadedEventArgs(IEnumerable<Customer> customers)
        {
            this.Customers = customers;
        }
    }
}