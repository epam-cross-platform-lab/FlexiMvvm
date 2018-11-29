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
    public static class TextSwitcherBindings
    {
        [NotNull]
        public static TargetItemBinding<TextSwitcher, TValue> SetCurrentText<TValue>(
            [NotNull] this IItemReference<TextSwitcher> textSwitcherReference)
        {
            if (textSwitcherReference == null)
                throw new ArgumentNullException(nameof(textSwitcherReference));

            return new TargetItemOneWayCustomBinding<TextSwitcher, TValue>(
                textSwitcherReference,
                (textSwitcher, value) =>
                {
                    switch (value)
                    {
                        case ICharSequence charSequence:
                            textSwitcher.NotNull().SetCurrentText(charSequence);
                            break;
                        case string @string:
                            textSwitcher.NotNull().SetCurrentText(@string);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetCurrentText)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetCurrentText");
        }

        [NotNull]
        public static TargetItemBinding<TextSwitcher, TValue> SetText<TValue>(
            [NotNull] this IItemReference<TextSwitcher> textSwitcherReference)
        {
            if (textSwitcherReference == null)
                throw new ArgumentNullException(nameof(textSwitcherReference));

            return new TargetItemOneWayCustomBinding<TextSwitcher, TValue>(
                textSwitcherReference,
                (textSwitcher, value) =>
                {
                    switch (value)
                    {
                        case ICharSequence charSequence:
                            textSwitcher.NotNull().SetText(charSequence);
                            break;
                        case string @string:
                            textSwitcher.NotNull().SetText(@string);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetCurrentText)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetText");
        }
    }
}
