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
    public static class UIControlBindings
    {
        [NotNull]
        public static TargetItemBinding<UIControl, object> AllEditingEventsBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().AllEditingEvents += eventHandler,
                (control, eventHandler) => control.NotNull().AllEditingEvents -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "AllEditingEvents");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> AllEventsBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().AllEvents += eventHandler,
                (control, eventHandler) => control.NotNull().AllEvents -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "AllEvents");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> AllTouchEventsBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().AllTouchEvents += eventHandler,
                (control, eventHandler) => control.NotNull().AllTouchEvents -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "AllTouchEvents");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> EditingChangedBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().EditingChanged += eventHandler,
                (control, eventHandler) => control.NotNull().EditingChanged -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "EditingChanged");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> EditingDidBeginBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().EditingDidBegin += eventHandler,
                (control, eventHandler) => control.NotNull().EditingDidBegin -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "EditingDidBegin");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> EditingDidEndBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().EditingDidEnd += eventHandler,
                (control, eventHandler) => control.NotNull().EditingDidEnd -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "EditingDidEnd");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> EditingDidEndOnExitBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().EditingDidEndOnExit += eventHandler,
                (control, eventHandler) => control.NotNull().EditingDidEndOnExit -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "EditingDidEndOnExit");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, bool> EnabledBinding(
            [NotNull] this IItemReference<UIControl> controlReference)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayCustomBinding<UIControl, bool>(
                controlReference,
                (control, enabled) => control.NotNull().Enabled = enabled,
                () => "Enabled");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> PrimaryActionTriggeredBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().PrimaryActionTriggered += eventHandler,
                (control, eventHandler) => control.NotNull().PrimaryActionTriggered -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "PrimaryActionTriggered");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchCancelBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchCancel += eventHandler,
                (control, eventHandler) => control.NotNull().TouchCancel -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchCancel");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDownBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDown += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDown -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDown");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDownRepeatBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDownRepeat += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDownRepeat -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDownRepeat");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDragEnterBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDragEnter += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDragEnter -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDragEnter");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDragExitBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDragExit += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDragExit -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDragExit");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDragInsideBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDragInside += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDragInside -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDragInside");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchDragOutsideBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchDragOutside += eventHandler,
                (control, eventHandler) => control.NotNull().TouchDragOutside -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchDragOutside");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchUpInsideBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchUpInside += eventHandler,
                (control, eventHandler) => control.NotNull().TouchUpInside -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchUpInside");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> TouchUpOutsideBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().TouchUpOutside += eventHandler,
                (control, eventHandler) => control.NotNull().TouchUpOutside -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "TouchUpOutside");
        }

        [NotNull]
        public static TargetItemBinding<UIControl, object> ValueChangedBinding(
            [NotNull] this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, eventHandler) => control.NotNull().ValueChanged += eventHandler,
                (control, eventHandler) => control.NotNull().ValueChanged -= eventHandler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.NotNull().Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => "ValueChanged");
        }
    }
}
