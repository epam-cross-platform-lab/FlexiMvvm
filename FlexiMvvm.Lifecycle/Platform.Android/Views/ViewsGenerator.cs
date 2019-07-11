﻿// <auto-generated />
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

#nullable enable

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using FlexiMvvm.Persistence.Core;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Represents a/an <see cref="Android.Support.V7.App.AppCompatActivity"/> that is adapted for use with the FlexiMvvm.
    /// </summary>
    [Register("fleximvvm.views.AppCompatActivity")]
    public partial class AppCompatActivity : Android.Support.V7.App.AppCompatActivity, IAndroidView, IOptionsMenuSource
    {
        private IViewLifecycleDelegate? _lifecycleDelegate;

        /// <inheritdoc />
        public AppCompatActivity()
        {
        }

        /// <inheritdoc />
        protected AppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public event EventHandler<OptionsItemSelectedEventArgs> OnOptionsItemSelectedCalled;

        /// <summary>
        /// Gets the view lifecycle delegate. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected IViewLifecycleDelegate LifecycleDelegate => _lifecycleDelegate ??= CreateLifecycleDelegate();

        /// <summary>
        /// Creates a new <see cref="IViewLifecycleDelegate"/> instance. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected virtual IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<AppCompatActivity>(this);
        }

        /// <inheritdoc />
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LifecycleDelegate.OnCreate(savedInstanceState);
        }

        /// <inheritdoc />
        protected override void OnStart()
        {
            base.OnStart();

            LifecycleDelegate.OnStart();
        }

        /// <inheritdoc />
        protected override void OnResume()
        {
            base.OnResume();

            LifecycleDelegate.OnResume();
        }

        /// <inheritdoc />
        protected override void OnPause()
        {
            base.OnPause();

            LifecycleDelegate.OnPause();
        }

        /// <inheritdoc />
        protected override void OnStop()
        {
            base.OnStop();

            LifecycleDelegate.OnStop();
        }

        /// <inheritdoc />
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var optionsItemSelectedEventArgs = new OptionsItemSelectedEventArgs(item);
            OnOptionsItemSelectedCalled?.Invoke(this, optionsItemSelectedEventArgs);

            if (optionsItemSelectedEventArgs.Handled)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        /// <inheritdoc />
        protected override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            LifecycleDelegate.OnActivityResult(requestCode, (Android.App.Result)resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        /// <inheritdoc />
        protected override void OnSaveInstanceState(Bundle outState)
        {
            LifecycleDelegate.OnSaveInstanceState(outState);

            base.OnSaveInstanceState(outState);
        }

        /// <inheritdoc />
        protected override void OnDestroy()
        {
            LifecycleDelegate.OnDestroy();

            base.OnDestroy();
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V7.App.AppCompatActivity"/> that is adapted for use with the FlexiMvvm
    /// and has its own lifecycle-aware view model.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class AppCompatActivity<TViewModel> : AppCompatActivity, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithoutParameters, IStateOwner
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public AppCompatActivity()
        {
        }

        /// <inheritdoc />
        protected AppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<AppCompatActivity<TViewModel>, TViewModel>(this);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (Android.App.Result)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(recreated);
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V7.App.AppCompatActivity"/> that is adapted for use with the FlexiMvvm,
    /// has its own lifecycle-aware view model and takes lifecycle-aware view model parameters.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class AppCompatActivity<TViewModel, TParameters> : AppCompatActivity, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public AppCompatActivity()
        {
        }

        /// <inheritdoc />
        protected AppCompatActivity(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<AppCompatActivity<TViewModel, TParameters>, TViewModel>(this);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (Android.App.Result)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(Intent?.GetParameters<TParameters>(), recreated);
        }
    }
}


namespace FlexiMvvm.Views
{
    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.DialogFragment"/> that is adapted for use with the FlexiMvvm.
    /// </summary>
    [Register("fleximvvm.views.DialogFragment")]
    public partial class DialogFragment : Android.Support.V4.App.DialogFragment, IAndroidView, IOptionsMenuSource
    {
        private IViewLifecycleDelegate? _lifecycleDelegate;

        /// <inheritdoc />
        public DialogFragment()
        {
            SetTargetFragment(null, RequestCode.InvalidRequestCode);
        }

        /// <inheritdoc />
        protected DialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public event EventHandler<OptionsItemSelectedEventArgs> OnOptionsItemSelectedCalled;

