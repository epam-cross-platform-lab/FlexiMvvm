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
using FlexiMvvm.Views;
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Provides a set of methods for performing navigation.
    /// </summary>
    public abstract class NavigationService
    {
        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/>.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <c>null</c>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="sourceView" /> is derived from a class other than the <see cref="UINavigationController"/> or <see cref="UIViewController"/>.</para>
        /// <para>-or-</para>
        /// <para>The navigation controller reference is <c>null</c> for the provided <paramref name="sourceView"/>.</para>
        /// </exception>
        public void Navigate<TTargetView>(
            INavigationView<IViewModel> sourceView,
            TTargetView targetView,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            var navigationController = sourceView.GetNavigationController();
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(navigationController, targetView, animated);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/> with receiving a result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <c>null</c>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="sourceView" /> is derived from a class other than the <see cref="UINavigationController"/> or <see cref="UIViewController"/>.</para>
        /// <para>-or-</para>
        /// <para>The navigation controller reference is <c>null</c> for the provided <paramref name="sourceView"/>.</para>
        /// </exception>
        public void NavigateForResult<TTargetView, TResult>(
            INavigationView<IViewModelWithResultHandler> sourceView,
            TTargetView targetView,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<IViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            var navigationController = sourceView.GetNavigationController();
            targetView.ResultSetWeakSubscribe(sourceView.HandleResult);
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(navigationController, targetView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/>.
        /// </summary>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <c>null</c>.
        /// <para>The default is <see cref="BackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is being presented or
        /// <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is being pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="sourceView" /> is derived from a class other than the <see cref="UINavigationController"/> or <see cref="UIViewController"/>.</para>
        /// <para>-or-</para>
        /// <para>The navigation controller reference is <c>null</c> for the provided <paramref name="sourceView"/>.</para>
        /// </exception>
        public void NavigateBack(
            INavigationView<IViewModel> sourceView,
            bool animated,
            BackwardNavigationDelegate? navigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var navigationController = sourceView.GetNavigationController();
            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(navigationController, sourceView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/> with a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the source view model result.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="resultCode">Determines whether the result has been set successfully or canceled.</param>
        /// <param name="result">The source view model result. Can be <c>null</c>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <c>null</c>.
        /// <para>The default is <see cref="BackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is being presented or
        /// <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is being pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="sourceView" /> is derived from a class other than the <see cref="UINavigationController"/> or <see cref="UIViewController"/>.</para>
        /// <para>-or-</para>
        /// <para>The navigation controller reference is <c>null</c> for the provided <paramref name="sourceView"/>.</para>
        /// </exception>
        public void NavigateBack<TResult>(
            INavigationView<IViewModelWithResult<TResult>> sourceView,
            ResultCode resultCode,
            TResult? result,
            bool animated,
            BackwardNavigationDelegate? navigationStrategy = null)
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var navigationController = sourceView.GetNavigationController();
            sourceView.SetResult(resultCode, result);
            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(navigationController, sourceView, animated);
        }

        private ForwardNavigationDelegate GetForwardNavigationStrategy(UIViewController targetView)
        {
            return targetView is UINavigationController ? NavigationStrategy.Forward.PresentViewController() : NavigationStrategy.Forward.PushViewController();
        }

        private BackwardNavigationDelegate GetBackwardNavigationStrategy(INavigationView<IViewModel> sourceView)
        {
            return sourceView.IsBeingPresented ? NavigationStrategy.Backward.DismissViewController() : NavigationStrategy.Backward.PopViewController();
        }
    }
}
