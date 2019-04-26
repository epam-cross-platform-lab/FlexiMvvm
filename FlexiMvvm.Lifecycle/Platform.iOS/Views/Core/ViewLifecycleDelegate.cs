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
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;
using UIKit;

namespace FlexiMvvm.Views.Core
{
    /// <summary>
    /// Base view lifecycle delegate. Responsible for keyboard handling.
    /// <para>This class is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    /// <typeparam name="TView">The type of the view that forwards its lifecycle calls.</typeparam>
    public class ViewLifecycleDelegate<TView> : IViewLifecycleDelegate
        where TView : class, IIosView
    {
        [Weak]
        private readonly TView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewLifecycleDelegate{TView}"/> class.
        /// </summary>
        /// <param name="view">The view that forwards its lifecycle calls to the delegate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <see langword="null"/>.</exception>
        public ViewLifecycleDelegate(TView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        /// <summary>
        /// Gets the view that forwards its lifecycle calls.
        /// </summary>
        protected TView View => _view;

        /// <inheritdoc />
        public virtual void WillMoveToParentViewController(UIViewController? parent)
        {
        }

        /// <inheritdoc />
        public virtual void ViewDidLoad()
        {
        }

        /// <inheritdoc />
        public virtual void ViewWillAppear()
        {
            View.KeyboardHandler?.RegisterForKeyboardNotifications();
        }

        /// <inheritdoc />
        public virtual void ViewDidAppear()
        {
        }

        /// <inheritdoc />
        public virtual void ViewWillDisappear()
        {
        }

        /// <inheritdoc />
        public virtual void ViewDidDisappear()
        {
            View.KeyboardHandler?.UnregisterFromKeyboardNotifications();
        }

        /// <inheritdoc />
        public virtual void DidMoveToParentViewController(UIViewController? parent)
        {
        }

        /// <inheritdoc />
        public virtual void SetResult(ResultCode resultCode, Result? result)
        {
        }

        /// <inheritdoc />
        public virtual void HandleResult(object sender, ResultSetEventArgs args)
        {
        }
    }

    /// <summary>
    /// A lifecycle delegate that is responsible for view model lifecycle.
    /// <para>This class is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    /// <typeparam name="TView">The type of the view that forwards its lifecycle calls.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public class ViewLifecycleDelegate<TView, TViewModel> : ViewLifecycleDelegate<TView>
        where TView : class, IIosView, INavigationView<TViewModel>, ILifecycleViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModel
    {
        private ResultCode _resultCode = ResultCode.Canceled;
        private Result? _result;
        private bool _isViewModelCreated;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewLifecycleDelegate{TView, TViewModel}"/> class.
        /// </summary>
        /// <param name="view">The view that forwards its lifecycle calls to the delegate.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The view model factory returned <see langword="null"/> value for the <typeparamref name="TViewModel"/>.</exception>
        public ViewLifecycleDelegate(TView view)
            : base(view)
        {
            var viewModelFactory = LifecycleViewModelProvider.GetFactory();
            var viewModel = viewModelFactory.Create<TViewModel>();

            if (viewModel == null)
            {
                throw new InvalidOperationException(
                    $"'{TypeFormatter.FormatName(viewModelFactory.GetType())}.{nameof(ILifecycleViewModelFactory.Create)}' " +
                    $"returned 'null' value for the '{TypeFormatter.FormatName<TViewModel>()}>' view model.");
            }

            _isViewModelCreated = true;

            View.SetViewModel(viewModel);
            ViewCache.Add(View);
        }

        /// <inheritdoc />
        public override void ViewWillAppear()
        {
            base.ViewWillAppear();

            if (_isViewModelCreated)
            {
                View.InitializeViewModelAsync(false);
                _isViewModelCreated = false;
            }
        }

        /// <inheritdoc />
        public override void ViewWillDisappear()
        {
            base.ViewWillDisappear();

            if (View.IsMovingFromParentViewController || View.IsBeingDismissed)
            {
                View.RaiseResultSet(_resultCode, _result);
            }
        }

        /// <inheritdoc />
        public override void SetResult(ResultCode resultCode, Result? result)
        {
            _resultCode = resultCode;
            _result = result;
        }

        /// <inheritdoc />
        public override void HandleResult(object sender, ResultSetEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (View.ViewModel is ILifecycleViewModelWithResultHandler viewModelWithResultHandler)
            {
                viewModelWithResultHandler.HandleResult(args.ResultCode, args.Result);
            }
        }
    }
}
