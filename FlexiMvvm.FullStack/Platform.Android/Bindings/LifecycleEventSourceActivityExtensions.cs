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
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class LifecycleEventSourceActivityExtensions
    {
        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceActivity, object> OnOptionsItemSelectedBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceActivity> activityReference,
            int itemId)
        {
            if (activityReference == null)
                throw new ArgumentNullException(nameof(activityReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceActivity, object, OptionsItemSelectedEventArgs>(
                activityReference,
                (activity, eventHandler) => activity.NotNull().OnOptionsItemSelectedCalled += eventHandler,
                (activity, eventHandler) => activity.NotNull().OnOptionsItemSelectedCalled -= eventHandler,
                (activity, canExecuteCommand) => { },
                (activity, eventArgs) => null,
                (activity, eventArgs) =>
                {
                    if (eventArgs.NotNull().Item.ItemId == itemId)
                    {
                        eventArgs.Handled = true;

                        return true;
                    }

                    return false;
                },
                () => "OnOptionsItemSelected");
        }

        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceActivity, object> OnBackPressedBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceActivity> activityReference)
        {
            if (activityReference == null)
                throw new ArgumentNullException(nameof(activityReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceActivity, object, BackPressedEventArgs>(
                activityReference,
                (activity, eventHandler) => activity.NotNull().OnBackPressedCalled += eventHandler,
                (activity, eventHandler) => activity.NotNull().OnBackPressedCalled -= eventHandler,
                (activity, canExecuteCommand) => { },
                (activity, eventArgs) => null,
                (activity, eventArgs) =>
                {
                    eventArgs.NotNull().Handled = true;

                    return true;
                },
                () => "OnBackPressed");
        }
    }
}
