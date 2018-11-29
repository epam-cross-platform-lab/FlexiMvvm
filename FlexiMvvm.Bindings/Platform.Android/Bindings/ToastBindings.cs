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
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ToastBindings
    {
        [NotNull]
        public static TargetItemBinding<Toast, ToastLength> DurationBinding(
            [NotNull] this IItemReference<Toast> toastReference)
        {
            if (toastReference == null)
                throw new ArgumentNullException(nameof(toastReference));

            return new TargetItemOneWayCustomBinding<Toast, ToastLength>(
                toastReference,
                (toast, duration) => toast.NotNull().Duration = duration,
                () => "Duration");
        }

        [NotNull]
        public static TargetItemBinding<Toast, TValue> SetTextBinding<TValue>(
            [NotNull] this IItemReference<Toast> toastReference)
        {
            if (toastReference == null)
                throw new ArgumentNullException(nameof(toastReference));

            return new TargetItemOneWayCustomBinding<Toast, TValue>(
                toastReference,
                (toast, value) =>
                {
                    switch (value)
                    {
                        case int resId:
                            toast.NotNull().SetText(resId);
                            break;
                        case ICharSequence charSequence:
                            toast.NotNull().SetText(charSequence);
                            break;
                        case string @string:
                            toast.NotNull().SetText(@string);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetText");
        }
    }
}
