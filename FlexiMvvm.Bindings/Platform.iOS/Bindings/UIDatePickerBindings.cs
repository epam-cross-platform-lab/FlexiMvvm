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
using FlexiMvvm.Bindings.Custom;
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIDatePickerBindings
    {
        /// <summary>
        /// Binding on <see cref="UIDatePicker.CountDownDuration"/> property.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIDatePicker.CountDownDuration"/> property.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, double> CountDownDurationBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, double>(
                datePickerReference,
                (datePicker, countDownDuration) => datePicker.NotNull().CountDownDuration = countDownDuration,
                () => "CountDownDuration");
        }

        /// <summary>
        /// Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UIDatePicker.SetDate"/> method.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UIDatePicker.SetDate"/> method.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIDatePicker.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UIDatePicker.SetDate"/> method.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, NSDate> DateAndValueChangedBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemTwoWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, eventHandler) => datePicker.NotNull().ValueChanged += eventHandler,
                (datePicker, eventHandler) => datePicker.NotNull().ValueChanged -= eventHandler,
                (datePicker, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        datePicker.NotNull().Enabled = canExecuteCommand;
                    }
                },
                datePicker => datePicker.NotNull().Date,
                (datePicker, date) =>
                {
                    if (date != null)
                    {
                        datePicker.NotNull().SetDate(date, animated);
                    }
                },
                () => "DateAndValueChanged");
        }

        /// <summary>
        /// Binding on <see cref="UIDatePicker.Date"/> property.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIDatePicker.Date"/> property.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, NSDate> DateBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, date) => datePicker.NotNull().Date = date,
                () => "Date");
        }

        /// <summary>
        /// Binding on <see cref="UIDatePicker.MaximumDate"/> property.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIDatePicker.MaximumDate"/> property.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, NSDate> MaximumDateBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, maximumDate) => datePicker.NotNull().MaximumDate = maximumDate,
                () => "MaximumDate");
        }

        /// <summary>
        /// Binding on <see cref="UIDatePicker.MinimumDate"/> property.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIDatePicker.MinimumDate"/> property.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, NSDate> MinimumDateBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, NSDate>(
                datePickerReference,
                (datePicker, minimumDate) => datePicker.NotNull().MinimumDate = minimumDate,
                () => "MinimumDate");
        }

        /// <summary>
        /// Binding on <see cref="UIDatePicker.MinuteInterval"/> property.
        /// </summary>
        /// <param name="datePickerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIDatePicker.MinuteInterval"/> property.</returns>
        /// <exception cref="ArgumentNullException">datePickerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIDatePicker, nint> MinuteIntervalBinding(
            [NotNull] this IItemReference<UIDatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<UIDatePicker, nint>(
                datePickerReference,
                (datePicker, minuteInterval) => datePicker.NotNull().MinuteInterval = minuteInterval,
                () => "MinuteInterval");
        }
    }
}
