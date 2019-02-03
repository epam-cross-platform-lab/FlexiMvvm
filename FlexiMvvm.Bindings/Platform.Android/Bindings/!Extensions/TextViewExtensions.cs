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
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class TextViewExtensions
    {
        [NotNull]
        public static TargetItemBinding<TextView, string> AfterTextChangedBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, AfterTextChangedEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().AfterTextChanged += eventHandler,
                (textView, eventHandler) => textView.NotNull().AfterTextChanged -= eventHandler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => textView.NotNull().Text,
                () => $"{nameof(TextView.AfterTextChanged)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> BeforeTextChangedBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().BeforeTextChanged += eventHandler,
                (textView, eventHandler) => textView.NotNull().BeforeTextChanged -= eventHandler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => textView.NotNull().Text,
                () => $"{nameof(TextView.BeforeTextChanged)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> ErrorBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, error) => textView.NotNull().Error = error,
                () => $"{nameof(TextView.Error)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> HintBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, hint) => textView.NotNull().Hint = hint,
                () => $"{nameof(TextView.Hint)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> SetErrorBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            [NotNull] Drawable icon)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));
            if (icon == null)
                throw new ArgumentNullException(nameof(icon));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, error) => textView.NotNull().SetError(error, icon),
                () => $"{nameof(TextView.SetError)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, int> SetHintBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, resId) => textView.NotNull().SetHint(resId),
                () => $"{nameof(TextView.SetHint)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> SetTextBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            [NotNull] TextView.BufferType bufferType)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));
            if (bufferType == null)
                throw new ArgumentNullException(nameof(bufferType));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().SetText(text, bufferType),
                () => $"{nameof(TextView.SetText)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> TextAndTextChangedBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemTwoWayCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().TextChanged += eventHandler,
                (textView, eventHandler) => textView.NotNull().TextChanged -= eventHandler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => textView.NotNull().Text,
                (textView, text) => textView.NotNull().Text = text,
                () => $"{nameof(TextView.Text)}And{nameof(TextView.TextChanged)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> TextBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().Text = text,
                () => $"{nameof(TextView.Text)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, string> TextChangedBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().TextChanged += eventHandler,
                (textView, eventHandler) => textView.NotNull().TextChanged -= eventHandler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => textView.NotNull().Text,
                () => $"{nameof(TextView.TextChanged)}");
        }

        [NotNull]
        public static TargetItemBinding<TextView, ICharSequence> TextFormattedBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, ICharSequence>(
                textViewReference,
                (textView, textFormatted) => textView.NotNull().TextFormatted = textFormatted,
                () => $"{nameof(TextView.TextFormatted)}");
        }
    }
}
