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
using Android.Graphics.Drawables;
using Android.Views;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewBindings
    {
        [NotNull]
        public static TargetItemBinding<View, bool> ActivatedBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, activated) => view.NotNull().Activated = activated,
                () => "Activated");
        }

        [NotNull]
        public static TargetItemBinding<View, float> AlphaBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, float>(
                viewReference,
                (view, alpha) => view.NotNull().Alpha = alpha,
                () => "Alpha");
        }

        [NotNull]
        public static TargetItemBinding<View, Drawable> BackgroundBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, Drawable>(
                viewReference,
                (view, background) => view.NotNull().Background = background,
                () => "Background");
        }

        [NotNull]
        public static TargetItemBinding<View, int> BottomBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, bottom) => view.NotNull().Bottom = bottom,
                () => "Bottom");
        }

        [NotNull]
        public static TargetItemBinding<View, object> ClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object>(
                viewReference,
                (view, eventHandler) => view.NotNull().Click += eventHandler,
                (view, eventHandler) => view.NotNull().Click -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                view => null,
                () => "Click");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> ContextClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.ContextClickEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().ContextClick += eventHandler,
                (view, eventHandler) => view.NotNull().ContextClick -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "ContextClick");
        }

        [NotNull]
        public static TargetItemBinding<View, object> ContextMenuCreatedBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.CreateContextMenuEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().ContextMenuCreated += eventHandler,
                (view, eventHandler) => view.NotNull().ContextMenuCreated -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "ContextMenuCreated");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> ClickableBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, clickable) => view.NotNull().Clickable = clickable,
                () => "Clickable");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> ClipToOutlineBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, clipToOutline) => view.NotNull().ClipToOutline = clipToOutline,
                () => "ClipToOutline");
        }

        [NotNull]
        public static TargetItemBinding<View, string> ContentDescriptionBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, string>(
                viewReference,
                (view, contentDescription) => view.NotNull().ContentDescription = contentDescription,
                () => "ContentDescription");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> DragBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.DragEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().Drag += eventHandler,
                (view, eventHandler) => view.NotNull().Drag -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "Drag");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> DrawingCacheEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, drawingCacheEnabled) => view.NotNull().DrawingCacheEnabled = drawingCacheEnabled,
                () => "DrawingCacheEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> DuplicateParentStateEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, duplicateParentStateEnabled) => view.NotNull().DuplicateParentStateEnabled = duplicateParentStateEnabled,
                () => "DuplicateParentStateEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, float> ElevationBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, float>(
                viewReference,
                (view, elevation) => view.NotNull().Elevation = elevation,
                () => "Elevation");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> EnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, enabled) => view.NotNull().Enabled = enabled,
                () => "Enabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> FilterTouchesWhenObscuredBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, filterTouchesWhenObscured) => view.NotNull().FilterTouchesWhenObscured = filterTouchesWhenObscured,
                () => "FilterTouchesWhenObscured");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> FocusableBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, focusable) => view.NotNull().Focusable = focusable,
                () => "Focusable");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> FocusableInTouchModeBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, focusableInTouchMode) => view.NotNull().FocusableInTouchMode = focusableInTouchMode,
                () => "FocusableInTouchMode");
        }

        [NotNull]
        public static TargetItemBinding<View, object> FocusChangeBinding(
            [NotNull] this IItemReference<View> viewReference,
            FocusDirection focusDirection,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.FocusChangeEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().FocusChange += eventHandler,
                (view, eventHandler) => view.NotNull().FocusChange -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) =>
                {
                    switch (focusDirection)
                    {
                        case FocusDirection.InOut:
                            return true;
                        case FocusDirection.In:
                            return eventArgs.NotNull().HasFocus;
                        case FocusDirection.Out:
                            return !eventArgs.NotNull().HasFocus;
                        default:
                            return false;
                    }
                },
                () => "FocusChange");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> GenericMotionBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.GenericMotionEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().GenericMotion += eventHandler,
                (view, eventHandler) => view.NotNull().GenericMotion -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "GenericMotion");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> HapticFeedbackEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, hapticFeedbackEnabled) => view.NotNull().HapticFeedbackEnabled = hapticFeedbackEnabled,
                () => "HapticFeedbackEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> HasTransientStateBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, hasTransientState) => view.NotNull().HasTransientState = hasTransientState,
                () => "HasTransientState");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> HorizontalScrollBarEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, horizontalScrollBarEnabled) => view.NotNull().HorizontalScrollBarEnabled = horizontalScrollBarEnabled,
                () => "HorizontalScrollBarEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> HoverBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.HoverEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().Hover += eventHandler,
                (view, eventHandler) => view.NotNull().Hover -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "Hover");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> HoveredBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, hovered) => view.NotNull().Hovered = hovered,
                () => "Hovered");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> KeepScreenOnBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, keepScreenOn) => view.NotNull().KeepScreenOn = keepScreenOn,
                () => "KeepScreenOn");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> KeyPressBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.KeyEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().KeyPress += eventHandler,
                (view, eventHandler) => view.NotNull().KeyPress -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "KeyPress");
        }

        [NotNull]
        public static TargetItemBinding<View, object> LayoutChangeBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.LayoutChangeEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().LayoutChange += eventHandler,
                (view, eventHandler) => view.NotNull().LayoutChange -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "LayoutChange");
        }

        [NotNull]
        public static TargetItemBinding<View, int> LeftBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, left) => view.NotNull().Left = left,
                () => "Left");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> LongClickableBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, longClickable) => view.NotNull().LongClickable = longClickable,
                () => "LongClickable");
        }

        [NotNull]
        public static TargetItemBinding<View, object> LongClickBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.LongClickEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().LongClick += eventHandler,
                (view, eventHandler) => view.NotNull().LongClick -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "LongClick");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> NestedScrollingEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, nestedScrollingEnabled) => view.NotNull().NestedScrollingEnabled = nestedScrollingEnabled,
                () => "NestedScrollingEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> PressedBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, pressed) => view.NotNull().Pressed = pressed,
                () => "Pressed");
        }

        [NotNull]
        public static TargetItemBinding<View, int> RightBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, right) => view.NotNull().Right = right,
                () => "Right");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> SaveEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, saveEnabled) => view.NotNull().SaveEnabled = saveEnabled,
                () => "SaveEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> SaveFromParentEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, saveFromParentEnabled) => view.NotNull().SaveFromParentEnabled = saveFromParentEnabled,
                () => "SaveFromParentEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, float> ScaleXBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, float>(
                viewReference,
                (view, scaleX) => view.NotNull().ScaleX = scaleX,
                () => "ScaleX");
        }

        [NotNull]
        public static TargetItemBinding<View, float> ScaleYBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, float>(
                viewReference,
                (view, scaleY) => view.NotNull().ScaleY = scaleY,
                () => "ScaleY");
        }

        [NotNull]
        public static TargetItemBinding<View, int> ScrollBarDefaultDelayBeforeFadeBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, scrollBarDefaultDelayBeforeFade) => view.NotNull().ScrollBarDefaultDelayBeforeFade = scrollBarDefaultDelayBeforeFade,
                () => "ScrollBarDefaultDelayBeforeFade");
        }

        [NotNull]
        public static TargetItemBinding<View, int> ScrollBarFadeDurationBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, barDefaultDelayBeforeFade) => view.NotNull().ScrollBarFadeDuration = barDefaultDelayBeforeFade,
                () => "ScrollBarFadeDuration");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> ScrollbarFadingEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, scrollbarFadingEnabled) => view.NotNull().ScrollbarFadingEnabled = scrollbarFadingEnabled,
                () => "ScrollbarFadingEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, int> ScrollBarSizeBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, scrollBarSize) => view.NotNull().ScrollBarSize = scrollBarSize,
                () => "ScrollBarSize");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> SelectedBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, selected) => view.NotNull().Selected = selected,
                () => "Selected");
        }

        [NotNull]
        public static TargetItemBinding<View, int> SetMinimumHeightBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, minHeight) => view.NotNull().SetMinimumHeight(minHeight),
                () => "SetMinimumHeight");
        }

        [NotNull]
        public static TargetItemBinding<View, int> SetMinimumWidthBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, minWidth) => view.NotNull().SetMinimumWidth(minWidth),
                () => "SetMinimumWidth");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> SoundEffectsEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, soundEffectsEnabled) => view.NotNull().SoundEffectsEnabled = soundEffectsEnabled,
                () => "SoundEffectsEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, StatusBarVisibility> SystemUiVisibilityChangeBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, StatusBarVisibility, View.SystemUiVisibilityChangeEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().SystemUiVisibilityChange += eventHandler,
                (view, eventHandler) => view.NotNull().SystemUiVisibilityChange -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Visibility,
                () => "SystemUiVisibilityChange");
        }

        [NotNull]
        public static TargetItemBinding<View, int> TopBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, int>(
                viewReference,
                (view, top) => view.NotNull().Top = top,
                () => "Top");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> TouchBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, bool, View.TouchEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().Touch += eventHandler,
                (view, eventHandler) => view.NotNull().Touch -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => eventArgs.Handled,
                () => "Touch");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> VerticalFadingEdgeEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, verticalFadingEdgeEnabled) => view.NotNull().VerticalFadingEdgeEnabled = verticalFadingEdgeEnabled,
                () => "VerticalFadingEdgeEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, bool> VerticalScrollBarEnabledBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, bool>(
                viewReference,
                (view, verticalScrollBarEnabled) => view.NotNull().VerticalScrollBarEnabled = verticalScrollBarEnabled,
                () => "VerticalScrollBarEnabled");
        }

        [NotNull]
        public static TargetItemBinding<View, object> ViewAttachedToWindowBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.ViewAttachedToWindowEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().ViewAttachedToWindow += eventHandler,
                (view, eventHandler) => view.NotNull().ViewAttachedToWindow -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "ViewAttachedToWindow");
        }

        [NotNull]
        public static TargetItemBinding<View, object> ViewDetachedFromWindowBinding(
            [NotNull] this IItemReference<View> viewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayToSourceCustomBinding<View, object, View.ViewDetachedFromWindowEventArgs>(
                viewReference,
                (view, eventHandler) => view.NotNull().ViewDetachedFromWindow += eventHandler,
                (view, eventHandler) => view.NotNull().ViewDetachedFromWindow -= eventHandler,
                (view, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        view.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (view, eventArgs) => null,
                () => "ViewDetachedFromWindow");
        }

        [NotNull]
        public static TargetItemBinding<View, ViewStates> VisibilityBinding(
            [NotNull] this IItemReference<View> viewReference)
        {
            if (viewReference == null)
                throw new ArgumentNullException(nameof(viewReference));

            return new TargetItemOneWayCustomBinding<View, ViewStates>(
                viewReference,
                (view, visibility) => view.NotNull().Visibility = visibility,
                () => "Visibility");
        }
    }
}
