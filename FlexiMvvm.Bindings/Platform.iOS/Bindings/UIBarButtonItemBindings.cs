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
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIBarButtonItemBindings
    {
        /// <summary>
        /// Binding on <see cref="UIBarButtonItem.Clicked"/> event.
        /// </summary>
        /// <param name="barButtonItemReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIBarButtonItem.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Binding on <see cref="UIBarButtonItem.Clicked"/> event.</returns>
        /// <exception cref="ArgumentNullException">barButtonItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIBarButtonItem, object> ClickedBinding(
            [NotNull] this IItemReference<UIBarButtonItem> barButtonItemReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayToSourceCustomBinding<UIBarButtonItem, object>(
                barButtonItemReference,
                (barButtonItem, eventHandler) => barButtonItem.NotNull().Clicked += eventHandler,
                (barButtonItem, eventHandler) => barButtonItem.NotNull().Clicked -= eventHandler,
                (barButtonItem, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        barButtonItem.NotNull().Enabled = canExecuteCommand;
                    }
                },
                barButtonItem => null,
                () => "Clicked");
        }

        /// <summary>
        /// Binding on <see cref="UIBarButtonItem.Enabled"/> property.
        /// </summary>
        /// <param name="barButtonItemReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIBarButtonItem.Enabled"/> property.</returns>
        /// <exception cref="ArgumentNullException">barButtonItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIBarButtonItem, bool> EnabledBinding(
            [NotNull] this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, bool>(
                barButtonItemReference,
                (barButtonItem, enabled) => barButtonItem.NotNull().Enabled = enabled,
                () => "Enabled");
        }

        /// <summary>
        /// Binding on <see cref="UIBarButtonItem.Title"/> property.
        /// </summary>
        /// <param name="barButtonItemReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIBarButtonItem.Title"/> property.</returns>
        /// <exception cref="ArgumentNullException">barButtonItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIBarButtonItem, string> TitleBinding(
            [NotNull] this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, string>(
                barButtonItemReference,
                (barButtonItem, title) => barButtonItem.NotNull().Title = title,
                () => "Title");
        }

        /// <summary>
        /// Binding on <see cref="UIBarButtonItem.Width"/> property.
        /// </summary>
        /// <param name="barButtonItemReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIBarButtonItem.Width"/> property.</returns>
        /// <exception cref="ArgumentNullException">barButtonItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIBarButtonItem, nfloat> WidthBinding(
            [NotNull] this IItemReference<UIBarButtonItem> barButtonItemReference)
        {
            if (barButtonItemReference == null)
                throw new ArgumentNullException(nameof(barButtonItemReference));

            return new TargetItemOneWayCustomBinding<UIBarButtonItem, nfloat>(
                barButtonItemReference,
                (barButtonItem, width) => barButtonItem.NotNull().Width = width,
                () => "Width");
        }
    }
}
