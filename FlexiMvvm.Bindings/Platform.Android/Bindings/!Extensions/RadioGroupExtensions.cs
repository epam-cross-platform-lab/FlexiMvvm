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
using Android.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class RadioGroupExtensions
    {
        public static TargetItemBinding<RadioGroup, int> CheckAndCheckedChangeBinding(
            this IItemReference<RadioGroup> radioGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemTwoWayCustomBinding<RadioGroup, int, RadioGroup.CheckedChangeEventArgs>(
                radioGroupReference,
                (radioGroup, handler) => radioGroup.CheckedChange += handler,
                (radioGroup, handler) => radioGroup.CheckedChange -= handler,
                (radioGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        radioGroup.Enabled = canExecuteCommand;
                    }
                },
                (radioGroup, args) => args?.CheckedId ?? radioGroup.CheckedRadioButtonId,
                (radioGroup, id) => radioGroup.Check(id),
                () => $"{nameof(RadioGroup.Check)}And{nameof(RadioGroup.CheckedChange)}");
        }

        public static TargetItemBinding<RadioGroup, int> CheckBinding(
            this IItemReference<RadioGroup> radioGroupReference)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemOneWayCustomBinding<RadioGroup, int>(
                radioGroupReference,
                (radioGroup, id) => radioGroup.Check(id),
                () => $"{nameof(RadioGroup.Check)}");
        }

        public static TargetItemBinding<RadioGroup, int> CheckedChangeBinding(
            this IItemReference<RadioGroup> radioGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (radioGroupReference == null)
                throw new ArgumentNullException(nameof(radioGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<RadioGroup, int, RadioGroup.CheckedChangeEventArgs>(
                radioGroupReference,
                (radioGroup, handler) => radioGroup.CheckedChange += handler,
                (radioGroup, handler) => radioGroup.CheckedChange -= handler,
                (radioGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        radioGroup.Enabled = canExecuteCommand;
                    }
                },
                (radioGroup, args) => args.CheckedId,
                () => $"{nameof(RadioGroup.CheckedChange)}");
        }
    }
}
