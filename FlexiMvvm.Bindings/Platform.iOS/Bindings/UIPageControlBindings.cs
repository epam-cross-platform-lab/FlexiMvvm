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
    public static class UIPageControlBindings
    {
        [NotNull]
        public static TargetItemBinding<UIPageControl, nint> CurrentPageAndValueChangedBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemTwoWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, eventHandler) => pageControl.NotNull().ValueChanged += eventHandler,
                (pageControl, eventHandler) => pageControl.NotNull().ValueChanged -= eventHandler,
                (pageControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        pageControl.NotNull().Enabled = canExecuteCommand;
                    }
                },
                pageControl => pageControl.NotNull().CurrentPage,
                (pageControl, currentPage) => pageControl.NotNull().CurrentPage = currentPage,
                () => "CurrentPageAndValueChanged");
        }

        [NotNull]
        public static TargetItemBinding<UIPageControl, nint> CurrentPageBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, currentPage) => pageControl.NotNull().CurrentPage = currentPage,
                () => "CurrentPage");
        }

        [NotNull]
        public static TargetItemBinding<UIPageControl, bool> DefersCurrentPageDisplayBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, bool>(
                pageControlReference,
                (pageControl, defersCurrentPageDisplay) => pageControl.NotNull().DefersCurrentPageDisplay = defersCurrentPageDisplay,
                () => "DefersCurrentPageDisplay");
        }

        [NotNull]
        public static TargetItemBinding<UIPageControl, bool> HidesForSinglePageBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, bool>(
                pageControlReference,
                (pageControl, hidesForSinglePage) => pageControl.NotNull().HidesForSinglePage = hidesForSinglePage,
                () => "HidesForSinglePage");
        }

        [NotNull]
        public static TargetItemBinding<UIPageControl, nint> PagesBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, pages) => pageControl.NotNull().Pages = pages,
                () => "Pages");
        }

        [NotNull]
        public static TargetItemBinding<UIPageControl, nint> ValueChangedBinding(
            [NotNull] this IItemReference<UIPageControl> pageControlReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (pageControlReference == null)
                throw new ArgumentNullException(nameof(pageControlReference));

            return new TargetItemOneWayToSourceCustomBinding<UIPageControl, nint>(
                pageControlReference,
                (pageControl, eventHandler) => pageControl.NotNull().ValueChanged += eventHandler,
                (pageControl, eventHandler) => pageControl.NotNull().ValueChanged -= eventHandler,
                (pageControl, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        pageControl.NotNull().Enabled = canExecuteCommand;
                    }
                },
                pageControl => pageControl.NotNull().CurrentPage,
                () => "ValueChanged");
        }
    }
}
