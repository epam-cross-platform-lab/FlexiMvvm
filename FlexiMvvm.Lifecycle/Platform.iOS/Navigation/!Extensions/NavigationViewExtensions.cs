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
    /// Provides a set of static methods for accessing the <see cref="INavigationView{TViewModel}"/>.
    /// </summary>
    public static class NavigationViewExtensions
    {
        /// <summary>
        /// Gets self if <paramref name="view"/> is <see cref="UINavigationController"/> or
        /// <see cref="UIViewController.NavigationController"/> property value if <paramref name="view"/> is <see cref="UIViewController"/>.
        /// </summary>
        /// <param name="view">The navigation view.</param>
        /// <returns>The <see cref="UINavigationController"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <para><paramref name="view" /> is derived from a class other than the <see cref="UINavigationController"/> or <see cref="UIViewController"/>.</para>
        /// <para>-or-</para>
        /// <para>The navigation controller reference is <c>null</c> for the provided <paramref name="view"/>.</para>
        /// </exception>
        public static UINavigationController GetNavigationController(this INavigationView<IViewModel> view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            var navigationController = view.As(
                navigationController => navigationController,
                viewController => viewController.NavigationController);

            if (navigationController == null)
            {
                throw new ArgumentException(
                    $"The navigation controller reference is 'null' for the provided '{TypeFormatter.FormatName(view.GetType())}' view.", nameof(view));
            }

            return navigationController;
        }
    }
}
