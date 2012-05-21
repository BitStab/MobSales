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
    public class ItemViewModel:MvxViewModel
    {
        private Item _item;

        public ItemViewModel() { }

        public ItemViewModel(Item item)
        {
            this._item = item;
        }

        public string No
        {
            get { return _item.No; }
            set{
                _item.No=value;
                FirePropertyChanged("No");
            }
        }
        public string Description
        {
            get { return _item.Description; }
            set
            {
                _item.Description = value;
                FirePropertyChanged("Description");
            }
        }
        public string Listprice
        {
            get { return _item.Listprice; }
            set
            {
                _item.Listprice = value;
                FirePropertyChanged("Listprice");
            }
        }
        public string Unitprice
        {
            get { return _item.Unitprice; }
            set
            {
                _item.Unitprice = value;
                FirePropertyChanged("Unitprice");
            }
        }
        public string Unitofmeasure
        {
            get { return _item.Unitofmeasure; }
            set
            {
                _item.Unitofmeasure = value;
                FirePropertyChanged("Unitofmeasure");
            }
        }
        public string Quantity
        {
            get { return _item.Quantity; }
            set
            {
                _item.Quantity = value;
                FirePropertyChanged("Quantity");
            }
        }
        public string Discount
        {
            get { return _item.Discount; }
            set
            {
                _item.Discount = value;
                FirePropertyChanged("Discount");
            }
        }
        public string Endprice
        {
            get { return _item.Endprice; }
            set
            {
                _item.Endprice = value;
                FirePropertyChanged("Endprice");
            }
        }
        public int Id
        {
            get { return _item.Id; }
            set
            {
                _item.Id = value;
                FirePropertyChanged("Id");
            }
        }

        public IMvxCommand ViewDetailCommand
        {
            get { return new MvxRelayCommand(() => RequestNavigate<ItemsViewModel>()); }
        }
    }
}