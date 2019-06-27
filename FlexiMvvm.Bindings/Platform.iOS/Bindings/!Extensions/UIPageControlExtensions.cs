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
    public static class UIPageControlExtensions
    {
        public static TargetItemBinding<UIPageControl, nint> CurrentPageAndValueChangedBinding(
            this IItemReference<UIPageControl> pageControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemTwoWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, handler) => pageControl.ValueChanged += handler,
                (pageControl, handler) => pageControl.ValueChanged -= handler,
                (pageControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        pageControl.Enabled = canExecuteCommand;
                    }
                },
                pageControl => pageControl.CurrentPage,
                (pageControl, currentPage) => pageControl.CurrentPage = currentPage,
                () => $"{nameof(UIPageControl.CurrentPage)}And{nameof(UIPageControl.ValueChanged)}");
        }

        public static TargetItemBinding<UIPageControl, nint> CurrentPageBinding(
            this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, currentPage) => pageControl.CurrentPage = currentPage,
                () => $"{nameof(UIPageControl.CurrentPage)}");
        }

        public static TargetItemBinding<UIPageControl, bool> DefersCurrentPageDisplayBinding(
            this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, bool>(
                pageControlReference,
                (pageControl, defersCurrentPageDisplay) => pageControl.DefersCurrentPageDisplay = defersCurrentPageDisplay,
                () => $"{nameof(UIPageControl.DefersCurrentPageDisplay)}");
        }

        public static TargetItemBinding<UIPageControl, bool> HidesForSinglePageBinding(
            this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, bool>(
                pageControlReference,
                (pageControl, hidesForSinglePage) => pageControl.HidesForSinglePage = hidesForSinglePage,
                () => $"{nameof(UIPageControl.HidesForSinglePage)}");
        }

        public static TargetItemBinding<UIPageControl, nint> PagesBinding(
            this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, pages) => pageControl.Pages = pages,
                () => $"{nameof(UIPageControl.Pages)}");
        }

        public static TargetItemBinding<UIPageControl, nint> ValueChangedBinding(
            this IItemReference<UIPageControl> pageControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, handler) => pageControl.ValueChanged += handler,
                (pageControl, handler) => pageControl.ValueChanged -= handler,
                (pageControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        pageControl.Enabled = canExecuteCommand;
                    }
                },
                pageControl => pageControl.CurrentPage,
                () => $"{nameof(UIPageControl.ValueChanged)}");
        }
    }
}
