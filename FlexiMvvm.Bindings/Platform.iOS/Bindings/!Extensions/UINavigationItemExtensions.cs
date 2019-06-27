// =========================================================================
// Copyright 2019 EPAM Systems, Inc.
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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UINavigationItemExtensions
    {
        public static TargetItemBinding<UINavigationItem, bool> HidesBackButtonBinding(
            this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hidesBackButton) => navigationItem.HidesBackButton = hidesBackButton,
                () => $"{nameof(UINavigationItem.HidesBackButton)}");
        }

        public static TargetItemBinding<UINavigationItem, bool> HidesSearchBarWhenScrollingBinding(
            this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hidesSearchBarWhenScrolling) => navigationItem.HidesSearchBarWhenScrolling = hidesSearchBarWhenScrolling,
                () => $"{nameof(UINavigationItem.HidesSearchBarWhenScrolling)}");
        }

        public static TargetItemBinding<UINavigationItem, bool> LeftItemsSupplementBackButtonBinding(
            this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, leftItemsSupplementBackButton) => navigationItem.LeftItemsSupplementBackButton = leftItemsSupplementBackButton,
                () => $"{nameof(UINavigationItem.LeftItemsSupplementBackButton)}");
        }

        public static TargetItemBinding<UINavigationItem, string> PromptBinding(
            this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, string>(
                navigationItemReference,
                (navigationItem, prompt) => navigationItem.Prompt = prompt,
                () => $"{nameof(UINavigationItem.Prompt)}");
        }

        public static TargetItemBinding<UINavigationItem, bool> SetHidesBackButtonBinding(
            this IItemReference<UINavigationItem> navigationItemReference,
            bool animated = true)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, bool>(
                navigationItemReference,
                (navigationItem, hides) => navigationItem.SetHidesBackButton(hides, animated),
                () => $"{nameof(UINavigationItem.SetHidesBackButton)}");
        }

        public static TargetItemBinding<UINavigationItem, string> TitleBinding(
            this IItemReference<UINavigationItem> navigationItemReference)
        {
            if (navigationItemReference == null)
                throw new ArgumentNullException(nameof(navigationItemReference));

            return new TargetItemOneWayCustomBinding<UINavigationItem, string>(
                navigationItemReference,
                (navigationItem, title) => navigationItem.Title = title,
                () => $"{nameof(UINavigationItem.Title)}");
        }
    }
}
