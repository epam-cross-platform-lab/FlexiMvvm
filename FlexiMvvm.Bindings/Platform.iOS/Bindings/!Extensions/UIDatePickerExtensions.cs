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
using Foundation;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIDatePickerExtensions
    {
        public static TargetItemBinding<UIDatePicker, double> CountDownDurationBinding(
            this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, double>(
                datePickerReference,
                (datePicker, countDownDuration) => datePicker.CountDownDuration = countDownDuration,
                () => $"{nameof(UIDatePicker.CountDownDuration)}");
        }

        public static TargetItemBinding<UIDatePicker, NSDate> DateAndValueChangedBinding(
            this IItemReference<UIDatePicker> datePickerReference,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemTwoWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, handler) => datePicker.ValueChanged += handler,
                (datePicker, handler) => datePicker.ValueChanged -= handler,
                (datePicker, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        datePicker.Enabled = canExecuteCommand;
                    }
                },
                datePicker => datePicker.Date,
                (datePicker, date) =>
                {
                    if (date != null)
                    {
                        datePicker.SetDate(date, animated);
                    }
                },
                () => $"{nameof(UIDatePicker.Date)}And{nameof(UIDatePicker.ValueChanged)}");
        }

        public static TargetItemBinding<UIDatePicker, NSDate> DateBinding(
            this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, date) => datePicker.Date = date,
                () => $"{nameof(UIDatePicker.Date)}");
        }

        public static TargetItemBinding<UIDatePicker, NSDate> MaximumDateBinding(
            this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, maximumDate) => datePicker.MaximumDate = maximumDate,
                () => $"{nameof(UIDatePicker.MaximumDate)}");
        }

        public static TargetItemBinding<UIDatePicker, NSDate> MinimumDateBinding(
            this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, minimumDate) => datePicker.MinimumDate = minimumDate,
                () => $"{nameof(UIDatePicker.MinimumDate)}");
        }

        public static TargetItemBinding<UIDatePicker, nint> MinuteIntervalBinding(
            this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, nint>(
                datePickerReference,
                (datePicker, minuteInterval) => datePicker.MinuteInterval = minuteInterval,
                () => $"{nameof(UIDatePicker.MinuteInterval)}");
        }
    }
}
