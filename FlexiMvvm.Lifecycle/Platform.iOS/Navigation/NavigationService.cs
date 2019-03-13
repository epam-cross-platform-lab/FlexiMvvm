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
using JetBrains.Annotations;
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
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        ///     The strategy used for performing navigation.
        ///     Default is <see cref="ForwardNavigationStrategy.PresentViewController(Action)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        ///     <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> or <paramref name="targetView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="UINavigationController"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void Navigate<TTargetView>(
            [NotNull] INavigationView<IViewModel> sourceView,
            [NotNull] TTargetView targetView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TTargetView : UIViewController
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            var navigationController = sourceView.GetNavigationController();

            if (navigationController == null)
            {
                throw new ArgumentNullException("View's navigation controller is 'null'.", nameof(sourceView));
            }

            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(navigationController, targetView, animated);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/> with receiving a result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        ///     The strategy used for performing navigation.
        ///     Default is <see cref="ForwardNavigationStrategy.PresentViewController(Action)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        ///     <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> or <paramref name="targetView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="UINavigationController"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void NavigateForResult<TTargetView, TResult>(
            [NotNull] INavigationView<IViewModelWithResultHandler> sourceView,
            [NotNull] TTargetView targetView,
            bool animated,
            [CanBeNull] ForwardNavigationDelegate navigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<IViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            var navigationController = sourceView.GetNavigationController();

            if (navigationController == null)
            {
                throw new ArgumentNullException("View's navigation controller is 'null'.", nameof(sourceView));
            }

            targetView.ResultSetWeakSubscribe(sourceView.HandleResult);
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(navigationController, targetView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/>.
        /// </summary>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        ///     The strategy used for performing navigation.
        ///     Default is <see cref="BackwardNavigationStrategy.DismissViewController(Action)"/> if <paramref name="sourceView"/> is being presented or
        ///     <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is being pushed.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="UINavigationController"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void NavigateBack(
            [NotNull] INavigationView<IViewModel> sourceView,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var navigationController = sourceView.GetNavigationController();

            if (navigationController == null)
            {
                throw new ArgumentNullException("View's navigation controller is 'null'.", nameof(sourceView));
            }

            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(navigationController, sourceView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/> with a result.
        /// </summary>
        /// <typeparam name="TResult">The type of the source view model result.</typeparam>
        /// <param name="sourceView">The source view from which navigation is performed from.</param>
        /// <param name="resultCode">Determines whether the result has been set successfully or canceled.</param>
        /// <param name="result">The source view model result.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        ///     The strategy used for performing navigation.
        ///     Default is <see cref="BackwardNavigationStrategy.DismissViewController(Action)"/> if <paramref name="sourceView"/> is being presented or
        ///     <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is being pushed.
        /// </param>
        /// <exception cref="ArgumentNullException">
        ///     <para><paramref name="sourceView"/> is <c>null</c>.</para>
        ///     <para>-or-</para>
        ///     <para><see cref="UINavigationController"/> returned by <paramref name="sourceView"/> is <c>null</c>.</para>
        /// </exception>
        public void NavigateBack<TResult>(
            [NotNull] INavigationView<IViewModelWithResult<TResult>> sourceView,
            ResultCode resultCode,
            [CanBeNull] TResult result,
            bool animated,
            [CanBeNull] BackwardNavigationDelegate navigationStrategy = null)
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            var navigationController = sourceView.GetNavigationController();

            if (navigationController == null)
            {
                throw new ArgumentNullException("View's navigation controller is 'null'.", nameof(sourceView));
            }

            sourceView.SetResult(resultCode, result);
            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(navigationController, sourceView, animated);
        }

        [NotNull]
        private ForwardNavigationDelegate GetForwardNavigationStrategy([NotNull] UIViewController targetView)
        {
            return targetView is UINavigationController ? NavigationStrategy.Forward.PresentViewController() : NavigationStrategy.Forward.PushViewController();
        }

        [NotNull]
        private BackwardNavigationDelegate GetBackwardNavigationStrategy([NotNull] INavigationView<IViewModel> sourceView)
        {
            return sourceView.IsBeingPresented ? NavigationStrategy.Backward.DismissViewController() : NavigationStrategy.Backward.PopViewController();
        }
    }
}
