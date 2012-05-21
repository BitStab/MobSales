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
    public class DashboardViewModel : MvxViewModel, IMvxServiceConsumer<IErrorReporter>
    {

        IErrorReporter errorReport;
        public DashboardViewModel()
        {
            try
            {
                this.errorReport = this.GetService<IErrorReporter>();
            }
            catch (Exception err)
            {

            }
        }

        public void ReportError(string error)
        {
            this.GetService<IErrorReporter>().ReportError(error);
        }
    }
}