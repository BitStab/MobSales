using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class ItemsViewModel : MvxViewModel, IMvxServiceConsumer<ICustomerService>, IMvxServiceConsumer<IErrorReporter>
    {
    }
}