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
        /// <summary>
        /// Binding on <see cref="Toolbar.Logo"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.Logo"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.LogoDescription"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.LogoDescription"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.NavigationContentDescription"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.NavigationContentDescription"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.NavigationContentDescriptionFormatted"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.NavigationContentDescriptionFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.NavigationIcon"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.NavigationIcon"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.MenuItemClick"/> event.
        /// </summary>
        /// <param name="toolbarReference">The item reference..</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="Toolbar.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="Toolbar.MenuItemClick"/> event.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.NavigationClick"/> event.
        /// </summary>
        /// <param name="toolbarReference">The item reference..</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="Toolbar.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="Toolbar.NavigationClick"/> event.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.OverflowIcon"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.OverflowIcon"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.Subtitle"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.Subtitle"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.SubtitleFormatted"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.SubtitleFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.Title"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.Title"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="Toolbar.TitleFormatted"/> property.
        /// </summary>
        /// <param name="toolbarReference">The item reference.</param>
        /// <returns>Binding on <see cref="Toolbar.TitleFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">toolbarReference is null.</exception>
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
