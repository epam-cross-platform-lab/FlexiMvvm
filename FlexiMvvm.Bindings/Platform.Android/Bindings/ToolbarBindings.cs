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
using Android.Support.V7.Widget;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ToolbarBindings
    {
        [NotNull]
        public static TargetItemBinding<Toolbar, Drawable> LogoBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, Drawable>(
                toolbarReference,
                (toolbar, logo) => toolbar.NotNull().Logo = logo,
                () => "Logo");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, string> LogoDescriptionBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, string>(
                toolbarReference,
                (toolbar, logoDescription) => toolbar.NotNull().LogoDescription = logoDescription,
                () => "LogoDescription");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, string> NavigationContentDescriptionBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, string>(
                toolbarReference,
                (toolbar, navigationContentDescription) => toolbar.NotNull().NavigationContentDescription = navigationContentDescription,
                () => "NavigationContentDescription");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, ICharSequence> NavigationContentDescriptionFormattedBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, ICharSequence>(
                toolbarReference,
                (toolbar, navigationContentDescription) => toolbar.NotNull().NavigationContentDescriptionFormatted = navigationContentDescription,
                () => "NavigationContentDescriptionFormatted");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, Drawable> NavigationIconBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, Drawable>(
                toolbarReference,
                (toolbar, navigationIcon) => toolbar.NotNull().NavigationIcon = navigationIcon,
                () => "NavigationIcon");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, object> MenuItemClickBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayToSourceCustomBinding<Toolbar, object, Toolbar.MenuItemClickEventArgs>(
                toolbarReference,
                (toolbar, eventHandler) => toolbar.NotNull().MenuItemClick += eventHandler,
                (toolbar, eventHandler) => toolbar.NotNull().MenuItemClick -= eventHandler,
                (toolbar, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        toolbar.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (toolbar, eventArgs) => eventArgs,
                () => "MenuItemClick");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, object> NavigationClickBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayToSourceCustomBinding<Toolbar, object, Toolbar.NavigationClickEventArgs>(
                toolbarReference,
                (toolbar, eventHandler) => toolbar.NotNull().NavigationClick += eventHandler,
                (toolbar, eventHandler) => toolbar.NotNull().NavigationClick -= eventHandler,
                (toolbar, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        toolbar.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (toolbar, eventArgs) => null,
                () => "NavigationClick");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, Drawable> OverflowIconBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, Drawable>(
                toolbarReference,
                (toolbar, overflowIcon) => toolbar.NotNull().OverflowIcon = overflowIcon,
                () => "OverflowIcon");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, string> SubtitleBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, string>(
                toolbarReference,
                (toolbar, subtitle) => toolbar.NotNull().Subtitle = subtitle,
                () => "Subtitle");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, ICharSequence> SubtitleFormattedBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, ICharSequence>(
                toolbarReference,
                (toolbar, subtitleFormatted) => toolbar.NotNull().SubtitleFormatted = subtitleFormatted,
                () => "SubtitleFormatted");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, string> TitleBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, string>(
                toolbarReference,
                (toolbar, title) => toolbar.NotNull().Title = title,
                () => "Title");
        }

        [NotNull]
        public static TargetItemBinding<Toolbar, ICharSequence> TitleFormattedBinding(
            [NotNull] this IItemReference<Toolbar> toolbarReference)
        {
            if (toolbarReference == null)
                throw new ArgumentNullException(nameof(toolbarReference));

            return new TargetItemOneWayCustomBinding<Toolbar, ICharSequence>(
                toolbarReference,
                (toolbar, titleFormatted) => toolbar.NotNull().TitleFormatted = titleFormatted,
                () => "TitleFormatted");
        }
    }
}
