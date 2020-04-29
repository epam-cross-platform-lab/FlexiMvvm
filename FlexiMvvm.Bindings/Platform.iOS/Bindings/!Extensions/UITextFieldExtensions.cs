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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UITextFieldExtensions
    {
        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, attributedText) => textField.AttributedText = attributedText,
                () => $"{nameof(UITextField.AttributedText)}");
        }

        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextAndEditingChangedBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, handler) => textField.EditingChanged += handler,
                (textField, handler) => textField.EditingChanged -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.AttributedText,
                (textField, attributedText) => textField.AttributedText = attributedText,
                () => $"{nameof(UITextField.AttributedText)}And{nameof(UITextField.EditingChanged)}");
        }

        public static TargetItemBinding<UITextField, NSAttributedString> AttributedTextAndEditingDidEndBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, NSAttributedString>(
                textFieldReference,
                (textField, handler) => textField.EditingDidEnd += handler,
                (textField, handler) => textField.EditingDidEnd -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.AttributedText,
                (textField, attributedText) => textField.AttributedText = attributedText,
                () => $"{nameof(UITextField.AttributedText)}And{nameof(UITextField.EditingDidEnd)}");
        }

        public static TargetItemBinding<UITextField, string> EditingChangedBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, handler) => textField.EditingChanged += handler,
                (textField, handler) => textField.EditingChanged -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.Text,
                () => nameof(UITextField.EditingChanged));
        }

        public static TargetItemBinding<UITextField, string> EditingDidEndBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, handler) => textField.EditingDidEnd += handler,
                (textField, handler) => textField.EditingDidEnd -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.Text,
                () => nameof(UITextField.EditingDidEnd));
        }

        public static TargetItemBinding<UITextField, bool> EnablesReturnKeyAutomaticallyBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, bool>(
                textFieldReference,
                (textField, enablesReturnKeyAutomatically) => textField.EnablesReturnKeyAutomatically = enablesReturnKeyAutomatically,
                () => $"{nameof(UITextField.EnablesReturnKeyAutomatically)}");
        }

        public static TargetItemBinding<UITextField, string> InsertTextBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, text) => textField.InsertText(text),
                () => $"{nameof(UITextField.InsertText)}");
        }

        public static TargetItemBinding<UITextField, UIKeyboardType> KeyboardTypeBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, UIKeyboardType>(
                textFieldReference,
                (textField, keyboardType) => textField.KeyboardType = keyboardType,
                () => nameof(UITextField.KeyboardType));
        }

        public static TargetItemBinding<UITextField, string> PlaceholderBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, placeholder) => textField.Placeholder = placeholder,
                () => $"{nameof(UITextField.Placeholder)}");
        }

        public static TargetItemBinding<UITextField, bool> SecureTextEntryBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, bool>(
                textFieldReference,
                (textField, secureTextEntry) => textField.SecureTextEntry = secureTextEntry,
                () => $"{nameof(UITextField.SecureTextEntry)}");
        }

        public static TargetItemBinding<UITextField, string> TextBinding(
            this IItemReference<UITextField> textFieldReference)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemOneWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, text) => textField.Text = text,
                () => $"{nameof(UITextField.Text)}");
        }

        public static TargetItemBinding<UITextField, string> TextAndEditingChangedBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, handler) => textField.EditingChanged += handler,
                (textField, handler) => textField.EditingChanged -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.Text,
                (textField, text) => textField.Text = text,
                () => $"{nameof(UITextField.Text)}And{nameof(UITextField.EditingChanged)}");
        }

        public static TargetItemBinding<UITextField, string> TextAndEditingDidEndBinding(
            this IItemReference<UITextField> textFieldReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (textFieldReference == null)
                throw new ArgumentNullException(nameof(textFieldReference));

            return new TargetItemTwoWayCustomBinding<UITextField, string>(
                textFieldReference,
                (textField, handler) => textField.EditingDidEnd += handler,
                (textField, handler) => textField.EditingDidEnd -= handler,
                (textField, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        textField.Enabled = canExecuteCommand;
                    }
                },
                textField => textField.Text,
                (textField, text) => textField.Text = text,
                () => $"{nameof(UITextField.Text)}And{nameof(UITextField.EditingDidEnd)}");
        }
    }
}
