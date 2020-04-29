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
    public static class CompoundButtonExtensions
    {
        public static TargetItemBinding<CompoundButton, bool> CheckedAndCheckedChangeBinding(
            this IItemReference<CompoundButton> compoundButtonReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemTwoWayCustomBinding<CompoundButton, bool, CompoundButton.CheckedChangeEventArgs>(
                compoundButtonReference,
                (compoundButton, handler) => compoundButton.CheckedChange += handler,
                (compoundButton, handler) => compoundButton.CheckedChange -= handler,
                (compoundButton, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        compoundButton.Enabled = canExecuteCommand;
                    }
                },
                (compoundButton, args) => args != null ? args.IsChecked : compoundButton.Checked,
                (compoundButton, @checked) => compoundButton.Checked = @checked,
                () => $"{nameof(CompoundButton.Checked)}And{nameof(CompoundButton.CheckedChange)}");
        }

        public static TargetItemBinding<CompoundButton, bool> CheckedBinding(
            this IItemReference<CompoundButton> compoundButtonReference)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayCustomBinding<CompoundButton, bool>(
                compoundButtonReference,
                (compoundButton, @checked) => compoundButton.Checked = @checked,
                () => $"{nameof(CompoundButton.Checked)}");
        }

        public static TargetItemBinding<CompoundButton, bool> CheckedChangeBinding(
            this IItemReference<CompoundButton> compoundButtonReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (compoundButtonReference == null)
                throw new ArgumentNullException(nameof(compoundButtonReference));

            return new TargetItemOneWayToSourceCustomBinding<CompoundButton, bool, CompoundButton.CheckedChangeEventArgs>(
                compoundButtonReference,
                (compoundButton, handler) => compoundButton.CheckedChange += handler,
                (compoundButton, handler) => compoundButton.CheckedChange -= handler,
                (compoundButton, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        compoundButton.Enabled = canExecuteCommand;
                    }
                },
                (compoundButton, args) => args.IsChecked,
                () => $"{nameof(CompoundButton.CheckedChange)}");
        }
    }
}
