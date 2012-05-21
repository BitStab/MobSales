using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobSales.Logic.DataService
{
    public interface ICustomerService
    {
        void init();
        void LoadCustomer(string search_value);
        event EventHandler<CustomerLoadedEventArgs> LoadCustomerCompleted;
    }
}