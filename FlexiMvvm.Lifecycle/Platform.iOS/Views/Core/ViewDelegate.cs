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
using System.Diagnostics;
using FlexiMvvm.Diagnostics;
using FlexiMvvm.ViewModels;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views.Core
{
    public class ViewDelegate<TView> : IViewDelegate<TView>
        where TView : class, IIosView
    {
        [NotNull]
        [Weak]
        private readonly TView _view;
        [CanBeNull]
        private KeyboardHandler _keyboardHandler;

        public ViewDelegate([NotNull] TView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        public TView View => _view;

        public KeyboardHandler KeyboardHandler => _keyboardHandler;

        public virtual void ViewDidLoad()
        {
            if (View.HandleKeyboard && View is UIViewController viewController && viewController.View != null)
            {
                _keyboardHandler = new KeyboardHandler(viewController.View);
            }
        }

        public virtual void ViewWillAppear()
        {
            _keyboardHandler?.RegisterForKeyboardNotifications();
        }

        public virtual void ViewDidAppear()
        {
        }

        public virtual void ViewWillDisappear()
        {
        }

        public virtual void ViewDidDisappear()
        {
            _keyboardHandler?.UnregisterFromKeyboardNotifications();
        }

        public virtual void WillMoveToParentViewController(UIViewController parent)
        {
        }

        public virtual void DidMoveToParentViewController(UIViewController parent)
        {
        }
    }

    public class ViewDelegate<TView, TViewModel> : ViewDelegate<TView>, IViewDelegate<TView, TViewModel>
        where TView : class, IIosView<TViewModel>
        where TViewModel : class, IViewModel
    {
        [CanBeNull]
        private ILogger _logger;
        private ViewModelResultCode _resultCode = ViewModelResultCode.Canceled;
        [CanBeNull]
        private ViewModelResultBase _result;

        public ViewDelegate([NotNull] TView view)
            : base(view)
        {
            ViewModel = ViewModelProvider.Get<TViewModel>();
            ViewModelViewCache.Add(ViewModel, View);
        }

        public TViewModel ViewModel { get; }

        [NotNull]
        private ILogger Logger => _logger ?? (_logger = new ConsoleLogger("FlexiMvvm.Lifecycle", LogFormatter.FormatTypeName(View)));

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.InitializeViewModel();
        }

        public override void ViewWillDisappear()
        {
            base.ViewWillDisappear();

            if (View is UIViewController viewController)
            {
                RaiseResultSetForModalIfNeeded(
                    viewController,
                    viewController.NavigationController,
                    viewController.NavigationController?.TopViewController);
            }
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            if (parent != null)
            {
                var parentView = parent.FindParentViewWithModel();

                if (parentView != null)
                {
                    // View.ViewModel.DirectParentViewModelAttached(parentView.ViewModel);
                    // parentView.ViewModel.DirectChildViewModelAttached(View.ViewModel);
                }
            }
            else
            {
                RaiseResultSetIfNeeded(View);
            }
        }

        public void SetResult(ViewModelResultCode resultCode)
        {
            _resultCode = resultCode;
        }

        public void SetResult(ViewModelResultCode resultCode, ViewModelResultBase result)
        {
            _resultCode = resultCode;
            _result = result;
        }

        public async void HandleResult(object sender, ViewModelResultSetEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (ViewModel is IViewModelWithResultHandler viewModelWithResultHandler)
            {
                await ViewModel.Initialization;

                viewModelWithResultHandler.HandleResult(args.ResultCode, args.Result);
            }
            else
            {
                Log($"\"{LogFormatter.FormatTypeName(ViewModel)}\" view model doesn't implement " +
                    $"\"{LogFormatter.FormatTypeName<IViewModelWithResultHandler>()}\" interface. Therefore it can't handle passed result.");
            }
        }

        private void RaiseResultSetIfNeeded([NotNull] IIosView<IViewModel> view)
        {
            if (view.ViewModel.CanReturnResult())
            {
                view.RaiseResultSet(new ViewModelResultSetEventArgs(_resultCode, _result));
            }
        }

        private void RaiseResultSetForModalIfNeeded([NotNull] [ItemCanBeNull] params UIViewController[] viewControllers)
        {
            foreach (var viewController in viewControllers)
            {
                if (viewController != null && viewController.IsBeingDismissed && viewController is IIosView<IViewModel> view)
                {
                    RaiseResultSetIfNeeded(view);

                    break;
                }
            }
        }

        [Conditional("DEBUG")]
        private void Log([CanBeNull] string message)
        {
            Logger.Log(message);
        }
    }
}
