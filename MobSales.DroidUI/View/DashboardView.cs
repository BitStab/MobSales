using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Android.Views;
using Cirrious.MvvmCross.Binding.Android.Views;
using MobSales.Logic.ViewModels;

namespace MobSales.DroidUI
{
    [Activity(Label = "MobSales Dashboard", WindowSoftInputMode = SoftInput.AdjustPan/*, ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape*/)]
    public class DashboardView : MvxBindingActivityView<DashboardViewModel>
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.test_frag);
        }

        protected override void OnViewModelSet()
        {
            //SetContentView(Resource.Layout.test_frag);
            //BindingInflate(Resource.Layout.test_frag, (ViewGroup)this);
        }

    }
}

