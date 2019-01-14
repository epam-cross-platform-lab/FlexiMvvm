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

using Android.Text;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class EditTextExtensions
    {
        [NotNull]
        public static TargetItemBinding<EditText, string> TextAndTextChangedBinding(
            [NotNull] this IItemReference<EditText> editTextReference,
            bool trackCanExecuteCommandChanged = false)
        {
            return new TargetItemTwoWayCustomBinding<EditText, string, TextChangedEventArgs>(
                editTextReference,
                (editText, eventHandler) => editText.NotNull().TextChanged += eventHandler,
                (editText, eventHandler) => editText.NotNull().TextChanged -= eventHandler,
                (editText, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        editText.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (editText, eventArgs) => editText.NotNull().Text,
                (editText, text) => editText.NotNull().Text = text,
                () => "TextAndTextChanged");
        }
    }
}
