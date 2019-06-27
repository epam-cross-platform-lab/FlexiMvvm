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

namespace FlexiMvvm.Bindings
{
    public static class TextViewExtensions
    {
        public static TargetItemBinding<TextView, string> AfterTextChangedBinding(
            this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, AfterTextChangedEventArgs>(
                textViewReference,
                (textView, handler) => textView.AfterTextChanged += handler,
                (textView, handler) => textView.AfterTextChanged -= handler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.Enabled = canExecuteCommand;
                    }
                },
                (textView, args) => textView.Text,
                () => $"{nameof(TextView.AfterTextChanged)}");
        }

        public static TargetItemBinding<TextView, string> BeforeTextChangedBinding(
            this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, handler) => textView.BeforeTextChanged += handler,
                (textView, handler) => textView.BeforeTextChanged -= handler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.Enabled = canExecuteCommand;
                    }
                },
                (textView, args) => textView.Text,
                () => $"{nameof(TextView.BeforeTextChanged)}");
        }

        public static TargetItemBinding<TextView, string> ErrorBinding(
            this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, error) => textView.Error = error,
                () => $"{nameof(TextView.Error)}");
        }

        public static TargetItemBinding<TextView, string> HintBinding(
            this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, hint) => textView.Hint = hint,
                () => $"{nameof(TextView.Hint)}");
        }

        public static TargetItemBinding<TextView, string> SetErrorBinding(
            this IItemReference<TextView> textViewReference,
            Drawable icon)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));
            if (icon == null)
                throw new ArgumentNullException(nameof(icon));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, error) => textView.SetError(error, icon),
                () => $"{nameof(TextView.SetError)}");
        }

        public static TargetItemBinding<TextView, int> SetHintBinding(
            this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, resId) => textView.SetHint(resId),
                () => $"{nameof(TextView.SetHint)}");
        }

        public static TargetItemBinding<TextView, string> SetTextBinding(
            this IItemReference<TextView> textViewReference,
            TextView.BufferType bufferType)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));
            if (bufferType == null)
                throw new ArgumentNullException(nameof(bufferType));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.SetText(text, bufferType),
                () => $"{nameof(TextView.SetText)}");
        }

        public static TargetItemBinding<TextView, string> TextAndTextChangedBinding(
            this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemTwoWayCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, handler) => textView.TextChanged += handler,
                (textView, handler) => textView.TextChanged -= handler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.Enabled = canExecuteCommand;
                    }
                },
                (textView, args) => textView.Text,
                (textView, text) => textView.Text = text,
                () => $"{nameof(TextView.Text)}And{nameof(TextView.TextChanged)}");
        }

        public static TargetItemBinding<TextView, string> TextBinding(
            this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.Text = text,
                () => $"{nameof(TextView.Text)}");
        }

        public static TargetItemBinding<TextView, string> TextChangedBinding(
            this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, TextChangedEventArgs>(
                textViewReference,
                (textView, handler) => textView.TextChanged += handler,
                (textView, handler) => textView.TextChanged -= handler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.Enabled = canExecuteCommand;
                    }
                },
                (textView, args) => textView.Text,
                () => $"{nameof(TextView.TextChanged)}");
        }

        public static TargetItemBinding<TextView, ICharSequence> TextFormattedBinding(
            this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, ICharSequence>(
                textViewReference,
                (textView, textFormatted) => textView.TextFormatted = textFormatted,
                () => $"{nameof(TextView.TextFormatted)}");
        }
    }
}
