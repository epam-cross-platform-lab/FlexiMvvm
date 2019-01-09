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
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UISwitchBindings
    {
        /// <summary>
        /// One way binding on <see cref="UISwitch.On"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISwitch.On"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISwitch, bool> OnBinding(
            [NotNull] this IItemReference<UISwitch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, on) => @switch.NotNull().On = on,
                () => "On");
        }

        /// <summary>
        /// One way binding on <see cref="UISwitch.SetState"/> method.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UISwitch.SetState"/> method.</param>
        /// <returns>One way binding on <see cref="UISwitch.SetState"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISwitch, bool> SetStateBinding(
            [NotNull] this IItemReference<UISwitch> switchReference,
            bool animated = true)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, newState) => @switch.NotNull().SetState(newState, animated),
                () => "SetState");
        }

        /// <summary>
        /// Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UISwitch.SetState"/> method.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UISwitch.SetState"/> method.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UISwitch.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UISwitch.SetState"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISwitch, bool> SetStateAndValueChangedBinding(
            [NotNull] this IItemReference<UISwitch> switchReference,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemTwoWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, eventHandler) => @switch.NotNull().ValueChanged += eventHandler,
                (@switch, eventHandler) => @switch.NotNull().ValueChanged -= eventHandler,
                (@switch, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        @switch.NotNull().Enabled = canExecuteCommand;
                    }
                },
                @switch => @switch.NotNull().On,
                (@switch, newState) => @switch.NotNull().SetState(newState, animated),
                () => "SetStateAndValueChanged");
        }
    }
}
