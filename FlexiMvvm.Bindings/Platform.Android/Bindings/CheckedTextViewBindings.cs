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
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class CheckedTextViewBindings
    {
        [NotNull]
        public static TargetItemBinding<CheckedTextView, bool> CheckedBinding(
            [NotNull] this IItemReference<CheckedTextView> checkedTextViewReference)
        {
            if (checkedTextViewReference == null)
                throw new ArgumentNullException(nameof(checkedTextViewReference));

            return new TargetItemOneWayCustomBinding<CheckedTextView, bool>(
                checkedTextViewReference,
                (checkedTextView, @checked) => checkedTextView.NotNull().Checked = @checked,
                () => "Checked");
        }

        [NotNull]
        public static TargetItemBinding<CheckedTextView, ColorStateList> CheckMarkTintListBinding(
            [NotNull] this IItemReference<CheckedTextView> checkedTextViewReference)
        {
            if (checkedTextViewReference == null)
                throw new ArgumentNullException(nameof(checkedTextViewReference));

            return new TargetItemOneWayCustomBinding<CheckedTextView, ColorStateList>(
                checkedTextViewReference,
                (checkedTextView, checkMarkTintList) => checkedTextView.NotNull().CheckMarkTintList = checkMarkTintList,
                () => "CheckMarkTintList");
        }

        [NotNull]
        public static TargetItemBinding<CheckedTextView, TValue> SetCheckMarkDrawableBinding<TValue>(
            [NotNull] this IItemReference<CheckedTextView> checkedTextViewReference)
        {
            if (checkedTextViewReference == null)
                throw new ArgumentNullException(nameof(checkedTextViewReference));

            return new TargetItemOneWayCustomBinding<CheckedTextView, TValue>(
                checkedTextViewReference,
                (checkedTextView, value) =>
                {
                    switch (value)
                    {
                        case Drawable drawable:
                            checkedTextView.NotNull().SetCheckMarkDrawable(drawable);
                            break;
                        case int resId:
                            checkedTextView.NotNull().SetCheckMarkDrawable(resId);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetCheckMarkDrawableBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetCheckMarkDrawable");
        }
    }
}
