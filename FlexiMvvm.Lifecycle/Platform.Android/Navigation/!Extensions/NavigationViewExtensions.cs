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
using Fragment = Android.Support.V4.App.Fragment;
using FragmentActivity = Android.Support.V4.App.FragmentActivity;

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Provides a set of static methods for accessing the <see cref="INavigationView{TViewModel}"/>.
    /// </summary>
    public static class NavigationViewExtensions
    {
        /// <summary>
        /// Gets self if <paramref name="view"/> is <see cref="FragmentActivity"/> or
        /// <see cref="Fragment.Activity"/> property value if <paramref name="view"/> is <see cref="Fragment"/>.
        /// </summary>
        /// <param name="view">The navigation view.</param>
        /// <returns>The <see cref="FragmentActivity"/> instance. Can be <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="view" /> is derived from a class other than the <see cref="FragmentActivity"/> or <see cref="Fragment"/>.
        /// </exception>
        public static FragmentActivity? GetActivity(this INavigationView<IViewModel> view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.As(
                activity => activity,
                fragment => fragment.Activity);
        }
    }
}
