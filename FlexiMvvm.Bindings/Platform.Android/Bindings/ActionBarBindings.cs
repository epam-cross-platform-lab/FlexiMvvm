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
using Android.Support.V7.App;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ActionBarBindings
    {
        /// <summary>
        /// Binding on <see cref="ActionBar.HideOffset"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.HideOffset"/> property.</returns>
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
        /// Binding on <see cref="ActionBar.HideOnContentScrollEnabled"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.HideOnContentScrollEnabled"/> property.</returns>
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
        /// Binding on <see cref="ActionBar.MenuVisibility"/> event.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.MenuVisibility"/> event.</returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="ActionBar.Subtitle"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.Subtitle"/> property.</returns>
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
        /// Binding on <see cref="ActionBar.Title"/> property.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.Title"/> property.</returns>
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
        /// Binding on <see cref="ActionBar.SetHomeActionContentDescription"/> method.
        /// <para>
        /// Supported parameters: <see cref="int"/> resId; <see cref="ICharSequence"/> description; <see cref="string"/> description.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>
        /// Binding on <see cref="ActionBar.SetHomeActionContentDescription()"/> method.
        /// </returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<ActionBar, TValue> SetHomeActionContentDescriptionBinding<TValue>(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, TValue>(
                actionBarReference,
                (actionBar, value) =>
                {
                    switch (value)
                    {
                        case int resId:
                            actionBar.NotNull().SetHomeActionContentDescription(resId);
                            break;
                        case ICharSequence description:
                            actionBar.NotNull().SetHomeActionContentDescription(description);
                            break;
                        case string description:
                            actionBar.NotNull().SetHomeActionContentDescription(description);
                            break;
                        default:
                            throw new NotSupportedException($"\"{nameof(SetHomeActionContentDescriptionBinding)}\" doesn't support \"{typeof(TValue)}\" type.");
                    }
                },
                () => "SetHomeActionContentDescription");
        }

        /// <summary>
        /// Binding on <see cref="ActionBar.SetHomeAsUpIndicator()"/> method.
        /// <para>
        /// Supported parameters: <see cref="int"/> resId; <see cref="Drawable"/> indicator.
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>
        /// Binding on <see cref="ActionBar.SetHomeAsUpIndicator()"/> method.
        /// </returns>
        /// <exception cref="ArgumentNullException">actionBarReference is null.</exception>
        /// <exception cref="NotSupportedException">Type <see cref="TValue"/> is not supported.</exception>
        [NotNull]
        public static TargetItemBinding<ActionBar, TValue> SetHomeAsUpIndicatorBinding<TValue>(
            [NotNull] this IItemReference<ActionBar> actionBarReference)
        {
            if (actionBarReference == null)
                throw new ArgumentNullException(nameof(actionBarReference));

            return new TargetItemOneWayCustomBinding<ActionBar, TValue>(
                actionBarReference,
                (actionBar, value) =>
                {
                    switch (value)
                    {
                        case int resId:
                            actionBar.NotNull().SetHomeAsUpIndicator(resId);
                            break;
                        case Drawable indicator:
                            actionBar.NotNull().SetHomeAsUpIndicator(indicator);
                            break;
                        default:
                            throw new NotSupportedException($"\"{nameof(SetHomeAsUpIndicatorBinding)}\" doesn't support \"{typeof(TValue)}\" type.");
                    }
                },
                () => "SetHomeAsUpIndicator");
        }

        /// <summary>
        /// Binding on <see cref="ActionBar.SetHomeButtonEnabled(bool)"/> method.
        /// </summary>
        /// <param name="actionBarReference">The item reference.</param>
        /// <returns>Binding on <see cref="ActionBar.SetHomeButtonEnabled(bool)"/> method.</returns>
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
