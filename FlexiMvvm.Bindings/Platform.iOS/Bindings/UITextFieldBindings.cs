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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UITextFieldBindings
    {
        [NotNull]
        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, attributedText) => textField.NotNull().AttributedText = attributedText,
                () => "AttributedText");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextAndEditingChangedBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, eventHandler) => textField.NotNull().EditingChanged += eventHandler,
                (textField, eventHandler) => textField.NotNull().EditingChanged -= eventHandler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.NotNull().Enabled = canExecuteCommand;
                    }
                },
                textField => textField.NotNull().AttributedText,
                (textField, attributedText) => textField.NotNull().AttributedText = attributedText,
                () => "AttributedTextAndEditingChanged");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextAndEditingDidEndBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, eventHandler) => textField.NotNull().EditingDidEnd += eventHandler,
                (textField, eventHandler) => textField.NotNull().EditingDidEnd -= eventHandler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.NotNull().Enabled = canExecuteCommand;
                    }
                },
                textField => textField.NotNull().AttributedText,
                (textField, attributedText) => textField.NotNull().AttributedText = attributedText,
                () => "AttributedTextAndEditingDidEnd");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, bool> EnablesReturnKeyAutomaticallyBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, bool>(
                textFieldReference,
                (textField, enablesReturnKeyAutomatically) => textField.NotNull().EnablesReturnKeyAutomatically = enablesReturnKeyAutomatically,
                () => "EnablesReturnKeyAutomatically");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, string> InsertTextBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, text) => textField.NotNull().InsertText(text),
                () => "InsertText");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, string> PlaceholderBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, placeholder) => textField.NotNull().Placeholder = placeholder,
                () => "Placeholder");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, bool> SecureTextEntryBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, bool>(
                textFieldReference,
                (textField, secureTextEntry) => textField.NotNull().SecureTextEntry = secureTextEntry,
                () => "SecureTextEntry");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, string> TextBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, text) => textField.NotNull().Text = text,
                () => "Text");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, string> TextAndEditingChangedBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, eventHandler) => textField.NotNull().EditingChanged += eventHandler,
                (textField, eventHandler) => textField.NotNull().EditingChanged -= eventHandler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.NotNull().Enabled = canExecuteCommand;
                    }
                },
                textField => textField.NotNull().Text,
                (textField, text) => textField.NotNull().Text = text,
                () => "TextAndEditingChanged");
        }

        [NotNull]
        public static TargetItemBinding<UITextField, string> TextAndEditingDidEndBinding(
            [NotNull] this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, eventHandler) => textField.NotNull().EditingDidEnd += eventHandler,
                (textField, eventHandler) => textField.NotNull().EditingDidEnd -= eventHandler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.NotNull().Enabled = canExecuteCommand;
                    }
                },
                textField => textField.NotNull().Text,
                (textField, text) => textField.NotNull().Text = text,
                () => "TextAndEditingDidEnd");
        }
    }
}
