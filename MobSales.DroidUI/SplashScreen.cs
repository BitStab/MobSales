using Android.App;
using Cirrious.MvvmCross.Android.Platform;
using Cirrious.MvvmCross.Android.Views;

namespace MobSales.DroidUI
{
    [Activity(Label = "MobSales.DroidUI", MainLauncher = true, Icon = "@drawable/icon", NoHistory=true, ScreenOrientation=Android.Content.PM.ScreenOrientation.Landscape)]
    public class SplashScreen : MvxBaseSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        //protected override MvxBaseAndroidSetup CreateSetup()
        //{
        //    return new Setup(ApplicationContext);
        //}
    }
}
