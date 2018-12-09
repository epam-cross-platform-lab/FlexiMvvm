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
using Android;
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class CompoundButtonBindings
    {
        /// <summary>
        /// Two way binding on <see cref="CompoundButton.CheckedChange"/> event and <see cref="CompoundButton.Checked"/> property.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="CompoundButton.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="CompoundButton.CheckedChange"/> event and <see cref="CompoundButton.Checked"/> property.</returns>
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
                (compoundButton, eventArgs) => compoundButton.NotNull().Checked,
                (compoundButton, @checked) => compoundButton.NotNull().Checked = @checked,
                () => "CheckedAndCheckedChange");
        }

        /// <summary>
        /// Binding on <see cref="CompoundButton.Checked"/> property.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <returns>Binding on <see cref="CompoundButton.Checked"/> property.</returns>
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
        /// Binding on <see cref="CompoundButton.CheckedChange"/> event.
        /// </summary>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="CompoundButton.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="CompoundButton.CheckedChange"/> event.</returns>
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
                (compoundButton, eventArgs) => compoundButton.NotNull().Checked,
                () => "CheckedChange");
        }

        /// <summary>
        /// Binding on <see cref="CompoundButton.SetButtonDrawable"/> method.
        /// <para>
        /// Supported parameters: <see cref="int"/> resId; <see cref="Drawable"/> drawable.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="compoundButtonReference">The item reference.</param>
        /// <returns>Binding on <see cref="CompoundButton.SetButtonDrawable"/> method.</returns>
        /// <exception cref="ArgumentNullException">compoundButtonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<CompoundButton, TValue> SetButtonDrawableBinding<TValue>(
            [NotNull] this IItemReference<CompoundButton> compoundButtonReference)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayCustomBinding<CompoundButton, TValue>(
                compoundButtonReference,
                (compoundButton, value) =>
                {
                    switch (value)
                    {
                        case int resId:
                            compoundButton.NotNull().SetButtonDrawable(resId);
                            break;
                        case Drawable drawable:
                            compoundButton.NotNull().SetButtonDrawable(drawable);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetButtonDrawableBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetButtonDrawable");
        }
    }
}
