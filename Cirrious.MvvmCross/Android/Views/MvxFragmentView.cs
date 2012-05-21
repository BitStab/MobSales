using System;
using Android.Views;
using Android.Widget;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.App;
using Cirrious.MvvmCross.Android.ExtensionMethods;
using Cirrious.MvvmCross.Android.Interfaces;
using Cirrious.MvvmCross.Interfaces.ViewModels;
using Cirrious.MvvmCross.Platform.Diagnostics;

namespace Cirrious.MvvmCross.Android.Views
{
    public abstract class MvxFragmentView<TViewModel> 
        : Fragment
        , IMvxAndroidView<TViewModel> 
        where TViewModel : class, IMvxViewModel
    {
    protected MvxFragmentView()
        {
            IsVisible = true;
        }

        public MvxFragmentView(Context context, IAttributeSet attrs)
            : base()
        {
        }

        #region Common code across all android views - one case for multiple inheritance?

        private TViewModel _viewModel;

        public Type ViewModelType
        {
            get { return typeof(TViewModel); }
        }

        public bool IsVisible { get; private set; }

        public TViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                this.OnViewModelSet();
            }
        }

        public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
        {
            this.Activity.StartActivityForResult(intent, requestCode);
        }

        protected abstract void OnViewModelSet();

        public event EventHandler<MvxIntentResultEventArgs> MvxIntentResultReceived;

        public override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.OnViewCreate(true);
        }

        public override void OnDestroy()
        {
            this.OnViewDestroy();
            base.OnDestroy();
        }

        public override View OnCreateView(LayoutInflater p0, ViewGroup p1, Bundle p2)
        {
            return base.OnCreateView(p0, p1, p2);
        }

        public override void OnResume()
        {
            base.OnResume();
            IsVisible = true;
            this.OnViewResume();
        }

        public override void OnPause()
        {
            this.OnViewPause();
            IsVisible = false;
            base.OnPause();
        }

        public override void OnStart()
        {
            base.OnStart();
            this.OnViewStart();
        }

        //protected override void OnRestart()
        //{
        //    base.OnResume
        //    this.OnViewRestart();
        //}

        public override void OnStop()
        {
            this.OnViewStop();
            base.OnStop();
        }
        
        public override void StartActivityForResult(Intent intent, int requestCode)
        {
            switch (requestCode)
            {
                case (int)MvxIntentRequestCode.PickFromFile:
                    MvxTrace.Trace("Warning - activity request code may clash with Mvx code for {0}", (MvxIntentRequestCode)requestCode);
                    break;
                default:
                    // ok...
                    break;
            }
            base.StartActivityForResult(intent, requestCode);
        }

        public override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            //Result code = (Result)resultCode;
            var handler = MvxIntentResultReceived;
            if (handler != null)
                handler(this, new MvxIntentResultEventArgs(requestCode,resultCode, data));
            base.OnActivityResult(requestCode, resultCode, data);
        }

        #endregion
    }
}