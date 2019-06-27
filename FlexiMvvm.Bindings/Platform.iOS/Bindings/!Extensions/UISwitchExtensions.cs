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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UISwitchExtensions
    {
        public static TargetItemBinding<UISwitch, bool> OnBinding(
            this IItemReference<UISwitch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, on) => @switch.On = on,
                () => $"{nameof(UISwitch.On)}");
        }

        public static TargetItemBinding<UISwitch, bool> SetStateBinding(
            this IItemReference<UISwitch> switchReference,
            bool animated = true)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, newState) => @switch.SetState(newState, animated),
                () => $"{nameof(UISwitch.SetState)}");
        }

        public static TargetItemBinding<UISwitch, bool> SetStateAndValueChangedBinding(
            this IItemReference<UISwitch> switchReference,
            bool animated = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemTwoWayCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, handler) => @switch.ValueChanged += handler,
                (@switch, handler) => @switch.ValueChanged -= handler,
                (@switch, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        @switch.Enabled = canExecuteCommand;
                    }
                },
                @switch => @switch.On,
                (@switch, newState) => @switch.SetState(newState, animated),
                () => $"{nameof(UISwitch.SetState)}And{nameof(UISwitch.ValueChanged)}");
        }

        public static TargetItemBinding<UISwitch, bool> ValueChangedBinding(
            this IItemReference<UISwitch> switchReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayToSourceCustomBinding<UISwitch, bool>(
                switchReference,
                (@switch, handler) => @switch.ValueChanged += handler,
                (@switch, handler) => @switch.ValueChanged -= handler,
                (@switch, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        @switch.Enabled = canExecuteCommand;
                    }
                },
                @switch => @switch.On,
                () => $"{nameof(UISwitch.ValueChanged)}");
        }
    }
}
