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
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views.Core;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public class FlxPageViewController : UIPageViewController, IFlxViewController
    {
        [CanBeNull]
        private IViewDelegate<FlxPageViewController> _viewDelegate;

        public event EventHandler ViewWillAppearCalled;

        public event EventHandler ViewDidAppearCalled;

        public event EventHandler ViewWillDisappearCalled;

        public event EventHandler ViewDidDisappearCalled;

        [NotNull]
        protected IViewDelegate<FlxPageViewController> ViewDelegate => _viewDelegate ?? (_viewDelegate = CreateViewDelegate());

        public virtual bool HandleKeyboard { get; } = false;

        public KeyboardHandler KeyboardHandler => ViewDelegate.KeyboardHandler;

        [NotNull]
        protected virtual IViewDelegate<FlxPageViewController> CreateViewDelegate()
        {
            return new ViewDelegate<FlxPageViewController>(this);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            ViewDelegate.ViewDidLoad();
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            ViewDelegate.ViewWillAppear();
            ViewWillAppearCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            ViewDelegate.ViewDidAppear();
            ViewDidAppearCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);

            ViewDelegate.ViewWillDisappear();
            ViewWillDisappearCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            ViewDelegate.ViewDidDisappear();
            ViewDidDisappearCalled?.Invoke(this, EventArgs.Empty);
        }

        public override void WillMoveToParentViewController(UIViewController parent)
        {
            base.WillMoveToParentViewController(parent);

            ViewDelegate.WillMoveToParentViewController(parent);
        }

        public override void DidMoveToParentViewController(UIViewController parent)
        {
            base.DidMoveToParentViewController(parent);

            ViewDelegate.DidMoveToParentViewController(parent);
        }
    }

    public class FlxPageViewController<TViewModel> : FlxPageViewController, IFlxViewController<TViewModel>
        where TViewModel : class, IViewModelWithoutParameters
    {
        public event EventHandler<ViewModelResultSetEventArgs> ResultSet;

        [NotNull]
        private new IViewDelegate<FlxPageViewController<TViewModel>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxPageViewController<TViewModel>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        protected override IViewDelegate<FlxPageViewController> CreateViewDelegate()
        {
            return new ViewDelegate<FlxPageViewController<TViewModel>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize();
        }

        public void SetResult(ViewModelResultCode resultCode, ViewModelResultBase result)
        {
            ViewDelegate.SetResult(resultCode, result);
        }

        void IIosView<TViewModel>.RaiseResultSet(ViewModelResultSetEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ResultSet?.Invoke(this, args);
        }

        public void HandleResult(object sender, ViewModelResultSetEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ViewDelegate.HandleResult(sender, args);
        }
    }

    public class FlxPageViewController<TViewModel, TParameters> : FlxPageViewController, IFlxViewController<TViewModel>
        where TViewModel : class, IViewModelWithParameters<TParameters>
        where TParameters : ViewModelParametersBase
    {
        [CanBeNull]
        private readonly TParameters _parameters;

        public FlxPageViewController([CanBeNull] TParameters parameters)
        {
            _parameters = parameters;
        }

        public event EventHandler<ViewModelResultSetEventArgs> ResultSet;

        [NotNull]
        private new IViewDelegate<FlxPageViewController<TViewModel, TParameters>, TViewModel> ViewDelegate =>
            (IViewDelegate<FlxPageViewController<TViewModel, TParameters>, TViewModel>)base.ViewDelegate;

        public TViewModel ViewModel => ViewDelegate.ViewModel;

        protected override IViewDelegate<FlxPageViewController> CreateViewDelegate()
        {
            return new ViewDelegate<FlxPageViewController<TViewModel, TParameters>, TViewModel>(this);
        }

        public virtual void InitializeViewModel()
        {
            ViewModel.Initialize(_parameters);
        }

        public void SetResult(ViewModelResultCode resultCode, ViewModelResultBase result)
        {
            ViewDelegate.SetResult(resultCode, result);
        }

        void IIosView<TViewModel>.RaiseResultSet(ViewModelResultSetEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ResultSet?.Invoke(this, args);
        }

        public void HandleResult(object sender, ViewModelResultSetEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            ViewDelegate.HandleResult(sender, args);
        }
    }
}
