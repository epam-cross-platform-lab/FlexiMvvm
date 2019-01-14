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

using Android.Support.V4.View;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ViewPagerExtensions
    {
        [NotNull]
        public static TargetItemBinding<ViewPager, int> SetCurrentItemAndPageSelectedBinding(
            [NotNull] this IItemReference<ViewPager> viewPagerReference,
            bool smoothScroll = true,
            bool trackCanExecuteCommandChanged = false)
        {
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
    }
}
