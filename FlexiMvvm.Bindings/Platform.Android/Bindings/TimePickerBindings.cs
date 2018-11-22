// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class TimePickerBindings
    {
        [NotNull]
        public static TargetItemBinding<TimePicker, Java.Lang.Boolean> SetIs24HourViewBinding(
            [NotNull] this IItemReference<TimePicker> timePickerReference)
        {
            if (timePickerReference == null)
                throw new ArgumentNullException(nameof(timePickerReference));

            return new TargetItemOneWayCustomBinding<TimePicker, Java.Lang.Boolean>(
                timePickerReference,
                (timePicker, is24HourView) => timePicker.NotNull().SetIs24HourView(is24HourView),
                () => "SetIs24HourView");
        }

        [NotNull]
        public static TargetItemBinding<TimePicker, object> EditorActionBinding(
            [NotNull] this IItemReference<TimePicker> timePickerReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (timePickerReference == null)
                throw new ArgumentNullException(nameof(timePickerReference));

            return new TargetItemOneWayToSourceCustomBinding<TimePicker, object, TimePicker.TimeChangedEventArgs>(
                timePickerReference,
                (timePicker, eventHandler) => timePicker.NotNull().TimeChanged += eventHandler,
                (timePicker, eventHandler) => timePicker.NotNull().TimeChanged -= eventHandler,
                (timePicker, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        timePicker.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => eventArgs,
                () => "TimeChanged");
        }
    }
}
