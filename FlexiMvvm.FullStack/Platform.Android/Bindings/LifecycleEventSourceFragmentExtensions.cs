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
using FlexiMvvm.Views;
using JetBrains.Annotations;
using Fragment = Android.Support.V4.App.Fragment;

namespace FlexiMvvm.Bindings
{
    public static class LifecycleEventSourceFragmentExtensions
    {
        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnOptionsItemSelectedBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference,
            int itemId)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object, OptionsItemSelectedEventArgs>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnOptionsItemSelectedCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnOptionsItemSelectedCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                (fragment, eventArgs) => null,
                (fragment, eventArgs) =>
                {
                    if (eventArgs.NotNull().Item.ItemId == itemId)
                    {
                        eventArgs.Handled = true;

                        return true;
                    }

                    return false;
                },
                () => $"{nameof(Fragment.OnOptionsItemSelected)}");
        }
    }
}
