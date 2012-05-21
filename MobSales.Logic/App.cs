using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.ExtensionMethods;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Android.Platform;
using Cirrious.MvvmCross.Binding.Android;
using MobSales.Logic.Model;
using MobSales.Logic.DataService;

namespace MobSales.Logic
{

    public interface IErrorReporter
    {
        void ReportError(string error);
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; private set; }

        public ErrorEventArgs(string message)
        {
            Message = message;
        }
    }

    public interface IErrorSource
    {
        event EventHandler<ErrorEventArgs> ErrorReported;
    }

    public class ErrorApplicationObject
        : MvxApplicationObject
        , IErrorReporter
        , IErrorSource
    {
        public void ReportError(string error)
        {
            if (ErrorReported == null)
                return;

            InvokeOnMainThread(() =>
            {
                var handler = ErrorReported;
                if (handler != null)
                    handler(this, new ErrorEventArgs(error));
            });
        }

        public event EventHandler<ErrorEventArgs> ErrorReported;
    }

    public class App
        : MvxApplication
        , IMvxServiceProducer<IMvxStartNavigation>
        , IMvxServiceProducer<ICustomerService>
        , IMvxServiceProducer<IErrorReporter>
        , IMvxServiceProducer<IErrorSource>
    {
        public App()
        {
            // set up the model
            var dataStore = new CustomerService();
            this.RegisterServiceInstance<ICustomerService>(dataStore);

            // set the start object
            var startApplicationObject = new StartApplicationObject();
            var errorApplicationObject = new ErrorApplicationObject();
            this.RegisterServiceInstance<IErrorReporter>(errorApplicationObject);
            this.RegisterServiceInstance<IErrorSource>(errorApplicationObject);
            this.RegisterServiceInstance<IMvxStartNavigation>(startApplicationObject);
        }
    }
}