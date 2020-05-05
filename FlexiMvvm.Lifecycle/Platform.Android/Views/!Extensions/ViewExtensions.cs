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
#if __ANDROID_29__
using AndroidX.Fragment.App;
#else
using Android.Support.V4.App;
#endif
using FlexiMvvm.Formatters;
using FlexiMvvm.ViewModels;

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
        /// <param name="view">The view that is represented by an activity or fragment.</param>
        /// <param name="activityHandler">The handler to execute if <paramref name="view"/> is <see cref="Android.Support.V4.App.FragmentActivity"/>.</param>
        /// <param name="fragmentHandler">The handler to execute if <paramref name="view"/> is <see cref="Android.Support.V4.App.Fragment"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="activityHandler" /> or <paramref name="fragmentHandler" /> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="view" /> is derived from a class other than the <see cref="Android.Support.V4.App.FragmentActivity"/> or <see cref="Android.Support.V4.App.Fragment"/>.
        /// </exception>
        public static void As(
            this IView<ILifecycleViewModel> view,
            Action<FragmentActivity> activityHandler,
            Action<Fragment> fragmentHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityHandler == null)
                throw new ArgumentNullException(nameof(activityHandler));
            if (fragmentHandler == null)
                throw new ArgumentNullException(nameof(fragmentHandler));

            if (view is FragmentActivity activity)
            {
                activityHandler(activity);
            }
            else if (view is Fragment fragment)
            {
                fragmentHandler(fragment);
            }
            else
            {
                throw new ArgumentException(
                    $"Only views derived from the '{TypeFormatter.FormatName<FragmentActivity>()}' or " +
                    $"'{TypeFormatter.FormatName<Fragment>()}' are supported.", nameof(view));
            }
        }

        /// <summary>
        /// Executes appropriate handler based on actual type of the <paramref name="view"/> with returning a result.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="view">The view that is represented by an activity or fragment.</param>
        /// <param name="activityHandler">The handler to execute if <paramref name="view"/> is <see cref="Android.Support.V4.App.FragmentActivity"/>.</param>
        /// <param name="fragmentHandler">The handler to execute if <paramref name="view"/> is <see cref="Android.Support.V4.App.Fragment"/>.</param>
        /// <returns>A result returned by appropriate handler.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="view" /> or <paramref name="activityHandler" /> or <paramref name="fragmentHandler" /> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">
        /// The <paramref name="view" /> is derived from a class other than the <see cref="Android.Support.V4.App.FragmentActivity"/> or <see cref="Android.Support.V4.App.Fragment"/>.
        /// </exception>
        public static T As<T>(
            this IView<ILifecycleViewModel> view,
            Func<FragmentActivity, T> activityHandler,
            Func<Fragment, T> fragmentHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityHandler == null)
                throw new ArgumentNullException(nameof(activityHandler));
            if (fragmentHandler == null)
                throw new ArgumentNullException(nameof(fragmentHandler));

            T result;

            if (view is FragmentActivity activity)
            {
                result = activityHandler(activity);
            }
            else if (view is Fragment fragment)
            {
                result = fragmentHandler(fragment);
            }
            else
            {
                throw new ArgumentException(
                    $"Only views derived from the '{TypeFormatter.FormatName<FragmentActivity>()}' or " +
                    $"'{TypeFormatter.FormatName<Fragment>()}' are supported.", nameof(view));
            }

            return result;
        }
    }
}
