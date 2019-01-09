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
        /// <summary>
        /// Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UIPageControl.CurrentPage"/> property.
        /// </summary>
        /// <param name="pageControlReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">if set to <c>true</c> than <see cref="UIPageControl.Enabled"/> will be <c>false</c> when corresponding command is executing.</param>
        /// <returns>Two way binding on <see cref="UIControl.ValueChanged"/> event and <see cref="UIPageControl.CurrentPage"/> property.</returns>
        /// <exception cref="ArgumentNullException">pageControlReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIPageControl.CurrentPage"/> property.
        /// </summary>
        /// <param name="pageControlReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIPageControl.CurrentPage"/> property.</returns>
        /// <exception cref="ArgumentNullException">pageControlReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIPageControl.DefersCurrentPageDisplay"/> property.
        /// </summary>
        /// <param name="pageControlReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIPageControl.DefersCurrentPageDisplay"/> property.</returns>
        /// <exception cref="ArgumentNullException">pageControlReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIPageControl.HidesForSinglePage"/> property.
        /// </summary>
        /// <param name="pageControlReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIPageControl.HidesForSinglePage"/> property.</returns>
        /// <exception cref="ArgumentNullException">pageControlReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="UIPageControl.Pages"/> property.
        /// </summary>
        /// <param name="pageControlReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIPageControl.Pages"/> property.</returns>
        /// <exception cref="ArgumentNullException">pageControlReference is null.</exception>
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
    }
}
