using System;
using System.Collections.Generic;
using Android.OS;
using Android.Views;
using Android.App;
using Cirrious.MvvmCross.Android.Views;
using Cirrious.MvvmCross.Binding.Android.Binders;
using Cirrious.MvvmCross.Binding.Android.Interfaces.Views;
using Cirrious.MvvmCross.Interfaces.ViewModels;


namespace Cirrious.MvvmCross.Binding.Android.Views
{
    public abstract class MvxBindingFragmentActivityView<TViewModel>
        : MvxFragmentActivityView<TViewModel>
          , IMvxBindingActivity
        where TViewModel : class, IMvxViewModel
    {
        #region Code shared across all binding activities - I hate this cut and paste

        private readonly List<View> _boundViews = new List<View>();

        protected override void OnCreate(Bundle bundle)
        {
            ClearBoundViews();
            base.OnCreate(bundle);
        }

        protected override void OnDestroy()
        {
            ClearBoundViews();
            base.OnDestroy();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                ClearBoundViews();
            base.Dispose(disposing);
        }

        public void ClearBindings(View view)
        {
            if (view == null)
                return;

            var cleaner = new MvxBindingLayoutCleaner();
            cleaner.Clean(view);
            for (var i = 0; i < _boundViews.Count; i++)
            {
                if (_boundViews[i] == view)
                {
                    _boundViews.RemoveAt(i);
                    break;
                }
            }
        }

        private void ClearBoundViews()
        {
            var cleaner = new MvxBindingLayoutCleaner();
            _boundViews.ForEach(cleaner.Clean);
            _boundViews.Clear();
        }

        public override LayoutInflater LayoutInflater
        {
            get
            {
                return base.LayoutInflater;
            }
        }

        //public override LayoutInflater LayoutInflater
        //{
        //    get
        //    {
        //        throw new InvalidOperationException("LayoutInflater must not be accessed directly in MvxBindingFragmentView - use IMvxBindingFragment.BindingInflate or IMvxBindingFragment.NonBindingInflate instead");
        //    }
        //}

        public virtual object DefaultBindingSource
        {
            get { return ViewModel; }
        }

        public View BindingInflate(int resourceId, ViewGroup viewGroup)
        {
            var view = BindingInflate(DefaultBindingSource, resourceId, viewGroup);
            if (view != null)
                _boundViews.Add(view);
            return view;
        }

        public View BindingInflate(object source, int resourceId, ViewGroup viewGroup)
        {
            return CommonInflate(
                resourceId,
                viewGroup,
                (layoutInflator) => new MvxBindingLayoutInflatorFactory(source, layoutInflator));
        }

        public View NonBindingInflate(int resourceId, ViewGroup viewGroup)
        {
            return CommonInflate(
                resourceId,
                viewGroup,
                (layoutInflator) => null);
        }

        public override void SetContentView(int layoutResId)
        {
            var view = BindingInflate(layoutResId, null);
            base.SetContentView(view);
        }

        private View CommonInflate(int resourceId, ViewGroup viewGroup, Func<LayoutInflater, MvxBindingLayoutInflatorFactory> factoryProvider)
        {
            var layoutInflator = this.LayoutInflater;
            using (var clone = layoutInflator.CloneInContext(this))
            {
                using (var factory = factoryProvider(clone))
                {
                    if (factory != null)
                        clone.Factory = factory;
                    var toReturn = clone.Inflate(resourceId, viewGroup);
                    if (factory != null)
                    {
                        factory.StoreBindings(toReturn);
                    }
                    return toReturn;
                }
            }
        }

        #endregion
    }
}