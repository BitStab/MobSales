using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using MobSales.Logic.DataService;
using MobSales.Logic.Base;
using MobSales.Logic.Model;

namespace MobSales.Logic.ViewModels
{
    public class CustomersViewModel:MvxViewModel, IMvxServiceConsumer<ICustomerService>, IMvxServiceConsumer<IErrorReporter>//, INotifyPropertyChanged
    {
        ICustomerService custService;
        IErrorReporter errorReport;
        private bool blocked = false;

        public CustomersViewModel()
        {
            try
            {
                this.errorReport = this.GetService<IErrorReporter>();
                this.custService = this.GetService<ICustomerService>();
            }
            catch (Exception err)
            {
                
            }
            if (custService != null)
            {
                this.custService.init();
                custService.LoadCustomerCompleted += new EventHandler<CustomerLoadedEventArgs>(custService_LoadCustomerCompleted);
            }
            loadCustomerCommand = new MvxRelayCommand(LoadCustomer);
            //loadCustomerCommand.Execute();
        }

        public void ReportError(string error)
        {
            this.GetService<IErrorReporter>().ReportError(error);
        }

        private List<CustomerViewModel> customers;
        public List<CustomerViewModel> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                FirePropertyChanged("Customers");
            }
        }

        private CustomerViewModel customer;
        public CustomerViewModel Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                FirePropertyChanged("Customer");
            }
        }

        private MvxRelayCommand loadCustomerCommand;

        public MvxRelayCommand LoadCustomerCommand
        {
            get { return loadCustomerCommand; }
        }

        public void LoadCustomer()
        {
            if (!blocked)
            {
                blocked = true;
                try
                {
                    custService.LoadCustomer(this._enteredText);
                }
                catch (Exception e)
                {
                    ReportError("Sorry - an error occured" + e.Message);
                }
            }
        }

        void custService_LoadCustomerCompleted(object sender, CustomerLoadedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    return;
                }

                List<CustomerViewModel> loadedCustomers = new List<CustomerViewModel>();
                foreach (var cust in e.Customers)
                {
                    loadedCustomers.Add(new CustomerViewModel(cust));
                }
                Customers = new List<CustomerViewModel>(loadedCustomers);
                blocked = false;
            }
            catch (Exception err)
            {
                ReportError("Sorry - an error occured" + err.Message);
            }
        }


        private string _currentTextHint;
        public string CurrentTextHint
        {
            get { return _currentTextHint; }
            set
            {
                _currentTextHint = value;
                if (_currentTextHint == null
                    || _currentTextHint.Trim().Length < 2)
                {
                    SetSuggestionsEmpty();
                    return;
                }

                LoadCustomer();
            }
        }

        private string _enteredText;
        public string EnteredText
        {
            get { return _enteredText; }
            private set { _enteredText = value; FirePropertyChanged("EnteredText"); }
        }

        private CustomerViewModel _currentCust;
        public CustomerViewModel CurrentCust
        {
            get { return _currentCust; }
            set { _currentCust = value; FirePropertyChanged("CurrentCustomer"); }
        }

        private void SetSuggestionsEmpty()
        {
            Customers = new List<CustomerViewModel>();
        }


        //#region INotifyPropertyChanged

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void FirePropertyChanged(string whichProperty)
        //{
        //    // take a copy - see RoadWarrior's answer on http://stackoverflow.com/questions/282653/checking-for-null-before-event-dispatching-thread-safe/282741#282741
        //    var handler = PropertyChanged;

        //    if (handler != null)
        //        handler(this, new PropertyChangedEventArgs(whichProperty));
        //}

        //#endregion
    }
}