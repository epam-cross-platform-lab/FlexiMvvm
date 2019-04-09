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
using FlexiMvvm.ViewModels;
using UIKit;

namespace FlexiMvvm.Views.Core
{
    /// <summary>
    /// Defines the contract for a view lifecycle delegate. Can perform custom actions when view's lifecycle method is called.
    /// <para>This interface is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    public interface IViewLifecycleDelegate
    {
        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.WillMoveToParentViewController(UIViewController?)"/> method is called.
        /// </summary>
        /// <param name="parent">The parent view. Can be <see langword="null"/>.</param>
        void WillMoveToParentViewController(UIViewController? parent);

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.ViewDidLoad"/> method is called.
        /// </summary>
        void ViewDidLoad();

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.ViewWillAppear(bool)"/> method is called.
        /// </summary>
        void ViewWillAppear();

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.ViewDidAppear(bool)"/> method is called.
        /// </summary>
        void ViewDidAppear();

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.ViewWillDisappear(bool)"/> method is called.
        /// </summary>
        void ViewWillDisappear();

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.ViewDidDisappear(bool)"/> method is called.
        /// </summary>
        void ViewDidDisappear();

        /// <summary>
        /// Can perform custom actions when <see cref="UIViewController.DidMoveToParentViewController(UIViewController?)"/> method is called.
        /// </summary>
        /// <param name="parent">The parent view. Can be <see langword="null"/>.</param>
        void DidMoveToParentViewController(UIViewController? parent);

        /// <summary>
        /// Sets the lifecycle-aware view model result to be returned to the calling view's model.
        /// </summary>
        /// <param name="resultCode">Determines whether the result should be set as successful or not due to cancellation by the user.</param>
        /// <param name="result">The view model result. Can be <see langword="null"/>.</param>
        void SetResult(ResultCode resultCode, Result? result);

        /// <summary>
        /// The event handler which forwards the lifecycle-aware view model result processing to the lifecycle-aware view model
        /// if it implements the <see cref="ILifecycleViewModelWithResultHandler"/>.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments containing the view model result.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sender"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        void HandleResult(object sender, ResultSetEventArgs args);
    }
}
