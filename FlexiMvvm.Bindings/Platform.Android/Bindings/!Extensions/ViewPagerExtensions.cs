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
#if __ANDROID_29__
using AndroidX.ViewPager.Widget;
#else
using Android.Support.V4.View;
#endif
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class ViewPagerExtensions
    {
        public static TargetItemBinding<ViewPager, int> CurrentItemBinding(
            this IItemReference<ViewPager> viewPagerReference)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayCustomBinding<ViewPager, int>(
                viewPagerReference,
                (viewPager, currentItem) => viewPager.CurrentItem = currentItem,
                () => $"{nameof(ViewPager.CurrentItem)}");
        }

        public static TargetItemBinding<ViewPager, int> PageSelectedBinding(
            this IItemReference<ViewPager> viewPagerReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayToSourceCustomBinding<ViewPager, int, ViewPager.PageSelectedEventArgs>(
                viewPagerReference,
                (viewPager, handler) => viewPager.PageSelected += handler,
                (viewPager, handler) => viewPager.PageSelected -= handler,
                (viewPager, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewPager.Enabled = canExecuteCommand;
                    }
                },
                (viewPager, args) => args.Position,
                () => $"{nameof(ViewPager.PageSelected)}");
        }

        public static TargetItemBinding<ViewPager, int> SetCurrentItemAndPageSelectedBinding(
            this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemTwoWayCustomBinding<ViewPager, int, ViewPager.PageSelectedEventArgs>(
                viewPagerReference,
                (viewPager, handler) => viewPager.PageSelected += handler,
                (viewPager, handler) => viewPager.PageSelected -= handler,
                (viewPager, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        viewPager.Enabled = canExecuteCommand;
                    }
                },
                (viewPager, args) => args != null ? args.Position : viewPager.CurrentItem,
                (viewPager, item) => viewPager.SetCurrentItem(item, smoothScroll),
                () => $"{nameof(ViewPager.SetCurrentItem)}And{nameof(ViewPager.PageSelected)}");
        }

        public static TargetItemBinding<ViewPager, int> SetCurrentItemBinding(
            this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true)
        {
            if (viewPagerReference == null)
                throw new ArgumentNullException(nameof(viewPagerReference));

            return new TargetItemOneWayCustomBinding<ViewPager, int>(
                viewPagerReference,
                (viewPager, item) => viewPager.SetCurrentItem(item, smoothScroll),
                () => $"{nameof(ViewPager.SetCurrentItem)}");
        }
    }
}
