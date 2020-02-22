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
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for backward navigation from the <see cref="UIViewController"/>.
    /// </summary>
    /// <param name="sourceView">The <see cref="UIViewController"/> from which navigation is performed from.</param>
    /// <param name="animated">Determines if the transition is to be animated.</param>
    public delegate void ViewControllerBackwardNavigationDelegate(UIViewController sourceView, bool animated);

    /// <summary>
    /// Provides a set of backward navigation strategies for the <see cref="UIViewController"/>.
    /// </summary>
    public sealed class ViewControllerBackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using the provided <paramref name="strategies"/>. Strategies are executed in the order in which they are passed.
        /// </summary>
        /// <param name="strategies">The strategies to execute during the backward navigation.</param>
        /// <returns>The backward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="strategies"/> is <see langword="null"/>.</exception>
        public ViewControllerBackwardNavigationDelegate Composite(params ViewControllerBackwardNavigationDelegate[] strategies)
        {
            if (strategies == null)
                throw new ArgumentNullException(nameof(strategies));

            return (sourceView, animated) =>
            {
                foreach (var strategy in strategies)
                {
                    strategy(sourceView, animated);
                }
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="UINavigationController.PopViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public ViewControllerBackwardNavigationDelegate PopViewController()
        {
            return (sourceView, animated) =>
            {
                sourceView.NavigationController.PopViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="UINavigationController.PopToViewController(UIViewController, bool)"/> method.
        /// </summary>
        /// <param name="targetView">The target view controller for navigation.</param>
        /// <returns>The backward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="targetView"/> is <see langword="null"/>.</exception>
        public ViewControllerBackwardNavigationDelegate PopToViewController(UIViewController targetView)
        {
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            return (sourceView, animated) =>
            {
                sourceView.NavigationController.PopToViewController(targetView, animated);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="UINavigationController.PopToRootViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public ViewControllerBackwardNavigationDelegate PopToRootViewController()
        {
            return (sourceView, animated) =>
            {
                sourceView.NavigationController.PopToRootViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using the <see cref="UIViewController.DismissViewController(bool, Action?)"/> method.
        /// </summary>
        /// <param name="completionHandler">The method to invoke when the animation completes. Can be <see langword="null"/>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public ViewControllerBackwardNavigationDelegate DismissViewController(Action? completionHandler = null)
        {
            return (sourceView, animated) =>
            {
                sourceView.DismissViewController(animated, completionHandler);
            };
        }
    }
}
