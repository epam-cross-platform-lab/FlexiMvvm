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
    public static class UINavigationItemBindings
    {
        /// <summary>
        /// One way binding on <see cref="UINavigationItem.HidesBackButton"/> property.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.HidesBackButton"/> property.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, bool> HidesBackButtonBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hidesBackButton) => navigationItem.NotNull().HidesBackButton = hidesBackButton,
                () => "HidesBackButton");
        }

        /// <summary>
        /// One way binding on <see cref="UINavigationItem.HidesSearchBarWhenScrolling"/> property.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.HidesSearchBarWhenScrolling"/> property.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, bool> HidesSearchBarWhenScrollingBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hidesSearchBarWhenScrolling) => navigationItem.NotNull().HidesSearchBarWhenScrolling = hidesSearchBarWhenScrolling,
                () => "HidesSearchBarWhenScrolling");
        }

        /// <summary>
        /// One way binding on <see cref="UINavigationItem.LeftItemsSupplementBackButton"/> property.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.LeftItemsSupplementBackButton"/> property.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, bool> LeftItemsSupplementBackButtonBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, leftItemsSupplementBackButton) => navigationItem.NotNull().LeftItemsSupplementBackButton = leftItemsSupplementBackButton,
                () => "LeftItemsSupplementBackButton");
        }

        /// <summary>
        /// One way binding on <see cref="UINavigationItem.Prompt"/> property.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.Prompt"/> property.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, string> PromptBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, string>(
                navigationItemReference,
                (navigationItem, prompt) => navigationItem.NotNull().Prompt = prompt,
                () => "Prompt");
        }

        /// <summary>
        /// One way binding on <see cref="UINavigationItem.SetHidesBackButton"/> method.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UINavigationItem.SetHidesBackButton"/> method.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.SetHidesBackButton"/> method.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, bool> SetHidesBackButtonBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference,
            bool animated = true)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hides) => navigationItem.NotNull().SetHidesBackButton(hides, animated),
                () => "SetHidesBackButton");
        }

        /// <summary>
        /// One way binding on <see cref="UINavigationItem.Title"/> property.
        /// </summary>
        /// <param name="navigationItemReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UINavigationItem.Title"/> property.</returns>
        /// <exception cref="ArgumentNullException">navigationItemReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UINavigationItem, string> TitleBinding(
            [NotNull] this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, string>(
                navigationItemReference,
                (navigationItem, title) => navigationItem.NotNull().Title = title,
                () => "Title");
        }
    }
}