        /// <summary>
        /// Gets the view lifecycle delegate. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected IViewLifecycleDelegate LifecycleDelegate => _lifecycleDelegate ??= CreateLifecycleDelegate();

        /// <summary>
        /// Creates a new <see cref="IViewLifecycleDelegate"/> instance. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected virtual IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<DialogFragment>(this);
        }

        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LifecycleDelegate.OnCreate(savedInstanceState);
        }

        /// <inheritdoc />
        public override void OnStart()
        {
            base.OnStart();

            LifecycleDelegate.OnStart();
        }

        /// <inheritdoc />
        public override void OnResume()
        {
            base.OnResume();

            LifecycleDelegate.OnResume();
        }

        /// <inheritdoc />
        public override void OnDismiss(IDialogInterface dialog)
        {
            base.OnDismiss(dialog);

            LifecycleDelegate.OnDismiss();
        }

        /// <inheritdoc />
        public override void OnPause()
        {
            base.OnPause();

            LifecycleDelegate.OnPause();
        }

        /// <inheritdoc />
        public override void OnStop()
        {
            base.OnStop();

            LifecycleDelegate.OnStop();
        }

        /// <inheritdoc />
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var optionsItemSelectedEventArgs = new OptionsItemSelectedEventArgs(item);
            OnOptionsItemSelectedCalled?.Invoke(this, optionsItemSelectedEventArgs);

            if (optionsItemSelectedEventArgs.Handled)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        /// <inheritdoc />
        public override void OnActivityResult(int requestCode, int resultCode, Intent? data)
        {
            LifecycleDelegate.OnActivityResult(requestCode, (Android.App.Result)resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        /// <inheritdoc />
        public override void OnSaveInstanceState(Bundle outState)
        {
            LifecycleDelegate.OnSaveInstanceState(outState);

            base.OnSaveInstanceState(outState);
        }

        /// <inheritdoc />
        public override void OnDestroyView()
        {
            LifecycleDelegate.OnDestroyView();

            base.OnDestroyView();
        }

        /// <inheritdoc />
        public override void OnDestroy()
        {
            LifecycleDelegate.OnDestroy();

            base.OnDestroy();
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.DialogFragment"/> that is adapted for use with the FlexiMvvm
    /// and has its own lifecycle-aware view model.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class DialogFragment<TViewModel> : DialogFragment, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithoutParameters, IStateOwner
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public DialogFragment()
        {
        }

        /// <inheritdoc />
        protected DialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<DialogFragment<TViewModel>, TViewModel>(this);
        }

        /// <inheritdoc />
        public void SetResult(Android.App.Result resultCode, Intent? data)
        {
            LifecycleDelegate.SetResult(resultCode, data);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (int)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(recreated);
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.DialogFragment"/> that is adapted for use with the FlexiMvvm,
    /// has its own lifecycle-aware view model and takes lifecycle-aware view model parameters.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class DialogFragment<TViewModel, TParameters> : DialogFragment, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public DialogFragment()
        {
        }

        /// <inheritdoc />
        protected DialogFragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<DialogFragment<TViewModel, TParameters>, TViewModel>(this);
        }

        /// <inheritdoc />
        public void SetResult(Android.App.Result resultCode, Intent? data)
        {
            LifecycleDelegate.SetResult(resultCode, data);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (int)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(Arguments?.GetParameters<TParameters>(), recreated);
        }
    }
}


namespace FlexiMvvm.Views
{
    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.Fragment"/> that is adapted for use with the FlexiMvvm.
    /// </summary>
    [Register("fleximvvm.views.Fragment")]
    public partial class Fragment : Android.Support.V4.App.Fragment, IAndroidView, IOptionsMenuSource
    {
        private IViewLifecycleDelegate? _lifecycleDelegate;

        /// <inheritdoc />
        public Fragment()
        {
            SetTargetFragment(null, RequestCode.InvalidRequestCode);
        }

        /// <inheritdoc />
        protected Fragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public event EventHandler<OptionsItemSelectedEventArgs> OnOptionsItemSelectedCalled;

        /// <summary>
        /// Gets the view lifecycle delegate. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected IViewLifecycleDelegate LifecycleDelegate => _lifecycleDelegate ??= CreateLifecycleDelegate();

