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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UISwitchBindings
    {
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

        [NotNull]
        public static TargetItemBinding<UISwitch, bool> ValueChangedBinding(
            [NotNull] this IItemReference<UISwitch> switchReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayToSourceCustomBinding<UISwitch, bool>(
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
                () => "ValueChanged");
        }
    }
}
