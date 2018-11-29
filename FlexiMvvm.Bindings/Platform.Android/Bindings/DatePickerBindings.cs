﻿// Copyright 2018 EPAM Systems, Inc.
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
    public static class DatePickerBindings
    {
        [NotNull]
        public static TargetItemBinding<DatePicker, DateTime> DateTimeBinding(
            [NotNull] this IItemReference<DatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<DatePicker, DateTime>(
                datePickerReference,
                (datePicker, dateTime) => datePicker.NotNull().DateTime = dateTime,
                () => "DateTime");
        }

        [NotNull]
        public static TargetItemBinding<DatePicker, int> FirstDayOfWeekBinding(
            [NotNull] this IItemReference<DatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<DatePicker, int>(
                datePickerReference,
                (datePicker, firstDayOfWeek) => datePicker.NotNull().FirstDayOfWeek = firstDayOfWeek,
                () => "FirstDayOfWeek");
        }

        [NotNull]
        public static TargetItemBinding<DatePicker, long> MaxDateBinding(
            [NotNull] this IItemReference<DatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<DatePicker, long>(
                datePickerReference,
                (datePicker, maxDate) => datePicker.NotNull().MaxDate = maxDate,
                () => "MaxDate");
        }

        [NotNull]
        public static TargetItemBinding<DatePicker, long> MinDateBinding(
            [NotNull] this IItemReference<DatePicker> datePickerReference)
        {
            if (datePickerReference == null)
                throw new ArgumentNullException(nameof(datePickerReference));

            return new TargetItemOneWayCustomBinding<DatePicker, long>(
                datePickerReference,
                (datePicker, minDate) => datePicker.NotNull().MinDate = minDate,
                () => "MinDate");
        }
    }
}