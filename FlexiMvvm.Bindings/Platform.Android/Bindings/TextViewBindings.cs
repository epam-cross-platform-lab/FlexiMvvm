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
using Android.Text;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class TextViewBindings
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
                () => "AfterTextChanged");
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
                () => "BeforeTextChanged");
        }

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
        /// Binding that sets a hint text color for <see cref="TextView"/>.
        /// <para>
        /// Supported types for <see cref="TValue"/>: <see cref="Color"/>, <see cref="ColorStateList"/>
        /// </para>
        /// <para>
        /// Usage: <c>.For(v => v.SetHintTextColorBinding&lt;ColorStateList&gt;())</c>
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The text view reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">textViewReference</exception>
        /// <exception cref="NotSupportedException">textViewReference</exception>
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
                        case ColorStateList colorStateList:
                            textView.NotNull().SetHintTextColor(colorStateList);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextColorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetHintTextColor");
        }

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
        /// Binding that sets a text color for <see cref="TextView"/>.
        /// <para>
        /// Supported types for <see cref="TValue"/>: <see cref="Color"/>, <see cref="ColorStateList"/>
        /// </para>
        /// <para>
        /// Usage: <c>.For(v => v.SetTextColorBinding&lt;Color&gt;())</c>
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="textViewReference">The text view reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">textViewReference</exception>
        /// <exception cref="NotSupportedException"><see cref="TValue"/></exception>
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
                        case ColorStateList colorStateList:
                            textView.NotNull().SetTextColor(colorStateList);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetTextColorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetTextColor");
        }

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

        [NotNull]
        public static TargetItemBinding<TextView, string> SetTextKeepStateBinding(
            [NotNull] this IItemReference<TextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<TextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().SetTextKeepState(text),
                () => "SetTextKeepState");
        }

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