        /// <summary>
        /// Creates a new <see cref="IViewLifecycleDelegate"/> instance. Intended for internal use by the FlexiMvvm.
        /// </summary>
        protected virtual IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<Fragment>(this);
        }

        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            LifecycleDelegate.OnCreate(savedInstanceState);
        }

        /// <inheritdoc />
        public override void OnStart()
        {
            base.OnStart();

            LifecycleDelegate.OnStart();
        }

        /// <inheritdoc />
        public override void OnResume()
        {
            base.OnResume();

            LifecycleDelegate.OnResume();
        }

        /// <inheritdoc />
        public override void OnPause()
        {
            base.OnPause();

            LifecycleDelegate.OnPause();
        }

        /// <inheritdoc />
        public override void OnStop()
        {
            base.OnStop();

            LifecycleDelegate.OnStop();
        }

        /// <inheritdoc />
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            var optionsItemSelectedEventArgs = new OptionsItemSelectedEventArgs(item);
            OnOptionsItemSelectedCalled?.Invoke(this, optionsItemSelectedEventArgs);

            if (optionsItemSelectedEventArgs.Handled)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        /// <inheritdoc />
        public override void OnActivityResult(int requestCode, int resultCode, Intent? data)
        {
            LifecycleDelegate.OnActivityResult(requestCode, (Android.App.Result)resultCode, data);

            base.OnActivityResult(requestCode, resultCode, data);
        }

        /// <inheritdoc />
        public override void OnSaveInstanceState(Bundle outState)
        {
            LifecycleDelegate.OnSaveInstanceState(outState);

            base.OnSaveInstanceState(outState);
        }

        /// <inheritdoc />
        public override void OnDestroyView()
        {
            LifecycleDelegate.OnDestroyView();

            base.OnDestroyView();
        }

        /// <inheritdoc />
        public override void OnDestroy()
        {
            LifecycleDelegate.OnDestroy();

            base.OnDestroy();
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.Fragment"/> that is adapted for use with the FlexiMvvm
    /// and has its own lifecycle-aware view model.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class Fragment<TViewModel> : Fragment, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithoutParameters, IStateOwner
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public Fragment()
        {
        }

        /// <inheritdoc />
        protected Fragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<Fragment<TViewModel>, TViewModel>(this);
        }

        /// <inheritdoc />
        public void SetResult(Android.App.Result resultCode, Intent? data)
        {
            LifecycleDelegate.SetResult(resultCode, data);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (int)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(recreated);
        }
    }

    /// <summary>
    /// Represents a/an <see cref="Android.Support.V4.App.Fragment"/> that is adapted for use with the FlexiMvvm,
    /// has its own lifecycle-aware view model and takes lifecycle-aware view model parameters.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    [SuppressMessage(
        "Compiler",
        "CS8618:Non-nullable field is uninitialized.",
        Justification = "The view lifecycle delegate sets a value to the ViewModel property so it is not null starting from OnCreate method.")]
    public partial class Fragment<TViewModel, TParameters> : Fragment, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithParameters<TParameters>, IStateOwner
        where TParameters : Parameters
    {
        private RequestCode? _requestCode;

        /// <inheritdoc />
        public Fragment()
        {
        }

        /// <inheritdoc />
        protected Fragment(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {
        }

        /// <inheritdoc />
        public TViewModel ViewModel { get; private set; }

        /// <inheritdoc />
        public RequestCode RequestCode => _requestCode ??= new RequestCode();

        /// <inheritdoc />
        protected override IViewLifecycleDelegate CreateLifecycleDelegate()
        {
            return new ViewLifecycleDelegate<Fragment<TViewModel, TParameters>, TViewModel>(this);
        }

        /// <inheritdoc />
        public void SetResult(Android.App.Result resultCode, Intent? data)
        {
            LifecycleDelegate.SetResult(resultCode, data);
        }

        /// <inheritdoc />
        void INavigationView<TViewModel>.OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            OnActivityResult(requestCode, (int)resultCode, data);
        }

        void ILifecycleViewModelOwner<TViewModel>.SetViewModel(TViewModel viewModel)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
        }

        async Task ILifecycleViewModelOwner<TViewModel>.InitializeViewModelAsync(bool recreated)
        {
            await ViewModel.InitializeAsync(Arguments?.GetParameters<TParameters>(), recreated);
        }
    }
}

#nullable restore

