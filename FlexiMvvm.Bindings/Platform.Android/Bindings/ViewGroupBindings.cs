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
using Android.Views;
using Android.Views.Animations;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewGroupBindings
    {
        /// <summary>
        /// One way to source binding on <see cref="ViewGroup.AnimationEnd"/> event.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="ViewGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="ViewGroup.AnimationEnd"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, object> AnimationEndBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewGroup, object, Animation.AnimationEndEventArgs>(
                viewGroupReference,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationEnd += eventHandler,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationEnd -= eventHandler,
                (viewGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewGroup, eventArgs) => null,
                () => "AnimationEnd");
        }

        /// <summary>
        /// One way to source binding on <see cref="ViewGroup.AnimationRepeat"/> event.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="ViewGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="ViewGroup.AnimationRepeat"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, object> AnimationRepeatBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewGroup, object, Animation.AnimationRepeatEventArgs>(
                viewGroupReference,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationRepeat += eventHandler,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationRepeat -= eventHandler,
                (viewGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewGroup, eventArgs) => null,
                () => "AnimationRepeat");
        }

        /// <summary>
        /// One way to source binding on <see cref="ViewGroup.AnimationStart"/> event.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="ViewGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="ViewGroup.AnimationStart"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, object> AnimationStartBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewGroup, object, Animation.AnimationStartEventArgs>(
                viewGroupReference,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationStart += eventHandler,
                (viewGroup, eventHandler) => viewGroup.NotNull().AnimationStart -= eventHandler,
                (viewGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewGroup, eventArgs) => null,
                () => "AnimationStart");
        }

        /// <summary>
        /// One way to source binding on <see cref="ViewGroup.ChildViewAdded"/> event.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="ViewGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="ViewGroup.ChildViewAdded"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, object> ChildViewAddedBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewGroup, object, ViewGroup.ChildViewAddedEventArgs>(
                viewGroupReference,
                (viewGroup, eventHandler) => viewGroup.NotNull().ChildViewAdded += eventHandler,
                (viewGroup, eventHandler) => viewGroup.NotNull().ChildViewAdded -= eventHandler,
                (viewGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewGroup, eventArgs) => null,
                () => "ChildViewAdded");
        }

        /// <summary>
        /// One way to source binding on <see cref="ViewGroup.ChildViewRemoved"/> event.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="ViewGroup.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>One way to source binding on <see cref="ViewGroup.ChildViewRemoved"/> event.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, object> ChildViewRemovedBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewGroup, object, ViewGroup.ChildViewRemovedEventArgs>(
                viewGroupReference,
                (viewGroup, eventHandler) => viewGroup.NotNull().ChildViewRemoved += eventHandler,
                (viewGroup, eventHandler) => viewGroup.NotNull().ChildViewRemoved -= eventHandler,
                (viewGroup, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewGroup.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewGroup, eventArgs) => null,
                () => "ChildViewRemoved");
        }

        /// <summary>
        /// One way binding on <see cref="ViewGroup.MotionEventSplittingEnabled"/> property.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ViewGroup.MotionEventSplittingEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, bool> MotionEventSplittingEnabledBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayCustomBinding<ViewGroup, bool>(
                viewGroupReference,
                (viewGroup, motionEventSplittingEnabled) => viewGroup.NotNull().MotionEventSplittingEnabled = motionEventSplittingEnabled,
                () => "MotionEventSplittingEnabled");
        }

        /// <summary>
        /// One way binding on <see cref="ViewGroup.TouchscreenBlocksFocus"/> property.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ViewGroup.TouchscreenBlocksFocus"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, bool> TouchscreenBlocksFocusBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayCustomBinding<ViewGroup, bool>(
                viewGroupReference,
                (viewGroup, touchscreenBlocksFocus) => viewGroup.NotNull().TouchscreenBlocksFocus = touchscreenBlocksFocus,
                () => "TouchscreenBlocksFocus");
        }

        /// <summary>
        /// One way binding on <see cref="ViewGroup.TransitionGroup"/> property.
        /// </summary>
        /// <param name="viewGroupReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ViewGroup.TransitionGroup"/> property.</returns>
        /// <exception cref="ArgumentNullException">viewGroupReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ViewGroup, bool> TransitionGroupBinding(
            [NotNull] this IItemReference<ViewGroup> viewGroupReference)
        {
            if (viewGroupReference == null)
                throw new ArgumentNullException(nameof(viewGroupReference));

            return new TargetItemOneWayCustomBinding<ViewGroup, bool>(
                viewGroupReference,
                (viewGroup, transitionGroup) => viewGroup.NotNull().TransitionGroup = transitionGroup,
                () => "TransitionGroup");
        }
    }
}
