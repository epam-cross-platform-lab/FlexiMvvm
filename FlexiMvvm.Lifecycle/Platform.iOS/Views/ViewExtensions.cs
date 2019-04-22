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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of <c>static</c> methods for accessing the <see cref="IView"/>.
    /// </summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// Gets self if <paramref name="view"/> is <see cref="UINavigationController"/> or
        /// <see cref="UIViewController.NavigationController"/> property value if <paramref name="view"/> is <see cref="UIViewController"/>.
        /// </summary>
        /// <param name="view">The view reference.</param>
        /// <returns>The <see cref="UINavigationController"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <c>null</c>.</exception>
        [CanBeNull]
        public static UINavigationController GetNavigationController([NotNull] this IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.As(
                navigationController => navigationController,
                viewController => viewController.NotNull().NavigationController);
        }

        /// <summary>
        /// Executes <paramref name="navigationControllerHandler"/> if <paramref name="view"/> is <see cref="UINavigationController"/> or
        /// <paramref name="viewControllerHandler"/> if <paramref name="view"/> is <see cref="UIViewController"/>.
        /// </summary>
        /// <param name="view">The view reference.</param>
        /// <param name="navigationControllerHandler">The navigation controller handler.</param>
        /// <param name="viewControllerHandler">The view controller handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="navigationControllerHandler" /> or <paramref name="viewControllerHandler" /> is <c>null</c>.</exception>
        public static void As(
            [NotNull] this IView view,
            [NotNull] Action<UINavigationController> navigationControllerHandler,
            [NotNull] Action<UIViewController> viewControllerHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (navigationControllerHandler == null)
                throw new ArgumentNullException(nameof(navigationControllerHandler));
            if (viewControllerHandler == null)
                throw new ArgumentNullException(nameof(viewControllerHandler));

            if (view is UINavigationController navigationController)
            {
                navigationControllerHandler(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                viewControllerHandler(viewController);
            }
        }

        /// <summary>
        /// Returns result of <paramref name="navigationControllerHandler"/> if <paramref name="view"/> is <see cref="UINavigationController"/> or
        /// <paramref name="viewControllerHandler"/> if <paramref name="view"/> is <see cref="UIViewController"/>.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="view">The view reference.</param>
        /// <param name="navigationControllerHandler">The navigation controller handler.</param>
        /// <param name="viewControllerHandler">The view controller handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="navigationControllerHandler" /> or <paramref name="viewControllerHandler" /> is <c>null</c>.</exception>
        /// <returns>Result of navigation controller or view controller handler.</returns>
        [CanBeNull]
        public static T As<T>(
            [NotNull] this IView view,
            [NotNull] Func<UINavigationController, T> navigationControllerHandler,
            [NotNull] Func<UIViewController, T> viewControllerHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (navigationControllerHandler == null)
                throw new ArgumentNullException(nameof(navigationControllerHandler));
            if (viewControllerHandler == null)
                throw new ArgumentNullException(nameof(viewControllerHandler));

            T result = default;

            if (view is UINavigationController navigationController)
            {
                result = navigationControllerHandler(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                result = viewControllerHandler(viewController);
            }

            return result;
        }
    }
}
