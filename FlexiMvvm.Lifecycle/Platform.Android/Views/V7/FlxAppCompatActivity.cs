// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =========================================================================

using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.V7
{
    [Register("fleximvvm.views.v7.FlxAppCompatActivity")]
    public class FlxAppCompatActivity : AppCompatActivity, IFlxActivity
    {
        [CanBeNull]
        private IViewDelegate<FlxAppCompatActivity> _viewDelegate;

        public event EventHandler OnStartCalled;

        public event EventHandler OnResumeCalled;

        public event EventHandler OnPauseCalled;

        public event EventHandler OnStopCalled;

        public event EventHandler<OptionsItemSelectedEventArgs> OnOptionsItemSelectedCalled;

        public event EventHandler<BackPressedEventArgs> OnBackPressedCalled;

        [NotNull]
        protected IViewDelegate<FlxAppCompatActivity> ViewDelegate => _viewDelegate ?? (_viewDelegate = CreateViewDelegate());

        [NotNull]
        protected virtual IViewDelegate<FlxAppCompatActivity> CreateViewDelegate()
        {
            return new ViewDelegate<FlxAppCompatActivity>(this);
        }

        protected override void OnCreate([CanBeNull] Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewDelegate.OnCreate(savedInstanceState);
        }

        protected override void OnStart()
        {
            base.OnStart();

            ViewDelegate.OnStart();
            OnStartCalled?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnResume()
        {
            base.OnResume();

            ViewDelegate.OnResume();
            OnResumeCalled?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnPause()
        {
            base.OnPause();

            ViewDelegate.OnPause();
            OnPauseCalled?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnStop()
        {
            base.OnStop();

            ViewDelegate.OnStop();
            OnStopCalled?.Invoke(this, EventArgs.Empty);
        }

        public override bool OnOptionsItemSelected([NotNull] IMenuItem item)
        {
            var optionsItemSelectedEventArgs = new OptionsItemSelectedEventArgs(item);
            OnOptionsItemSelectedCalled?.Invoke(this, optionsItemSelectedEventArgs);

            if (optionsItemSelectedEventArgs.Handled)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        public override void OnBackPressed()
        {
            var backPressedEventArgs = new BackPressedEventArgs();
            OnBackPressedCalled?.Invoke(this, backPressedEventArgs);

            if (!backPressedEventArgs.Handled)
            {
                base.OnBackPressed();
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, [CanBeNull] Intent data)
        {
            ViewDelegate.OnActivityResult(requestCode, resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnSaveInstanceState([NotNull] Bundle outState)
        {
            ViewDelegate.OnSaveInstanceState(outState);

            base.OnSaveInstanceState(outState);
        }

        protected override void OnDestroy()
        {
            ViewDelegate.OnDestroy();

            base.OnDestroy();
        }
    }

    public class FlxAppCompatActivity<TViewModel> : FlxAppCompatActivity, IFlxActivity<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters, IViewModelWithState
    {
        [NotNull]
        private new IViewDelegate<FlxAppCompatActivity<TViewModel>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxAppCompatActivity<TViewModel>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        public FragmentManager GetFragmentManager()
        {
            return FragmentManager.NotNull();
        }

        protected override IViewDelegate<FlxAppCompatActivity> CreateViewDelegate()
        {
            return new ViewDelegate<FlxAppCompatActivity<TViewModel>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize();
        }
    }

    public class FlxAppCompatActivity<TViewModel, TParameters> : FlxAppCompatActivity, IFlxActivity<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>, IViewModelWithState
        where TParameters : ViewModelParametersBase
    {
        [NotNull]
        private new IViewDelegate<FlxAppCompatActivity<TViewModel, TParameters>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxAppCompatActivity<TViewModel, TParameters>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        public FragmentManager GetFragmentManager()
        {
            return FragmentManager.NotNull();
        }

        protected override IViewDelegate<FlxAppCompatActivity> CreateViewDelegate()
        {
            return new ViewDelegate<FlxAppCompatActivity<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize(Intent.GetViewModelParameters<TParameters>());
        }
    }
}
