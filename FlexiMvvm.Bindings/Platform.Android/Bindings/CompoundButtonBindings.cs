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
using System.Windows.Input;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class CompoundButtonBindings
    {
        /// <summary>
        /// Two way binding on <see cref="CompoundButton.Checked"/> property and <see cref="CompoundButton.CheckedChange"/> event.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="CompoundButton.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>Two way binding on <see cref="CompoundButton.Checked"/> property and <see cref="CompoundButton.CheckedChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">compoundButtonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<CompoundButton, bool> CheckedAndCheckedChangeBinding(
            [NotNull] this IItemReference<CompoundButton> compoundButtonReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemTwoWayCustomBinding<CompoundButton, bool, CompoundButton.CheckedChangeEventArgs>(
                compoundButtonReference,
                (compoundButton, eventHandler) => compoundButton.NotNull().CheckedChange += eventHandler,
                (compoundButton, eventHandler) => compoundButton.NotNull().CheckedChange -= eventHandler,
                (compoundButton, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        compoundButton.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (compoundButton, eventArgs) => eventArgs?.IsChecked ?? compoundButton.NotNull().Checked,
                (compoundButton, @checked) => compoundButton.NotNull().Checked = @checked,
                () => "CheckedAndCheckedChange");
        }

        /// <summary>
        /// One way binding on <see cref="CompoundButton.Checked"/> property.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <returns>One way binding on <see cref="CompoundButton.Checked"/> property.</returns>
        /// <exception cref="ArgumentNullException">compoundButtonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<CompoundButton, bool> CheckedBinding(
            [NotNull] this IItemReference<CompoundButton> compoundButtonReference)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayCustomBinding<CompoundButton, bool>(
                compoundButtonReference,
                (compoundButton, @checked) => compoundButton.NotNull().Checked = @checked,
                () => "Checked");
        }

        /// <summary>
        /// One way to source binding on <see cref="CompoundButton.CheckedChange"/> event.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="CompoundButton.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>One way to source binding on <see cref="CompoundButton.CheckedChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">compoundButtonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<CompoundButton, bool> CheckedChangeBinding(
            [NotNull] this IItemReference<CompoundButton> compoundButtonReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayToSourceCustomBinding<CompoundButton, bool, CompoundButton.CheckedChangeEventArgs>(
                compoundButtonReference,
                (compoundButton, eventHandler) => compoundButton.NotNull().CheckedChange += eventHandler,
                (compoundButton, eventHandler) => compoundButton.NotNull().CheckedChange -= eventHandler,
                (compoundButton, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        compoundButton.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (compoundButton, eventArgs) => eventArgs.NotNull().IsChecked,
                () => "CheckedChange");
        }

        /// <summary>
        /// One way binding on <see cref="CompoundButton.SetButtonDrawable(int)"/> method.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <returns>One way binding on <see cref="CompoundButton.SetButtonDrawable(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">compoundButtonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<CompoundButton, int> SetButtonDrawableBinding(
            [NotNull] this IItemReference<CompoundButton> compoundButtonReference)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayCustomBinding<CompoundButton, int>(
                compoundButtonReference,
                (compoundButton, resId) => compoundButton.NotNull().SetButtonDrawable(resId),
                () => "SetButtonDrawable");
        }
    }
}
