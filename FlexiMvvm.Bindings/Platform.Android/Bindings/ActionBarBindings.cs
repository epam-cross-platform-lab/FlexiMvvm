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
using Android.Support.V7.App;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ActionBarBindings
    {
        [NotNull]
        public static TargetItemBinding<ActionBar, int> HideOffsetBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, int>(
                actionBarReference,
                (actionBar, hideOffset) => actionBar.NotNull().HideOffset = hideOffset,
                () => "HideOffset");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, bool> HideOnContentScrollEnabledBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, bool>(
                actionBarReference,
                (actionBar, hideOnContentScrollEnabled) => actionBar.NotNull().HideOnContentScrollEnabled = hideOnContentScrollEnabled,
                () => "HideOnContentScrollEnabled");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, object> MenuVisibilityBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayToSourceCustomBinding<ActionBar, object, ActionBar.MenuVisibilityEventArgs>(
                actionBarReference,
                (actionBar, eventHandler) => actionBar.NotNull().MenuVisibility += eventHandler,
                (actionBar, eventHandler) => actionBar.NotNull().MenuVisibility -= eventHandler,
                (actionBar, canExecuteCommand) => { },
                (view, eventArgs) => eventArgs.IsVisible,
                () => "MenuVisibility");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, string> SubtitleBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, string>(
                actionBarReference,
                (actionBar, subtitle) => actionBar.NotNull().Subtitle = subtitle,
                () => "Subtitle");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, string> TitleBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, string>(
                actionBarReference,
                (actionBar, title) => actionBar.NotNull().Title = title,
                () => "Title");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, int> SetHomeActionContentDescriptionBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, int>(
                actionBarReference,
                (actionBar, resId) => actionBar.NotNull().SetHomeActionContentDescription(resId),
                () => "SetHomeActionContentDescription");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, int> SetHomeAsUpIndicatorBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, int>(
                actionBarReference,
                (actionBar, resId) => actionBar.NotNull().SetHomeAsUpIndicator(resId),
                () => "SetHomeAsUpIndicator");
        }

        [NotNull]
        public static TargetItemBinding<ActionBar, bool> SetHomeButtonEnabledBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, bool>(
                actionBarReference,
                (actionBar, enabled) => actionBar.NotNull().SetHomeButtonEnabled(enabled),
                () => "SetHomeButtonEnabled");
        }
    }
}
