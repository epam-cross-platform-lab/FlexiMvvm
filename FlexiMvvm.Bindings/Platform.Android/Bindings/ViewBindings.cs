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
        /// <summary>
        /// One way binding on <see cref="View.Activated"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Activated"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Alpha"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Alpha"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Background"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Background"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Bottom"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Bottom"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.Click"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.Click"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.ContextClick"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.ContextClick"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.ContextMenuCreated"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.ContextMenuCreated"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Clickable"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Clickable"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ClipToOutline"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ClipToOutline"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ContentDescription"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ContentDescription"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.Drag"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.Drag"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.DrawingCacheEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.DrawingCacheEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.DuplicateParentStateEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.DuplicateParentStateEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Elevation"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Elevation"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Enabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Enabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.FilterTouchesWhenObscured"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.FilterTouchesWhenObscured"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Focusable"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Focusable"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.FocusableInTouchMode"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.FocusableInTouchMode"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.FocusChange"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="focusDirection">The focus direction.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.FocusChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.GenericMotion"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.GenericMotion"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.HapticFeedbackEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.HapticFeedbackEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.HasTransientState"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.HasTransientState"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.HorizontalScrollBarEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.HorizontalScrollBarEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.Hover"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.Hover"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Hovered"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Hovered"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.KeepScreenOn"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.KeepScreenOn"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.KeyPress"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.KeyPress"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.LayoutChange"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.LayoutChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Left"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Left"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.LongClickable"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.LongClickable"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.LongClick"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.LongClick"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.NestedScrollingEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.NestedScrollingEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Pressed"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Pressed"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Right"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Right"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.SaveEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.SaveEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.SaveFromParentEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.SaveFromParentEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScaleX"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScaleX"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScaleY"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScaleY"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScrollBarDefaultDelayBeforeFade"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScrollBarDefaultDelayBeforeFade"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScrollBarFadeDuration"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScrollBarFadeDuration"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScrollbarFadingEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScrollbarFadingEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.ScrollBarSize"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.ScrollBarSize"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Selected"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Selected"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.SetMinimumHeight(int)"/> method.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.SetMinimumHeight(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.SetMinimumWidth(int)"/> method.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.SetMinimumWidth(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.SoundEffectsEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.SoundEffectsEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.SystemUiVisibilityChange"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.SystemUiVisibilityChange"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Top"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Top"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.Touch"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.Touch"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.VerticalFadingEdgeEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.VerticalFadingEdgeEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.VerticalScrollBarEnabled"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.VerticalScrollBarEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.ViewAttachedToWindow"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.ViewAttachedToWindow"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="View.ViewDetachedFromWindow"/> event.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="View.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="View.ViewDetachedFromWindow"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="View.Visibility"/> property.
        /// </summary>
        /// <param name="viewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="View.Visibility"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewReference is null.</exception>
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
