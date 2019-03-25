﻿// =========================================================================
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
using FlexiMvvm.ViewModels;
using FlexiMvvm.ViewModels.Core;
using FlexiMvvm.Views.Keyboard;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views.Core
{
    public class ViewLifecycleDelegate<TView> : IViewLifecycleDelegate
        where TView : class, IIosView, IKeyboardHandlerOwner
    {
        [NotNull]
        [Weak]
        private readonly TView _view;

        public ViewLifecycleDelegate([NotNull] TView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
        }

        [NotNull]
        protected TView View => _view;

        public virtual void ViewDidLoad()
        {
            if (View.HandleKeyboard && View is UIViewController viewController && viewController.View != null)
            {
                View.SetKeyboardHandler(new KeyboardHandler(viewController.View));
            }
        }

        public virtual void ViewWillAppear()
        {
            View.KeyboardHandler?.RegisterForKeyboardNotifications();
        }

        public virtual void ViewWillDisappear()
        {
        }

        public virtual void ViewDidDisappear()
        {
            View.KeyboardHandler?.UnregisterFromKeyboardNotifications();
        }

        public virtual void SetResult(ResultCode resultCode)
        {
        }

        public virtual void SetResult(ResultCode resultCode, [CanBeNull] Result result)
        {
        }

        public virtual void HandleResult([NotNull] object sender, [NotNull] ResultSetEventArgs args)
        {
        }
    }

    public class ViewLifecycleDelegate<TView, TViewModel> : ViewLifecycleDelegate<TView>
        where TView : class, IIosView, INavigationView<TViewModel>, IKeyboardHandlerOwner, IViewModelOwner<TViewModel>
        where TViewModel : class, ILifecycleViewModel
    {
        private ResultCode _resultCode = ResultCode.Canceled;
        [CanBeNull]
        private Result _result;
        private bool _isViewModelCreated;
        [NotNull]
        private Task _viewModelAsyncInitialization = Task.CompletedTask;

        public ViewLifecycleDelegate([NotNull] TView view)
            : base(view)
        {
            var factory = ViewModelProvider.GetFactory();
            var viewModel = factory.Create<TViewModel>();
            _isViewModelCreated = true;

            View.SetViewModel(viewModel);
            ViewCache.Add(View);
        }

        public override void ViewWillAppear()
        {
            base.ViewWillAppear();

            if (_isViewModelCreated)
            {
                _viewModelAsyncInitialization = View.InitializeViewModelAsync();
                _isViewModelCreated = false;
            }
        }

        public override void ViewWillDisappear()
        {
            base.ViewWillDisappear();

            if (View.IsMovingFromParentViewController || View.IsBeingDismissed)
            {
                View.RaiseResultSet(_resultCode, _result);
            }
        }

        public override void SetResult(ResultCode resultCode)
        {
            _resultCode = resultCode;
        }

        public override void SetResult(ResultCode resultCode, Result result)
        {
            _resultCode = resultCode;
            _result = result;
        }

        public override async void HandleResult(object sender, ResultSetEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (View.ViewModel is ILifecycleViewModelWithResultHandler viewModelWithResultHandler)
            {
                await _viewModelAsyncInitialization;
                viewModelWithResultHandler.HandleResult(args.ResultCode, args.Result);
            }
        }
    }
}
