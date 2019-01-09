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
        /// <summary>
        /// One way binding on <see cref="ActionBar.HideOffset"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.HideOffset"/> property.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="ActionBar.HideOnContentScrollEnabled"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.HideOnContentScrollEnabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="ActionBar.MenuVisibility"/> event.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="ActionBar.MenuVisibility"/> event.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ActionBar, bool> MenuVisibilityBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayToSourceCustomBinding<ActionBar, bool, ActionBar.MenuVisibilityEventArgs>(
                actionBarReference,
                (actionBar, eventHandler) => actionBar.NotNull().MenuVisibility += eventHandler,
                (actionBar, eventHandler) => actionBar.NotNull().MenuVisibility -= eventHandler,
                (actionBar, canExecuteCommand) => { },
                (actionBar, eventArgs) => eventArgs.NotNull().IsVisible,
                () => "MenuVisibility");
        }

        /// <summary>
        /// One way binding on <see cref="ActionBar.Subtitle"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.Subtitle"/> property.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="ActionBar.Title"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.Title"/> property.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="ActionBar.SetHomeActionContentDescription(string)"/> method.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.SetHomeActionContentDescription(string)"/> method.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ActionBar, string> SetHomeActionContentDescriptionBinding(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, string>(
                actionBarReference,
                (actionBar, description) => actionBar.NotNull().SetHomeActionContentDescription(description),
                () => "SetHomeActionContentDescription");
        }

        /// <summary>
        /// One way binding on <see cref="ActionBar.SetHomeAsUpIndicator(int)"/> method.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.SetHomeAsUpIndicator(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="ActionBar.SetHomeButtonEnabled(bool)"/> method.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ActionBar.SetHomeButtonEnabled(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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
