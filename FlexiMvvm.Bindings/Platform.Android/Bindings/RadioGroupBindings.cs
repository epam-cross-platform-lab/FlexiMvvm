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
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class RadioGroupBindings
    {
        /// <summary>
        /// Two way binding on <see cref="RadioGroup.CheckedChange"/> event and <see cref="RadioGroup.Check"/> method.
        /// </summary>
        /// <param name="radioGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="RadioGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="RadioGroup.CheckedChange"/> event and <see cref="RadioGroup.Check"/> method.</returns>
        /// <exception cref="ArgumentNullException">radioGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RadioGroup, int> CheckAndCheckedChangeBinding(
            [NotNull] this IItemReference<RadioGroup> radioGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemTwoWayCustomBinding<RadioGroup, int, RadioGroup.CheckedChangeEventArgs>(
                radioGroupReference,
                (radioGroup, eventHandler) => radioGroup.NotNull().CheckedChange += eventHandler,
                (radioGroup, eventHandler) => radioGroup.NotNull().CheckedChange -= eventHandler,
                (radioGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        radioGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (radioGroup, eventArgs) => eventArgs?.CheckedId ?? radioGroup.NotNull().CheckedRadioButtonId,
                (radioGroup, id) => radioGroup.NotNull().Check(id),
                () => "CheckAndCheckedChange");
        }

        /// <summary>
        /// One way binding on <see cref="RadioGroup.Check(int)"/> method.
        /// </summary>
        /// <param name="radioGroupReference">The item reference.</param>
        /// <returns>One way binding on <see cref="RadioGroup.Check(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">radioGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RadioGroup, int> CheckBinding(
            [NotNull] this IItemReference<RadioGroup> radioGroupReference)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemOneWayCustomBinding<RadioGroup, int>(
                radioGroupReference,
                (radioGroup, index) => radioGroup.NotNull().Check(index),
                () => "Check");
        }

        /// <summary>
        /// One way to source binding on <see cref="RadioGroup.CheckedChange"/> event.
        /// </summary>
        /// <param name="radioGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="RadioGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="RadioGroup.CheckedChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">radioGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<RadioGroup, int> CheckedChangeBinding(
            [NotNull] this IItemReference<RadioGroup> radioGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<RadioGroup, int, RadioGroup.CheckedChangeEventArgs>(
                radioGroupReference,
                (radioGroup, eventHandler) => radioGroup.NotNull().CheckedChange += eventHandler,
                (radioGroup, eventHandler) => radioGroup.NotNull().CheckedChange -= eventHandler,
                (radioGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        radioGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (radioGroup, eventArgs) => eventArgs?.CheckedId ?? radioGroup.NotNull().CheckedRadioButtonId,
                () => "CheckedChange");
        }
    }
}
