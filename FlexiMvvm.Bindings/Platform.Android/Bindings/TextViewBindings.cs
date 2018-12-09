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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Text;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class TextViewBindings
    {
        /// <summary>
        /// Binding on <see cref="TextView.AfterTextChanged"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="SearchView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="TextView.AfterTextChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
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
                () => "AfterTextChanged");
        }

        /// <summary>
        /// Binding on <see cref="TextView.BeforeTextChanged"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="SearchView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="TextView.BeforeTextChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
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
                () => "BeforeTextChanged");
        }

        /// <summary>
        /// Binding on <see cref="TextView.EditorAction"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="SearchView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="TextView.EditorAction"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, string> EditorActionBinding(
            [NotNull] this IItemReference<TextView> textViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<TextView, string, TextView.EditorActionEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().EditorAction += eventHandler,
                (textView, eventHandler) => textView.NotNull().EditorAction -= eventHandler,
                (textView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (textView, eventArgs) => textView.NotNull().Text,
                () => "EditorAction");
        }

        /// <summary>
        /// Binding on <see cref="TextView.Error"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.Error"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, string> ErrorBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, error) => textView.NotNull().Error = error,
                () => "Error");
        }

        /// <summary>
        /// Binding on <see cref="TextView.FreezesText"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.FreezesText"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> FreezesTextBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, freezesText) => textView.NotNull().FreezesText = freezesText,
                () => "FreezesText");
        }

        /// <summary>
        /// Binding on <see cref="TextView.Hint"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.Hint"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, string> HintBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, hint) => textView.NotNull().Hint = hint,
                () => "Hint");
        }

        /// <summary>
        /// Binding on <see cref="TextView.LetterSpacing"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.LetterSpacing"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, float> LetterSpacingBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, float>(
                textViewReference,
                (textView, letterSpacing) => textView.NotNull().LetterSpacing = letterSpacing,
                () => "LetterSpacing");
        }

        /// <summary>
        /// Binding on <see cref="TextView.LinksClickable"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.LinksClickable"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> LinksClickableBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, linksClickable) => textView.NotNull().LinksClickable = linksClickable,
                () => "LinksClickable");
        }

        /// <summary>
        /// Binding on <see cref="TextView.PrivateImeOptions"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.PrivateImeOptions"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, string> PrivateImeOptionsBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, privateImeOptions) => textView.NotNull().PrivateImeOptions = privateImeOptions,
                () => "PrivateImeOptions");
        }

        /// <summary>
        /// Binding on <see cref="TextView.ShowSoftInputOnFocus"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.ShowSoftInputOnFocus"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> ShowSoftInputOnFocusBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, showSoftInputOnFocus) => textView.NotNull().ShowSoftInputOnFocus = showSoftInputOnFocus,
                () => "ShowSoftInputOnFocus");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetAllCaps(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetAllCaps(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetAllCapsBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, allCaps) => textView.NotNull().SetAllCaps(allCaps),
                () => "SetAllCaps");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetCursorVisible(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetCursorVisible(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetCursorVisibleBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, visible) => textView.NotNull().SetCursorVisible(visible),
                () => "SetCursorVisible");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetElegantTextHeight(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetElegantTextHeight(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetElegantTextHeightBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, elegant) => textView.NotNull().SetElegantTextHeight(elegant),
                () => "SetElegantTextHeight");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetEms(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetEms(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetEmsBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, elegant) => textView.NotNull().SetEms(elegant),
                () => "SetEms");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetError"/> method.
        /// <para>
        /// Supported parameters: <see cref="ICharSequence"/> error; <see cref="string"/> error.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="drawable">The drawable.</param>
        /// <returns>Binding on <see cref="TextView.SetError"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetErrorBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference,
            [NotNull] Drawable drawable)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case ICharSequence error:
                            textView.NotNull().SetError(error, drawable);
                            break;
                        case string error:
                            textView.NotNull().SetError(error, drawable);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetErrorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetErrorBinding");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetHeight(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetHeight(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetHeightBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, pixels) => textView.NotNull().SetHeight(pixels),
                () => "SetHeight");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetHighlightColor(Color)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetHighlightColor(Color)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, Color> SetHighlightColorBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, Color>(
                textViewReference,
                (textView, color) => textView.NotNull().SetHighlightColor(color),
                () => "SetHighlightColor");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetHint(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetHint(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetHintBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, resId) => textView.NotNull().SetHint(resId),
                () => "SetHint");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetHintTextColor"/> method.
        /// <para>
        /// Supported parameters: <see cref="Color"/> color; <see cref="ColorStateList"/> colors.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetHintTextColor"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetHintTextColorBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case Color color:
                            textView.NotNull().SetHintTextColor(color);
                            break;
                        case ColorStateList colors:
                            textView.NotNull().SetHintTextColor(colors);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextColorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetHintTextColor");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetHorizontallyScrolling(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetHorizontallyScrolling(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetHorizontallyScrollingBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, whether) => textView.NotNull().SetHorizontallyScrolling(whether),
                () => "SetHorizontallyScrolling");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetIncludeFontPadding(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetIncludeFontPadding(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetIncludeFontPaddingBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, includepad) => textView.NotNull().SetIncludeFontPadding(includepad),
                () => "SetIncludeFontPadding");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetInputExtras(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetInputExtras(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetInputExtrasBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, xmlResId) => textView.NotNull().SetInputExtras(xmlResId),
                () => "SetInputExtras");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetLines(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetLines(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetLinesBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, lines) => textView.NotNull().SetLines(lines),
                () => "SetLines");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetLinkTextColor"/> method.
        /// <para>
        /// Supported parameters: <see cref="Color"/> color; <see cref="ColorStateList"/> colors.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetLinkTextColor"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetLinkTextColorBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case Color color:
                            textView.NotNull().SetLinkTextColor(color);
                            break;
                        case ColorStateList colors:
                            textView.NotNull().SetLinkTextColor(colors);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetLinkTextColorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetLinkTextColor");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMaxEms(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMaxEms(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMaxEmsBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, maxEms) => textView.NotNull().SetMaxEms(maxEms),
                () => "SetMaxEms");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMaxHeight(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMaxHeight(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMaxHeightBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, maxPixels) => textView.NotNull().SetMaxHeight(maxPixels),
                () => "SetMaxHeight");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMaxLines(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMaxLines(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMaxLinesBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, maxLines) => textView.NotNull().SetMaxLines(maxLines),
                () => "SetMaxLines");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMaxWidth(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMaxWidth(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMaxWidthBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, maxPixels) => textView.NotNull().SetMaxWidth(maxPixels),
                () => "SetMaxWidth");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMinEms(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMinEms(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMinEmsBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, minEms) => textView.NotNull().SetMinEms(minEms),
                () => "SetMinEms");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMinHeight(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMinHeight(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMinHeightBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, minPixels) => textView.NotNull().SetMinHeight(minPixels),
                () => "SetMinHeight");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMinLines(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMinLines(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMinLinesBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, minLines) => textView.NotNull().SetMinLines(minLines),
                () => "SetMinLines");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetMinWidth(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetMinWidth(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetMinWidthBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, minPixels) => textView.NotNull().SetMinWidth(minPixels),
                () => "SetMinWidth");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetSelectAllOnFocus(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetSelectAllOnFocus(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetSelectAllOnFocusBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, selectAllOnFocus) => textView.NotNull().SetSelectAllOnFocus(selectAllOnFocus),
                () => "SetSelectAllOnFocus");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetSingleLine(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetSingleLine(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetSingleLineBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, singleLine) => textView.NotNull().SetSingleLine(singleLine),
                () => "SetSingleLine");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetText"/> method.
        /// <para>
        /// Supported parameters: <see cref="int"/> resId; <see cref="ICharSequence"/> text; <see cref="string"/> text.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="bufferType">The buffer type.</param>
        /// <returns>Binding on <see cref="TextView.SetText"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetTextBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference,
            [CanBeNull] TextView.BufferType bufferType = null)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case int resId:
                            textView.NotNull().SetText(resId, bufferType ?? TextView.BufferType.Normal);
                            break;
                        case ICharSequence text:
                            textView.NotNull().SetText(text, bufferType ?? TextView.BufferType.Normal);
                            break;
                        case string text:
                            textView.NotNull().SetText(text, bufferType ?? TextView.BufferType.Normal);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetText");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetTextColor"/> method.
        /// <para>
        /// Supported parameters: <see cref="Color"/> color; <see cref="ColorStateList"/> colors.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetTextColor"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetTextColorBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case Color color:
                            textView.NotNull().SetTextColor(color);
                            break;
                        case ColorStateList colors:
                            textView.NotNull().SetTextColor(colors);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextColorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetTextColor");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetTextIsSelectable(bool)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetTextIsSelectable(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, bool> SetTextIsSelectableBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, bool>(
                textViewReference,
                (textView, selectable) => textView.NotNull().SetTextIsSelectable(selectable),
                () => "SetTextIsSelectable");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetTextKeepState"/> method.
        /// <para>
        /// Supported parameters: <see cref="ICharSequence"/> text; <see cref="string"/> text.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="bufferType">The buffer type.</param>
        /// <returns>Binding on <see cref="TextView.SetTextKeepState"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, TValue> SetTextKeepStateBinding<TValue>(
            [NotNull] this IItemReference<TextView> textViewReference,
            [CanBeNull] TextView.BufferType bufferType = null)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, TValue>(
                textViewReference,
                (textView, value) =>
                {
                    switch (value)
                    {
                        case ICharSequence text:
                            textView.NotNull().SetTextKeepState(text, bufferType ?? TextView.BufferType.Normal);
                            break;
                        case string text:
                            textView.NotNull().SetTextKeepState(text, bufferType ?? TextView.BufferType.Normal);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextKeepStateBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetTextKeepState");
        }

        /// <summary>
        /// Binding on <see cref="TextView.SetWidth(int)"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.SetWidth(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, int> SetWidthBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, int>(
                textViewReference,
                (textView, pixels) => textView.NotNull().SetWidth(pixels),
                () => "SetWidth");
        }

        /// <summary>
        /// Binding on <see cref="TextView.Text"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, string> TextBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().Text = text,
                () => "Text");
        }

        /// <summary>
        /// Binding on <see cref="TextView.TextChanged"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="TextView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="TextView.TextChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
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
                () => "TextChanged");
        }

        /// <summary>
        /// Two way binding on <see cref="TextView.TextChanged"/> event and <see cref="TextView.Text"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="TextView.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="TextView.TextChanged"/> event and <see cref="TextView.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
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
                () => "TextAndTextChanged");
        }

        /// <summary>
        /// Binding on <see cref="TextView.TextFormatted"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.TextFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, ICharSequence> TextFormattedBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, ICharSequence>(
                textViewReference,
                (textView, textFormatted) => textView.NotNull().TextFormatted = textFormatted,
                () => "TextFormatted");
        }

        /// <summary>
        /// Binding on <see cref="TextView.TextScaleX"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.TextScaleX"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, float> TextScaleXBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, float>(
                textViewReference,
                (textView, textScaleX) => textView.NotNull().TextScaleX = textScaleX,
                () => "TextScaleX");
        }

        /// <summary>
        /// Binding on <see cref="TextView.TextSize"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="TextView.TextSize"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<TextView, float> TextSizeBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, float>(
                textViewReference,
                (textView, textSize) => textView.NotNull().TextSize = textSize,
                () => "TextSize");
        }
    }
}
