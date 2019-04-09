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

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Defines the contract for a platform-specific view that participates in navigation.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface INavigationView<out TViewModel> : IView<TViewModel>
        where TViewModel : class, ILifecycleViewModel
    {
        /// <summary>
        /// Occurs when the lifecycle-aware view model result is returning to the calling view's model.
        /// </summary>
        event EventHandler<ResultSetEventArgs> ResultSet;

        /// <summary>
        /// Gets a value indicating whether the current view is in the process of being added to a parent view.
        /// </summary>
        bool IsMovingToParentViewController { get; }

        /// <summary>
        /// Gets a value indicating whether the current view is in the process of being removed from its parent view.
        /// </summary>
        bool IsMovingFromParentViewController { get; }

        /// <summary>
        /// Gets a value indicating whether the current view is in the process of being presented.
        /// </summary>
        bool IsBeingPresented { get; }

        /// <summary>
        /// Gets a value indicating whether the current view is in the process of being dismissed.
        /// </summary>
        bool IsBeingDismissed { get; }

        /// <summary>
        /// Gets the view that is presenting this view. Can be <see langword="null"/>.
        /// </summary>
        UIViewController? PresentingViewController { get; }

        /// <summary>
        /// Modally presents a view.
        /// </summary>
        /// <param name="viewControllerToPresent">The view that displays over the current view content.</param>
        /// <param name="animated">Boolean indicating whether to animate presentation or not.</param>
        /// <param name="completionHandler">Completion action to execute after the presentation finishes. Can be <see langword="null"/>.</param>
        void PresentViewController(UIViewController viewControllerToPresent, bool animated, Action? completionHandler);

        /// <summary>
        /// Dismisses the presented view.
        /// </summary>
        /// <param name="animated">Boolean that determines if the transition is to be animated.</param>
        /// <param name="completionHandler">Completion action to execute when the animation completes. Can be <see langword="null"/>.</param>
        void DismissViewController(bool animated, Action? completionHandler);

        /// <summary>
        /// Sets the lifecycle-aware view model result to be returned to the calling view's model.
        /// </summary>
        /// <param name="resultCode">Determines whether the result should be set as successful or not due to cancellation by the user.</param>
        /// <param name="result">The view model result. Can be <see langword="null"/>.</param>
        void SetResult(ResultCode resultCode, Result? result);

        /// <summary>
        /// Raises the <see cref="ResultSet"/> event with <paramref name="resultCode"/> and <paramref name="result"/> arguments.
        /// </summary>
        /// <param name="resultCode">Determines whether the result should be set as successful or not due to cancellation by the user.</param>
        /// <param name="result">The view model result. Can be <see langword="null"/>.</param>
        void RaiseResultSet(ResultCode resultCode, Result? result);

        /// <summary>
        /// The event handler which forwards the lifecycle-aware view model result processing to the lifecycle-aware view model
        /// if it implements the <see cref="ILifecycleViewModelWithResultHandler"/>.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="args">The event arguments containing the view model result.</param>
        /// <exception cref="ArgumentNullException"><paramref name="sender"/> or <paramref name="args"/> is <see langword="null"/>.</exception>
        void HandleResult(object sender, ResultSetEventArgs args);
    }

    /// <summary>
    /// Defines the contract for a platform-specific view that participates in navigation and takes lifecycle-aware view model parameters.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    public interface INavigationView<out TViewModel, TParameters> : INavigationView<TViewModel>
        where TViewModel : class, ILifecycleViewModelWithParameters<TParameters>
        where TParameters : Parameters
    {
        /// <summary>
        /// Sets the lifecycle-aware view model parameters to pass to the initialization method of the lifecycle-aware view model.
        /// </summary>
        /// <param name="parameters">The view model parameters. Can be <see langword="null"/>.</param>
        void SetParameters(TParameters? parameters);
    }
}
