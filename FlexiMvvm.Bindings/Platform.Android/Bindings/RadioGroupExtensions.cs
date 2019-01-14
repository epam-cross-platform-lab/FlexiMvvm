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

using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class RadioGroupExtensions
    {
        [NotNull]
        public static TargetItemBinding<RadioGroup, int> CheckAndCheckedChangeBinding(
            [NotNull] this IItemReference<RadioGroup> radioGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
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
    }
}
