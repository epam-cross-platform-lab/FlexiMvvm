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
using FlexiMvvm.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class EventSourceViewControllerBindings
    {
        [NotNull]
        public static TargetItemBinding<IEventSourceViewController, object> ViewWillAppearBinding(
            [NotNull] this IItemReference<IEventSourceViewController> viewControllerReference)
        {
            if (viewControllerReference == null)
                throw new ArgumentNullException(nameof(viewControllerReference));

            return new TargetItemOneWayToSourceCustomBinding<IEventSourceViewController, object>(
                viewControllerReference,
                (viewController, eventHandler) => viewController.NotNull().ViewWillAppearCalled += eventHandler,
                (viewController, eventHandler) => viewController.NotNull().ViewWillAppearCalled -= eventHandler,
                (viewController, canExecuteCommand) => { },
                viewController => null,
                () => "ViewWillAppear");
        }

        [NotNull]
        public static TargetItemBinding<IEventSourceViewController, object> ViewDidAppearBinding(
            [NotNull] this IItemReference<IEventSourceViewController> viewControllerReference)
        {
            if (viewControllerReference == null)
                throw new ArgumentNullException(nameof(viewControllerReference));

            return new TargetItemOneWayToSourceCustomBinding<IEventSourceViewController, object>(
                viewControllerReference,
                (viewController, eventHandler) => viewController.NotNull().ViewDidAppearCalled += eventHandler,
                (viewController, eventHandler) => viewController.NotNull().ViewDidAppearCalled -= eventHandler,
                (viewController, canExecuteCommand) => { },
                viewController => null,
                () => "ViewDidAppear");
        }

        [NotNull]
        public static TargetItemBinding<IEventSourceViewController, object> ViewWillDisappearBinding(
            [NotNull] this IItemReference<IEventSourceViewController> viewControllerReference)
        {
            if (viewControllerReference == null)
                throw new ArgumentNullException(nameof(viewControllerReference));

            return new TargetItemOneWayToSourceCustomBinding<IEventSourceViewController, object>(
                viewControllerReference,
                (viewController, eventHandler) => viewController.NotNull().ViewWillDisappearCalled += eventHandler,
                (viewController, eventHandler) => viewController.NotNull().ViewWillDisappearCalled -= eventHandler,
                (viewController, canExecuteCommand) => { },
                viewController => null,
                () => "ViewWillDisappear");
        }

        [NotNull]
        public static TargetItemBinding<IEventSourceViewController, object> ViewDidDisappearBinding(
            [NotNull] this IItemReference<IEventSourceViewController> viewControllerReference)
        {
            if (viewControllerReference == null)
                throw new ArgumentNullException(nameof(viewControllerReference));

            return new TargetItemOneWayToSourceCustomBinding<IEventSourceViewController, object>(
                viewControllerReference,
                (viewController, eventHandler) => viewController.NotNull().ViewDidDisappearCalled += eventHandler,
                (viewController, eventHandler) => viewController.NotNull().ViewDidDisappearCalled -= eventHandler,
                (viewController, canExecuteCommand) => { },
                viewController => null,
                () => "ViewDidDisappear");
        }
    }
}
