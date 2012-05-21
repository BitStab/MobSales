using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Cirrious.MvvmCross.Commands;
using Cirrious.MvvmCross.Interfaces.Commands;
using Cirrious.MvvmCross.ShortNames;
using Cirrious.MvvmCross.ViewModels;
using MobSales.Logic.Model;
using MobSales.Logic.ViewModels;

namespace MobSales.Logic.ViewModels
{
    public class CustomerViewModel:MvxViewModel
    {
        private Customer _cust;

        public CustomerViewModel()
        {
        
        }

        public CustomerViewModel(Customer cust)
        {
            this._cust = cust;
        }

        public string No
        {
            get { return _cust.No; }
            set
            {
                _cust.No = value;
                FirePropertyChanged("No");
            }
        }

        public string Name
        {
            get { return _cust.Name; }
            set
            {
                _cust.Name = value;
                FirePropertyChanged("Name");
            }
        }

        public string Address
        {
            get { return _cust.Address; }
            set
            {
                _cust.No = value;
                FirePropertyChanged("Address");
            }
        }

        public string Post_Code
        {
            get { return _cust.Post_Code; }
            set
            {
                _cust.No = value;
                FirePropertyChanged("Post_Code");
            }
        }

        public IMvxCommand ViewDetailCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<CustomersViewModel>()); }
        }

        public override string ToString()
        {
            string objectString = No + " " + Name;
            return objectString;
        }
    }
}
