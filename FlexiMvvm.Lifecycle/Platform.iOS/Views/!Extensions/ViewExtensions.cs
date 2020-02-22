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
using UIKit;

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of static methods for the <see cref="IView{TViewModel}"/>.
    /// </summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// Executes appropriate handler based on actual type of the <paramref name="view"/>.
        /// </summary>
        /// <param name="view">The view that is represented by the <see cref="UIViewController"/> or <see cref="UINavigationController"/>.</param>
        /// <param name="viewControllerHandler">The handler to execute when the <paramref name="view"/> is <see cref="UIViewController"/>.</param>
        /// <param name="navigationControllerHandler">
        /// The handler to execute when the <paramref name="view"/> is <see cref="UINavigationController"/>. Can be <see langword="null"/>.
        /// <para>If the <paramref name="navigationControllerHandler"/> is <see langword="null"/> then the <paramref name="viewControllerHandler"/> will be used as a handler.</para>
        /// </param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="viewControllerHandler" /> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="view" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public static void As(
            this IView<ILifecycleViewModel> view,
            Action<UIViewController> viewControllerHandler,
            Action<UINavigationController>? navigationControllerHandler = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (viewControllerHandler == null)
                throw new ArgumentNullException(nameof(viewControllerHandler));

            if (view is UINavigationController navigationController)
            {
                (navigationControllerHandler ?? viewControllerHandler)(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                viewControllerHandler(viewController);
            }
            else
            {
                throw new ArgumentException($"Only views derived from the '{TypeFormatter.FormatName<UIViewController>()}' are supported.", nameof(view));
            }
        }

        /// <summary>
        /// Executes appropriate handler based on actual type of the <paramref name="view"/> with returning a result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="view">The view that is represented by the <see cref="UIViewController"/> or <see cref="UINavigationController"/>.</param>
        /// <param name="viewControllerHandler">The handler to execute when the <paramref name="view"/> is <see cref="UIViewController"/>.</param>
        /// <param name="navigationControllerHandler">
        /// The handler to execute when the <paramref name="view"/> is <see cref="UINavigationController"/>. Can be <see langword="null"/>.
        /// <para>If the <paramref name="navigationControllerHandler"/> is <see langword="null"/> then the <paramref name="viewControllerHandler"/> will be used as a handler.</para>
        /// </param>
        /// <returns>A result returned by appropriate handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="viewControllerHandler" /> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="view" /> is derived from a class other than the <see cref="UIViewController"/>.
        /// </exception>
        public static T As<T>(
            this IView<ILifecycleViewModel> view,
            Func<UIViewController, T> viewControllerHandler,
            Func<UINavigationController, T>? navigationControllerHandler = null)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (viewControllerHandler == null)
                throw new ArgumentNullException(nameof(viewControllerHandler));

            T result;

            if (view is UINavigationController navigationController)
            {
                result = (navigationControllerHandler ?? viewControllerHandler)(navigationController);
            }
            else if (view is UIViewController viewController)
            {
                result = viewControllerHandler(viewController);
            }
            else
            {
                throw new ArgumentException($"Only views derived from the '{TypeFormatter.FormatName<UIViewController>()}' are supported.", nameof(view));
            }

            return result;
        }
    }
}
