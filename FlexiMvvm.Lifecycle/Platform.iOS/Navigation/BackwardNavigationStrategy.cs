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
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;
using FlexiMvvm.Views;
using UIKit;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Defines the contract for backward navigation.
    /// </summary>
    /// <param name="sourceView">The source navigation view from which navigation is performed from.</param>
    /// <param name="animated">Determines if the transition is to be animated.</param>
    public delegate void BackwardNavigationDelegate(INavigationView<ILifecycleViewModel> sourceView, bool animated);

    /// <summary>
    /// Provides a set of backward navigation strategies.
    /// </summary>
    public sealed class BackwardNavigationStrategy
    {
        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public BackwardNavigationDelegate PopViewController()
        {
            return (sourceView, animated) =>
            {
                var navigationController = sourceView.GetNavigationController();

                if (navigationController == null)
                {
                    throw new InvalidOperationException(
                        $"'{TypeFormatter.FormatName(sourceView.GetType())}.{nameof(NavigationViewExtensions.GetNavigationController)}' returned 'null' value.");
                }

                navigationController.PopViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopToViewController(UIViewController, bool)"/> method.
        /// </summary>
        /// <param name="targetView">The target view for navigation.</param>
        /// <returns>The backward navigation delegate.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="targetView"/> is <c>null</c>.</exception>
        public BackwardNavigationDelegate PopToViewController(UIViewController targetView)
        {
            if (targetView == null)
                throw new ArgumentNullException(nameof(targetView));

            return (sourceView, animated) =>
            {
                var navigationController = sourceView.GetNavigationController();

                if (navigationController == null)
                {
                    throw new InvalidOperationException(
                        $"'{TypeFormatter.FormatName(sourceView.GetType())}.{nameof(NavigationViewExtensions.GetNavigationController)}' returned 'null' value.");
                }

                navigationController.PopToViewController(targetView, animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="UINavigationController.PopToRootViewController(bool)"/> method.
        /// </summary>
        /// <returns>The backward navigation delegate.</returns>
        public BackwardNavigationDelegate PopToRootViewController()
        {
            return (sourceView, animated) =>
            {
                var navigationController = sourceView.GetNavigationController();

                if (navigationController == null)
                {
                    throw new InvalidOperationException(
                        $"'{TypeFormatter.FormatName(sourceView.GetType())}.{nameof(NavigationViewExtensions.GetNavigationController)}' returned 'null' value.");
                }

                navigationController.PopToRootViewController(animated);
            };
        }

        /// <summary>
        /// Backward navigation using <see cref="INavigationView{TViewModel}.DismissViewController(bool, Action?)"/> method.
        /// </summary>
        /// <param name="completionHandler">The method to invoke when the animation completes. Can be <c>null</c>.</param>
        /// <returns>The backward navigation delegate.</returns>
        public BackwardNavigationDelegate DismissViewController(Action? completionHandler = null)
        {
            return (sourceView, animated) =>
            {
                sourceView.DismissViewController(animated, completionHandler);
            };
        }
    }
}
