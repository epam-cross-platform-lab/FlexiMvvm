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
    public static class ViewExtensions
    {
        [NotNull]
        public static Android.Support.V4.App.FragmentActivity GetActivity([NotNull] this IView view)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));

            return view.As(
                activity => activity,
                fragment => fragment.NotNull().Activity).NotNull();
        }

        public static void As(
            [NotNull] this IView view,
            [NotNull] Action<Android.Support.V4.App.FragmentActivity> activityAction,
            [NotNull] Action<Android.Support.V4.App.Fragment> fragmentAction)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityAction == null)
                throw new ArgumentNullException(nameof(activityAction));
            if (fragmentAction == null)
                throw new ArgumentNullException(nameof(fragmentAction));

            if (view is Android.Support.V4.App.FragmentActivity activity)
            {
                activityAction(activity);
            }
            else if (view is Android.Support.V4.App.Fragment fragment)
            {
                fragmentAction(fragment);
            }
        }

        [CanBeNull]
        public static T As<T>(
            [NotNull] this IView view,
            [NotNull] Func<Android.Support.V4.App.FragmentActivity, T> activityFunc,
            [NotNull] Func<Android.Support.V4.App.Fragment, T> fragmentFunc)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (activityFunc == null)
                throw new ArgumentNullException(nameof(activityFunc));
            if (fragmentFunc == null)
                throw new ArgumentNullException(nameof(fragmentFunc));

            T result = default;

            if (view is Android.Support.V4.App.FragmentActivity activity)
            {
                result = activityFunc(activity);
            }
            else if (view is Android.Support.V4.App.Fragment fragment)
            {
                result = fragmentFunc(fragment);
            }

            return result;
        }
    }
}
