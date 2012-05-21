using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using Cirrious.MvvmCross.Binding.Android.Views;
using Cirrious.MvvmCross.Android.Views;
using MobSales.Logic.ViewModels;

namespace MobSales.DroidUI.Views.Fragments
{
    public class TitlesFragment : Fragment//<CustomersViewModel>
    {
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
        }

        public override View  OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            View fragmentView = p0.Inflate(Resource.Layout.InserimentoOdV, p1, false);
            return fragmentView;
        }

        //protected override void OnViewModelSet() { }
    }
}