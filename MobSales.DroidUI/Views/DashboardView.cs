﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Android.Views;
using Cirrious.MvvmCross.Binding.Android.Views;
using MobSales.Logic.ViewModels;

namespace MobSales.DroidUI.Views
{
    [Activity(Label = "MobSales Dashboard", WindowSoftInputMode = SoftInput.AdjustPan/*, ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape*/)]
    public class DashboardView : MvxBindingFragmentActivityView<DashboardViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //SetContentView(Resource.Layout.test_frag);
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.test_frag);
            FragmentManager fragManager = this.FragmentManager;
            FragmentTransaction transaction = fragManager.BeginTransaction();

            Fragments.TitlesFragment titles= new Fragments.TitlesFragment();
            transaction.Replace(Resource.Id.frag_title, titles);
            transaction.Commit();
            //BindingInflate(Resource.Layout.test_frag, (ViewGroup)this);
        }

    }
}

