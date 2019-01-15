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

namespace FlexiMvvm.Bindings
{
    public static class LifecycleEventSourceFragmentExtensions
    {
        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnActivityCreatedBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnActivityCreatedCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnActivityCreatedCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                fragment => null,
                () => "OnActivityCreated");
        }

        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnStartBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnStartCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnStartCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                fragment => null,
                () => "OnStart");
        }

        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnResumeBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnResumeCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnResumeCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                fragment => null,
                () => "OnResume");
        }

        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnPauseBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnPauseCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnPauseCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                fragment => null,
                () => "OnPause");
        }

        [NotNull]
        public static TargetItemBinding<ILifecycleEventSourceFragment, object> OnStopBinding(
            [NotNull] this IItemReference<ILifecycleEventSourceFragment> fragmentReference)
        {
            if (fragmentReference == null)
                throw new ArgumentNullException(nameof(fragmentReference));

            return new TargetItemOneWayToSourceCustomBinding<ILifecycleEventSourceFragment, object>(
                fragmentReference,
                (fragment, eventHandler) => fragment.NotNull().OnStopCalled += eventHandler,
                (fragment, eventHandler) => fragment.NotNull().OnStopCalled -= eventHandler,
                (fragment, canExecuteCommand) => { },
                fragment => null,
                () => "OnStop");
        }

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
                () => "OnOptionsItemSelected");
        }
    }
}
