// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Views.V4
{
    [Register("fleximvvm.views.v4.FlxFragment")]
    public class FlxFragment : Fragment, IFlxFragment
    {
        [CanBeNull]
        private IViewDelegate<FlxFragment> _viewDelegate;

        public event EventHandler OnActivityCreatedCalled;

        public event EventHandler OnStartCalled;

        public event EventHandler OnResumeCalled;

        public event EventHandler OnPauseCalled;

        public event EventHandler OnStopCalled;

        public event EventHandler<OptionsItemSelectedEventArgs> OnOptionsItemSelectedCalled;

        [NotNull]
        protected IViewDelegate<FlxFragment> ViewDelegate => _viewDelegate ?? (_viewDelegate = CreateViewDelegate());

        [NotNull]
        protected virtual IViewDelegate<FlxFragment> CreateViewDelegate()
        {
            return new ViewDelegate<FlxFragment>(this);
        }

        public override void OnCreate([CanBeNull] Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ViewDelegate.OnCreate(savedInstanceState);
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            ViewDelegate.OnActivityCreated();
            OnActivityCreatedCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void OnStart()
        {
            base.OnStart();

            ViewDelegate.OnStart();
            OnStartCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void OnResume()
        {
            base.OnResume();

            ViewDelegate.OnResume();
            OnResumeCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void OnPause()
        {
            base.OnPause();

            ViewDelegate.OnPause();
            OnPauseCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void OnStop()
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

        public override void OnActivityResult(int requestCode, int resultCode, [CanBeNull] Intent data)
        {
            ViewDelegate.OnActivityResult(requestCode, (Android.App.Result)resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        public override void OnSaveInstanceState([NotNull] Bundle outState)
        {
            ViewDelegate.OnSaveInstanceState(outState);

            base.OnSaveInstanceState(outState);
        }

        public override void OnDestroyView()
        {
            ViewDelegate.OnDestroyView();

            base.OnDestroyView();
        }

        public override void OnDestroy()
        {
            ViewDelegate.OnDestroy();

            base.OnDestroy();
        }
    }

    public class FlxFragment<TViewModel> : FlxFragment, IFlxFragment<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters, IViewModelWithState
    {
        [NotNull]
        private new IViewDelegate<FlxFragment<TViewModel>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxFragment<TViewModel>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        public Android.App.FragmentManager GetFragmentManager()
        {
            return Activity.NotNull().FragmentManager.NotNull();
        }

        protected override IViewDelegate<FlxFragment> CreateViewDelegate()
        {
            return new ViewDelegate<FlxFragment<TViewModel>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize();
        }
    }

    public class FlxFragment<TViewModel, TParameters> : FlxFragment, IFlxFragment<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>, IViewModelWithState
        where TParameters : ViewModelParametersBase
    {
        [NotNull]
        private new IViewDelegate<FlxFragment<TViewModel, TParameters>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxFragment<TViewModel, TParameters>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        public Android.App.FragmentManager GetFragmentManager()
        {
            return Activity.NotNull().FragmentManager.NotNull();
        }

        protected override IViewDelegate<FlxFragment> CreateViewDelegate()
        {
            return new ViewDelegate<FlxFragment<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize(Arguments.GetViewModelParameters<TParameters>());
        }
    }
}
