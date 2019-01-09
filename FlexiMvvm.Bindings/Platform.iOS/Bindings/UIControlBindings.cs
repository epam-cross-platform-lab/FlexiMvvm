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
        /// <summary>
        /// One way to source binding on <see cref="UIControl.AllEditingEvents"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.AllEditingEvents"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.AllEvents"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.AllEvents"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.AllTouchEvents"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.AllTouchEvents"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.EditingChanged"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.EditingChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.EditingDidBegin"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.EditingDidBegin"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.EditingDidEnd"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.EditingDidEnd"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.EditingDidEndOnExit"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.EditingDidEndOnExit"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIControl.Enabled"/> property.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIControl.Enabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.PrimaryActionTriggered"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.PrimaryActionTriggered"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchCancel"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchCancel"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDown"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDown"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDownRepeat"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDownRepeat"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDragEnter"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDragEnter"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDragExit"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDragExit"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDragInside"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDragInside"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchDragOutside"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchDragOutside"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchUpInside"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchUpInside"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.TouchUpOutside"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.TouchUpOutside"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="UIControl.ValueChanged"/> event.
        /// </summary>
        /// <param name="controlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="UIControl.ValueChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">controlReference is null.</exception>
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
