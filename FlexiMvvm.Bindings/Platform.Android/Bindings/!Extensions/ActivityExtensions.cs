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
using Android.App;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class ActivityExtensions
    {
        public static TargetItemBinding<Activity, string> TitleBinding(
            this IItemReference<Activity> activityReference)
        {
            if (activityReference == null)
                throw new ArgumentNullException(nameof(activityReference));

            return new TargetItemOneWayCustomBinding<Activity, string>(
                activityReference,
                (activity, title) => activity.Title = title,
                () => $"{nameof(Activity.Title)}");
        }
    }
}
