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

namespace FlexiMvvm.Views
{
    /// <summary>
    /// Provides a set of <c>static</c> methods for accessing the <see cref="IView"/>.
    /// </summary>
    public static class ViewExtensions
    {
        /// <summary>
        /// Gets self if <paramref name="view"/> is <see cref="Android.Support.V4.App.FragmentActivity"/> or
        /// <see cref="Android.Support.V4.App.Fragment.Activity"/> property value if <paramref name="view"/> is <see cref="Android.Support.V4.App.Fragment"/>.
        /// </summary>
        /// <param name="view">The view reference.</param>
        /// <returns>The <see cref="Android.Support.V4.App.FragmentActivity"/> instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view"/> is <c>null</c>.</exception>
        [CanBeNull]
        public static Android.Support.V4.App.FragmentActivity GetActivity([NotNull] this IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.As(
                activity => activity,
                fragment => fragment.NotNull().Activity);
        }

        /// <summary>
        /// Executes <paramref name="activityHandler"/> if <paramref name="view"/> is <see cref="Android.Support.V4.App.FragmentActivity"/> or
        /// <paramref name="fragmentHandler"/> if <paramref name="view"/> is <see cref="Android.Support.V4.App.Fragment"/>.
        /// </summary>
        /// <param name="view">The view reference.</param>
        /// <param name="activityHandler">The activity handler.</param>
        /// <param name="fragmentHandler">The fragment handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="activityHandler" /> or <paramref name="fragmentHandler" /> is <c>null</c>.</exception>
        public static void As(
            [NotNull] this IView view,
            [NotNull] Action<Android.Support.V4.App.FragmentActivity> activityHandler,
            [NotNull] Action<Android.Support.V4.App.Fragment> fragmentHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityHandler == null)
                throw new ArgumentNullException(nameof(activityHandler));
            if (fragmentHandler == null)
                throw new ArgumentNullException(nameof(fragmentHandler));

            if (view is Android.Support.V4.App.FragmentActivity activity)
            {
                activityHandler(activity);
            }
            else if (view is Android.Support.V4.App.Fragment fragment)
            {
                fragmentHandler(fragment);
            }
        }

        /// <summary>
        /// Returns result of <paramref name="activityHandler"/> if <paramref name="view"/> is <see cref="Android.Support.V4.App.FragmentActivity"/> or
        /// <paramref name="fragmentHandler"/> if <paramref name="view"/> is <see cref="Android.Support.V4.App.Fragment"/>.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="view">The view reference.</param>
        /// <param name="activityHandler">The activity handler.</param>
        /// <param name="fragmentHandler">The fragment handler.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="activityHandler" /> or <paramref name="fragmentHandler" /> is <c>null</c>.</exception>
        /// <returns>Result of activity or fragment handler.</returns>
        [CanBeNull]
        public static T As<T>(
            [NotNull] this IView view,
            [NotNull] Func<Android.Support.V4.App.FragmentActivity, T> activityHandler,
            [NotNull] Func<Android.Support.V4.App.Fragment, T> fragmentHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityHandler == null)
                throw new ArgumentNullException(nameof(activityHandler));
            if (fragmentHandler == null)
                throw new ArgumentNullException(nameof(fragmentHandler));

            T result = default;

            if (view is Android.Support.V4.App.FragmentActivity activity)
            {
                result = activityHandler(activity);
            }
            else if (view is Android.Support.V4.App.Fragment fragment)
            {
                result = fragmentHandler(fragment);
            }

            return result;
        }
    }
}
