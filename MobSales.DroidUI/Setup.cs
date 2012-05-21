using System;
using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using Cirrious.MvvmCross.Android.Platform;
using Cirrious.MvvmCross.Application;
using Cirrious.MvvmCross.Binding.Android;
using Cirrious.MvvmCross.Interfaces.ServiceProvider;
using Cirrious.MvvmCross.Interfaces.ViewModels;

using MobSales.Logic;
using MobSales.Logic.ViewModels;

namespace MobSales.DroidUI
{
    public class Setup
        : MvxBaseAndroidBindingSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }
        
        protected override MvxApplication CreateApp()
        {
            var app = new App();
            return app;
        }
    }
}