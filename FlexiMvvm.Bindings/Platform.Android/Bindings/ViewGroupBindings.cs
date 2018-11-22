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
using Android.Animation;
using Android.Graphics.Drawables;
using Android.Views;
using Android.Views.Animations;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewGroupBindings
    {
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
