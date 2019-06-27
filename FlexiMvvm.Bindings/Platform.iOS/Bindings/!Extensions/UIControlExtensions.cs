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
    public static class UIControlExtensions
    {
        public static TargetItemBinding<UIControl, object> AllEditingEventsBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.AllEditingEvents += handler,
                (control, handler) => control.AllEditingEvents -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.AllEditingEvents)}");
        }

        public static TargetItemBinding<UIControl, object> AllEventsBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.AllEvents += handler,
                (control, handler) => control.AllEvents -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.AllEvents)}");
        }

        public static TargetItemBinding<UIControl, object> AllTouchEventsBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.AllTouchEvents += handler,
                (control, handler) => control.AllTouchEvents -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.AllTouchEvents)}");
        }

        public static TargetItemBinding<UIControl, object> EditingChangedBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.EditingChanged += handler,
                (control, handler) => control.EditingChanged -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.EditingChanged)}");
        }

        public static TargetItemBinding<UIControl, object> EditingDidBeginBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.EditingDidBegin += handler,
                (control, handler) => control.EditingDidBegin -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.EditingDidBegin)}");
        }

        public static TargetItemBinding<UIControl, object> EditingDidEndBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.EditingDidEnd += handler,
                (control, handler) => control.EditingDidEnd -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.EditingDidEnd)}");
        }

        public static TargetItemBinding<UIControl, object> EditingDidEndOnExitBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.EditingDidEndOnExit += handler,
                (control, handler) => control.EditingDidEndOnExit -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.EditingDidEndOnExit)}");
        }

        public static TargetItemBinding<UIControl, bool> EnabledBinding(
            this IItemReference<UIControl> controlReference)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayCustomBinding<UIControl, bool>(
                controlReference,
                (control, enabled) => control.Enabled = enabled,
                () => $"{nameof(UIControl.Enabled)}");
        }

        public static TargetItemBinding<UIControl, bool> HighlightedBinding(
            this IItemReference<UIControl> controlReference,
            UIControlState forState = UIControlState.Normal)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayCustomBinding<UIControl, bool>(
                controlReference,
                (control, highlighted) => control.Highlighted = highlighted,
                () => $"{nameof(UIControl.Highlighted)}");
        }

        public static TargetItemBinding<UIControl, object> PrimaryActionTriggeredBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.PrimaryActionTriggered += handler,
                (control, handler) => control.PrimaryActionTriggered -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.PrimaryActionTriggered)}");
        }

        public static TargetItemBinding<UIControl, bool> SelectedBinding(
            this IItemReference<UIControl> controlReference,
            UIControlState forState = UIControlState.Normal)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayCustomBinding<UIControl, bool>(
                controlReference,
                (control, selected) => control.Selected = selected,
                () => $"{nameof(UIControl.Selected)}");
        }

        public static TargetItemBinding<UIControl, object> TouchCancelBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchCancel += handler,
                (control, handler) => control.TouchCancel -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchCancel)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDownBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDown += handler,
                (control, handler) => control.TouchDown -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDown)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDownRepeatBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDownRepeat += handler,
                (control, handler) => control.TouchDownRepeat -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDownRepeat)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDragEnterBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDragEnter += handler,
                (control, handler) => control.TouchDragEnter -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDragEnter)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDragExitBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDragExit += handler,
                (control, handler) => control.TouchDragExit -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDragExit)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDragInsideBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDragInside += handler,
                (control, handler) => control.TouchDragInside -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDragInside)}");
        }

        public static TargetItemBinding<UIControl, object> TouchDragOutsideBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchDragOutside += handler,
                (control, handler) => control.TouchDragOutside -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchDragOutside)}");
        }

        public static TargetItemBinding<UIControl, object> TouchUpInsideBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchUpInside += handler,
                (control, handler) => control.TouchUpInside -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchUpInside)}");
        }

        public static TargetItemBinding<UIControl, object> TouchUpOutsideBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.TouchUpOutside += handler,
                (control, handler) => control.TouchUpOutside -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.TouchUpOutside)}");
        }

        public static TargetItemBinding<UIControl, object> ValueChangedBinding(
            this IItemReference<UIControl> controlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (controlReference == null)
                throw new ArgumentNullException(nameof(controlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIControl, object>(
                controlReference,
                (control, handler) => control.ValueChanged += handler,
                (control, handler) => control.ValueChanged -= handler,
                (control, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        control.Enabled = canExecuteCommand;
                    }
                },
                control => null,
                () => $"{nameof(UIControl.ValueChanged)}");
        }
    }
}
