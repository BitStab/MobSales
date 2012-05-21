using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Net;
using System.Web.Services;

using MobSales.Logic.Model;
using MobSales.Logic.DataService;


namespace MobSales.Logic.DataService
{
    class CustomerService : ICustomerService
    {
        public event EventHandler<CustomerLoadedEventArgs> LoadCustomerCompleted;
        private bool blocked = false;
        private WebService.rootCustomer root = null;

        public void init()
        {
            SalesService.Instance = new WebService.Test();
            CookieContainer cooks = new CookieContainer();
            SalesService.Instance.CookieContainer = cooks;
            CredentialCache cache = new CredentialCache();
            //credentials
            SalesService.Instance.UseDefaultCredentials = false;
            SalesService.Instance.Credentials = cache;
            SalesService.Instance.PreAuthenticate = true;
        }

        public void LoadCustomer(string search_value)
        {
            if (!blocked)
            {
                blocked = true;
                if (SalesService.Instance == null)
                    init();
                try
                {
                    SalesService.Instance.GetCustomersCompleted += new WebService.GetCustomersCompletedEventHandler(Instance_LoadCustomersCompleted);
                    if (search_value == null || search_value == "")
                        SalesService.Instance.GetCustomersAsync("*", new WebService.rootCustomer());
                    else
                        if (search_value != " ")
                            SalesService.Instance.GetCustomersAsync(search_value, new WebService.rootCustomer());
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        void Instance_LoadCustomersCompleted(object sender, WebService.GetCustomersCompletedEventArgs e)
        {
            try
            {
                List<Customer> customers = new List<Customer>();
                foreach (var cust in e.customerPort.Customer)
                {
                    customers.Add(
                        new Customer()
                        {
                            No = cust.No_,
                            Name = cust.Name,
                            Address = cust.Address,
                        }
                    );
                }

                if (LoadCustomerCompleted != null)
                {
                    LoadCustomerCompleted(this, new CustomerLoadedEventArgs(customers) { Error = e.Error });
                }
                blocked = false;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}