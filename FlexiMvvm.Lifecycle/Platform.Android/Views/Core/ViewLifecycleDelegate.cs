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
using System.Threading.Tasks;
using Android.Content;
using Android.OS;
using FlexiMvvm.Persistence.Core;
using FlexiMvvm.ViewModels;
using FlexiMvvm.ViewModels.Core;

namespace FlexiMvvm.Views.Core
{
    /// <summary>
    /// Base view lifecycle delegate.
    /// <para>This class is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    /// <typeparam name="TView">The type of the view that forwards its lifecycle calls.</typeparam>
    public class ViewLifecycleDelegate<TView> : IViewLifecycleDelegate
        where TView : class, IAndroidView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewLifecycleDelegate{TView}"/> class.
        /// </summary>
        /// <param name="view">The view that forwards its lifecycle calls to the delegate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <see langword="null"/>.</exception>
        public ViewLifecycleDelegate(TView view)
        {
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <summary>
        /// Gets the view that forwards its lifecycle calls.
        /// </summary>
        protected TView View { get; }

        /// <inheritdoc />
        public virtual void OnCreate(Bundle? savedInstanceState)
        {
        }

        /// <inheritdoc />
        public virtual void OnStart()
        {
        }

        /// <inheritdoc />
        public virtual void OnResume()
        {
        }

        /// <inheritdoc />
        public virtual void OnPause()
        {
        }

        /// <inheritdoc />
        public virtual void OnStop()
        {
        }

        /// <inheritdoc />
        public virtual void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
        }

        /// <inheritdoc />
        public virtual void OnSaveInstanceState(Bundle outState)
        {
        }

        /// <inheritdoc />
        public virtual void OnDestroyView()
        {
        }

        /// <inheritdoc />
        public virtual void OnDestroy()
        {
        }
    }

    /// <summary>
    /// A lifecycle delegate that is responsible for view model lifecycle and persistence handling.
    /// <para>This class is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    /// <typeparam name="TView">The type of the view that forwards its lifecycle calls.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public class ViewLifecycleDelegate<TView, TViewModel> : ViewLifecycleDelegate<TView>
        where TView : class, IAndroidView, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModel, IStateOwner
    {
        private const string LifecycleViewModelKeyKey = "FlexiMvvm_LifecycleViewModel_Key";
        private const string LifecycleViewModelStateKey = "FlexiMvvm_LifecycleViewModel_State";
        private const string ViewRequestCodeStateKey = "FlexiMvvm_View_RequestCode_State";

        private bool _isViewRecreated;
        private string? _viewModelKey;
        private bool _isViewModelCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewLifecycleDelegate{TView, TViewModel}"/> class.
        /// </summary>
        /// <param name="view">The view that forwards its lifecycle calls to the delegate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <see langword="null"/>.</exception>
        public ViewLifecycleDelegate(TView view)
            : base(view)
        {
        }

        /// <inheritdoc />
        public override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _isViewRecreated = savedInstanceState != null;
            _viewModelKey = savedInstanceState?.GetString(LifecycleViewModelKeyKey) ?? Guid.NewGuid().ToString();
            var viewModelState = savedInstanceState?.GetState(LifecycleViewModelStateKey);
            var viewRequestCodeState = savedInstanceState?.GetState(ViewRequestCodeStateKey);

            var viewModelStore = LifecycleViewModelStoreProvider.Get(View);
            var viewModelFactory = LifecycleViewModelProvider.GetFactory();
            var viewModel = LifecycleViewModelProvider.Get<TViewModel>(viewModelStore!, _viewModelKey, viewModelFactory, viewModelState, out _isViewModelCreated);

            View.SetViewModel(viewModel);
            View.RequestCode.ImportState(viewRequestCodeState);
            ViewCache.Add(View);
        }

        /// <inheritdoc />
        public override void OnStart()
        {
            base.OnStart();

            if (_isViewModelCreated)
            {
                View.InitializeViewModelAsync(_isViewRecreated);
                _isViewModelCreated = false;
            }
        }

        /// <inheritdoc />
        public override void OnActivityResult(int requestCode, Android.App.Result resultCode, Intent? data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (View.ViewModel is ILifecycleViewModelWithResultHandler viewModelWithResultHandler)
            {
                var resultMapper = View.RequestCode.GetResultMapper(requestCode);

                if (resultMapper != null)
                {
                    viewModelWithResultHandler.HandleResult(resultCode, resultMapper.Map(data));
                }
            }
        }

        /// <inheritdoc />
        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);

            outState.PutString(LifecycleViewModelKeyKey, _viewModelKey);
            outState.PutState(LifecycleViewModelStateKey, View.ViewModel.ExportState());
            outState.PutState(ViewRequestCodeStateKey, View.RequestCode.ExportState());
        }

        /// <inheritdoc />
        public override void OnDestroy()
        {
            base.OnDestroy();

            var store = LifecycleViewModelStoreProvider.Get(View);

            if (store != null)
            {
                View.As(
                    activity =>
                    {
                        if (activity.IsFinishing)
                        {
                            store.Remove(_viewModelKey!);
                        }
                    },
                    fragment =>
                    {
                        if (fragment.IsRemoving)
                        {
                            store.Remove(_viewModelKey!);
                        }
                    });
            }

            ViewCache.Remove(View);
        }
    }
}
