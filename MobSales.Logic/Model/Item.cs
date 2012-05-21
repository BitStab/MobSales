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

namespace MobSales.Logic.Model
{
    public class Item
    {
        public string No { get; set; }
        public string Description { get; set; }
        public string Listprice { get; set; }
        public string Unitprice { get; set; }
        public string Unitofmeasure { get; set; }
        public string Quantity { get; set; }
        public string Discount { get; set; }
        public string Endprice { get; set; }
        public int Id { get; set; }

        public Item(Item _item) 
        {
            this.No = _item.No;
            this.Description = _item.Description;
            this.Listprice = _item.Listprice;
            this.Unitprice = _item.Unitprice;
            this.Unitofmeasure = _item.Unitofmeasure;
            this.Quantity = _item.Quantity;
            this.Discount = _item.Discount;
            this.Endprice = _item.Endprice;
            this.Id = _item.Id;
        }

        public override string ToString()
        {
            return (this.No + " " + this.Description);
        }
    }
}