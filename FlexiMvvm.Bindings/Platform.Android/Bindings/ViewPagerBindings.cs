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
using Android.Support.V4.View;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewPagerBindings
    {
        [NotNull]
        public static TargetItemBinding<ViewPager, int> OffscreenPageLimitBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayCustomBinding<ViewPager, int>(
                viewPagerReference,
                (viewPager, offscreenPageLimit) => viewPager.NotNull().OffscreenPageLimit = offscreenPageLimit,
                () => "OffscreenPageLimit");
        }

        [NotNull]
        public static TargetItemBinding<ViewPager, int> PageMarginBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayCustomBinding<ViewPager, int>(
                viewPagerReference,
                (viewPager, pageMargin) => viewPager.NotNull().PageMargin = pageMargin,
                () => "PageMargin");
        }

        [NotNull]
        public static TargetItemBinding<ViewPager, int> PageSelectedBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewPager, int, ViewPager.PageSelectedEventArgs>(
                viewPagerReference,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected += eventHandler,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected -= eventHandler,
                (viewPager, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewPager.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewPager, eventArgs) => eventArgs?.Position ?? viewPager.NotNull().CurrentItem,
                () => "PageSelected");
        }

        [NotNull]
        public static TargetItemBinding<ViewPager, int> SetCurrentItemBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayCustomBinding<ViewPager, int>(
                viewPagerReference,
                (viewPager, item) => viewPager.NotNull().SetCurrentItem(item, smoothScroll),
                () => "SetCurrentItem");
        }

        [NotNull]
        public static TargetItemBinding<ViewPager, int> SetCurrentItemAndPageSelectedBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemTwoWayCustomBinding<ViewPager, int, ViewPager.PageSelectedEventArgs>(
                viewPagerReference,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected += eventHandler,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected -= eventHandler,
                (viewPager, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewPager.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewPager, eventArgs) => eventArgs?.Position ?? viewPager.NotNull().CurrentItem,
                (viewPager, currentItem) => viewPager.NotNull().SetCurrentItem(currentItem, smoothScroll),
                () => "SetCurrentItemAndPageSelected");
        }

        [NotNull]
        public static TargetItemBinding<ViewPager, int> ViewDetachedFromWindowBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewPager, int, ViewPager.PageSelectedEventArgs>(
                viewPagerReference,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected += eventHandler,
                (viewPager, eventHandler) => viewPager.NotNull().PageSelected -= eventHandler,
                (viewPager, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewPager.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (viewPager, eventArgs) => eventArgs?.Position ?? viewPager.NotNull().CurrentItem,
                () => "ViewDetachedFromWindow");
        }
    }
}
