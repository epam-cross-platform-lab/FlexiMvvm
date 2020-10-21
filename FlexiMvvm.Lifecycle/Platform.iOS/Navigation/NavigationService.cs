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
        [Obsolete("Navigate<TTargetView>(INavigationView<ILifecycleViewModel>, TTargetView, bool, ForwardNavigationDelegate?) will be removed soon. Use NavigateToViewController<TTargetView>(INavigationView<ILifecycleViewModel>, TTargetView, bool, ViewControllerForwardNavigationDelegate?) method instead.")]
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
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target <see cref="UIViewController"/>.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view controller.</typeparam>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="targetView">The target <see cref="UIViewController"/> for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation to the <see cref="UIViewController"/>. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ViewControllerForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateToViewController<TTargetView>(
            INavigationView<ILifecycleViewModel> sourceView,
            TTargetView targetView,
            bool animated,
            ViewControllerForwardNavigationDelegate? viewControllerNavigationStrategy = null)
            where TTargetView : UIViewController
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            (viewControllerNavigationStrategy ?? GetViewControllerForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
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
        [Obsolete("Navigate<TTargetView, TParameters>(INavigationView<ILifecycleViewModel>, TTargetView, TParameters?, bool, ForwardNavigationDelegate?) will be removed soon. Use NavigateToViewController<TTargetView, TParameters>(INavigationView<ILifecycleViewModel>, TTargetView, TParameters?, bool, ViewControllerForwardNavigationDelegate?) method instead.")]
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
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target <see cref="UIViewController"/> with the provided lifecycle-aware view model <paramref name="parameters"/>.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view controller.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="targetView">The target <see cref="UIViewController"/> for navigation.</param>
        /// <param name="parameters">The target view model parameters. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation to the <see cref="UIViewController"/>. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ViewControllerForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateToViewController<TTargetView, TParameters>(
            INavigationView<ILifecycleViewModel> sourceView,
            TTargetView targetView,
            TParameters? parameters,
            bool animated,
            ViewControllerForwardNavigationDelegate? viewControllerNavigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<ILifecycleViewModelWithParameters<TParameters>, TParameters>
            where TParameters : Parameters
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            targetView.SetParameters(parameters);
            (viewControllerNavigationStrategy ?? GetViewControllerForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
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
        [Obsolete("NavigateForResult<TTargetView, TResult>(INavigationView<ILifecycleViewModelWithResultHandler>, TTargetView, bool, ForwardNavigationDelegate?) will be removed soon. Use NavigateToViewControllerForResult<TTargetView, TResult>(INavigationView<ILifecycleViewModelWithResultHandler>, TTargetView, bool, ViewControllerForwardNavigationDelegate?) method instead.")]
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
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target <see cref="UIViewController"/> with handling a lifecycle-aware view model result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view controller.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="targetView">The target <see cref="UIViewController"/> for navigation.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation to the <see cref="UIViewController"/>. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ViewControllerForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateToViewControllerForResult<TTargetView, TResult>(
            INavigationView<ILifecycleViewModelWithResultHandler> sourceView,
            TTargetView targetView,
            bool animated,
            ViewControllerForwardNavigationDelegate? viewControllerNavigationStrategy = null)
            where TTargetView : UIViewController, INavigationView<ILifecycleViewModelWithResult<TResult>>
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            targetView.ResultSetWeakSubscribe(sourceView.HandleResult);
            (viewControllerNavigationStrategy ?? GetViewControllerForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
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
        [Obsolete("NavigateForResult<TTargetView, TParameters, TResult>(INavigationView<ILifecycleViewModelWithResultHandler>, TTargetView, TParameters?, bool, ForwardNavigationDelegate?) will be removed soon. Use NavigateToViewControllerForResult<TTargetView, TParameters, TResult>(INavigationView<ILifecycleViewModelWithResultHandler>, TTargetView, TParameters?, bool, ViewControllerForwardNavigationDelegate?) method instead.")]
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
        /// Performs forward navigation from the <paramref name="sourceView"/> to the target <see cref="UIViewController"/> with the provided lifecycle-aware view model <paramref name="parameters"/>
        /// and handling a lifecycle-aware view model result when it finished.
        /// </summary>
        /// <typeparam name="TTargetView">The type of the target view controller.</typeparam>
        /// <typeparam name="TParameters">The type of the target view model parameters.</typeparam>
        /// <typeparam name="TResult">The type of the target view model result.</typeparam>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="targetView">The target <see cref="UIViewController"/> for navigation.</param>
        /// <param name="parameters">The target view model parameters. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation to the <see cref="UIViewController"/>. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerForwardNavigationStrategy.PresentViewController(Action?)"/> if <paramref name="targetView"/> is <see cref="UINavigationController"/> or
        /// <see cref="ViewControllerForwardNavigationStrategy.PushViewController()"/> if <paramref name="targetView"/> is <see cref="UIViewController"/>.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> or <paramref name="targetView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateToViewControllerForResult<TTargetView, TParameters, TResult>(
            INavigationView<ILifecycleViewModelWithResultHandler> sourceView,
            TTargetView targetView,
            TParameters? parameters,
            bool animated,
            ViewControllerForwardNavigationDelegate? viewControllerNavigationStrategy = null)
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
            (viewControllerNavigationStrategy ?? GetViewControllerForwardNavigationStrategy(targetView)).Invoke(sourceView, targetView, animated);
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/>.
        /// </summary>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerBackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is presented or
        /// <see cref="ViewControllerBackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateBack(
            INavigationView<ILifecycleViewModel> sourceView,
            bool animated,
            ViewControllerBackwardNavigationDelegate? viewControllerNavigationStrategy = null)
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            sourceView.As(
                viewController => (viewControllerNavigationStrategy ?? GetViewControllerBackwardNavigationStrategy(viewController)).Invoke(viewController, animated));
        }

        /// <summary>
        /// Performs backward navigation from the <paramref name="sourceView"/> with returning a lifecycle-aware view model result.
        /// </summary>
        /// <typeparam name="TResult">The type of the source view model result.</typeparam>
        /// <param name="sourceView">The <see cref="INavigationView{TViewModel}"/> from which navigation is performed from.</param>
        /// <param name="resultCode">Determines whether the result should be set as successful or canceled.</param>
        /// <param name="result">The source view model result. Can be <see langword="null"/>.</param>
        /// <param name="animated">Determines if the transition is to be animated.</param>
        /// <param name="viewControllerNavigationStrategy">
        /// The strategy used for performing navigation. Can be <see langword="null"/>.
        /// <para>The default is <see cref="ViewControllerBackwardNavigationStrategy.DismissViewController(Action?)"/> if <paramref name="sourceView"/> is presented or
        /// <see cref="ViewControllerBackwardNavigationStrategy.PopViewController()"/> if <paramref name="sourceView"/> is pushed.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="sourceView"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="sourceView" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public void NavigateBack<TResult>(
            INavigationView<ILifecycleViewModelWithResult<TResult>> sourceView,
            ResultCode resultCode,
            TResult? result,
            bool animated,
            ViewControllerBackwardNavigationDelegate? viewControllerNavigationStrategy = null)
            where TResult : Result
        {
            if (sourceView == null)
                throw new ArgumentNullException(nameof(sourceView));

            sourceView.SetResult(resultCode, result);
            sourceView.As(
                viewController => (viewControllerNavigationStrategy ?? GetViewControllerBackwardNavigationStrategy(viewController)).Invoke(viewController, animated));
        }

        [Obsolete]
        private ForwardNavigationDelegate GetForwardNavigationStrategy(UIViewController targetView)
        {
            return targetView is UINavigationController ? NavigationStrategy.Forward.PresentViewController() : NavigationStrategy.Forward.PushViewController();
        }

        private ViewControllerForwardNavigationDelegate GetViewControllerForwardNavigationStrategy(UIViewController targetView)
        {
            return targetView is UINavigationController ? ViewControllerNavigationStrategy.Forward.PresentViewController() : ViewControllerNavigationStrategy.Forward.PushViewController();
        }

        private ViewControllerBackwardNavigationDelegate GetViewControllerBackwardNavigationStrategy(UIViewController sourceView)
        {
            var isPresented = sourceView.PresentingViewController?.PresentedViewController == sourceView;

            return isPresented ? ViewControllerNavigationStrategy.Backward.DismissViewController() : ViewControllerNavigationStrategy.Backward.PopViewController();
        }
    }
}
