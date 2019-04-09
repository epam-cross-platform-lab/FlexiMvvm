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
    /// Base class for an application navigation implementation.
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
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        public void Navigate<TTargetView>(
            INavigationView<ILifecycleViewModel> sourceView,
            TTargetView targetView,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/> with the provided lifecycle-aware view model <paramref name="parameters"/>.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="parameters">The target view model parameters. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        public void Navigate<TTargetView, TParameters>(
            INavigationView<ILifecycleViewModel> sourceView,
            TTargetView targetView,
            TParameters? parameters,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<ILifecycleViewModelWithParameters<TParameters>, TParameters>
            where TParameters : Parameters
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            targetView.SetParameters(parameters);
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/> with handling a lifecycle-aware view model result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        public void NavigateForResult<TTargetView, TResult>(
            INavigationView<ILifecycleViewModelWithResultHandler> sourceView,
            TTargetView targetView,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<ILifecycleViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            targetView.ResultSetWeakSubscribe(sourceView.HandleResult);
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
        }

        /// <summary>
        /// Performs forward navigation from the <paramref name="sourceView"/> to the <paramref name="targetView"/> with the provided lifecycle-aware view model <paramref name="parameters"/>
        /// and handling a lifecycle-aware view model result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="targetView">The target view for navigation.</param>
        /// <param name="parameters">The target view model parameters. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        public void NavigateForResult<TTargetView, TParameters, TResult>(
            INavigationView<ILifecycleViewModelWithResultHandler> sourceView,
            TTargetView targetView,
            TParameters? parameters,
            bool animated,
            ForwardNavigationDelegate? navigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<ILifecycleViewModelWithParameters<TParameters>, TParameters>, INavigationView<ILifecycleViewModelWithResult<TResult>>
            where TParameters : Parameters
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            targetView.SetParameters(parameters);
            targetView.ResultSetWeakSubscribe(sourceView.HandleResult);
            (navigationStrategy ?? GetForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/>.
        /// </summary>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="BackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is presented or
        /// <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <see langword="null"/>.</exception>
        public void NavigateBack(
            INavigationView<ILifecycleViewModel> sourceView,
            bool animated,
            BackwardNavigationDelegate? navigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(sourceView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/> with returning a lifecycle-aware view model result.
        /// </summary>
        /// <typeparam name="TResult">The type of the source view model result.</typeparam>
        /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
        /// <param name="resultCode">Determines whether the result should be set as successful or canceled.</param>
        /// <param name="result">The source view model result. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="navigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="BackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is presented or
        /// <see cref="BackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <see langword="null"/>.</exception>
        public void NavigateBack<TResult>(
            INavigationView<ILifecycleViewModelWithResult<TResult>> sourceView,
            ResultCode resultCode,
            TResult? result,
            bool animated,
            BackwardNavigationDelegate? navigationStrategy = null)
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            sourceView.SetResult(resultCode, result);
            (navigationStrategy ?? GetBackwardNavigationStrategy(sourceView)).Invoke(sourceView, animated);
        }

        private ForwardNavigationDelegate GetForwardNavigationStrategy(UIViewController targetView)
        {
            return targetView is UINavigationController ? NavigationStrategy.Forward.PresentViewController() : NavigationStrategy.Forward.PushViewController();
        }

        private BackwardNavigationDelegate GetBackwardNavigationStrategy(INavigationView<ILifecycleViewModel> sourceView)
        {
            var isPresented = sourceView.PresentingViewController?.PresentedViewController == sourceView;

            return isPresented ? NavigationStrategy.Backward.DismissViewController() : NavigationStrategy.Backward.PopViewController();
        }
    }
}
