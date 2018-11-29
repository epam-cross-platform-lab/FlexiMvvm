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
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
        /// Binding on <see cref="ActionBar.SetHomeActionContentDescription()"/> method.
        /// <para>
        /// Supported types for <see cref="TValue"/>: <see cref="ICharSequence"/>, <see cref="string"/>, <see cref="int"/>
        /// </para>
        /// <para>
        /// Usage: <c>.For(v => v.SetHomeActionContentDescriptionBinding&lt;ICharSequence&gt;())</c>
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
        /// <exception cref="NotSupportedException">actionBarReference</exception>
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
                        case ICharSequence charSequence:
                            actionBar.NotNull().SetHomeActionContentDescription(charSequence);
                            break;
                        case string @string:
                            actionBar.NotNull().SetHomeActionContentDescription(@string);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetHomeActionContentDescriptionBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetHomeActionContentDescription");
        }

        /// <summary>
        /// Binding on <see cref="ActionBar.SetHomeAsUpIndicator()"/> method.
        /// <para>
        /// Supported types for <see cref="TValue"/>: <see cref="Drawable"/>, <see cref="int"/>
        /// </para>
        /// <para>
        /// Usage: <c>.For(v => v.SetHomeActionContentDescriptionBinding&lt;Drawable&gt;())</c>
        /// </para>
        /// </summary>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
        /// <exception cref="NotSupportedException">actionBarReference</exception>
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
                        case Drawable drawable:
                            actionBar.NotNull().SetHomeAsUpIndicator(drawable);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetHomeAsUpIndicatorBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetHomeAsUpIndicator");
        }

        /// <summary>
        /// Binding on <see cref="ActionBar.SetHomeButtonEnabled()"/> method.
        /// </summary>
        /// <param name="actionBarReference">The action bar reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">actionBarReference</exception>
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
