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
using System.Collections.Generic;
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class UIPageViewControllerObservableDataSourceBindings
    {
        [NotNull]
        public static TargetItemBinding<UIPageViewControllerObservableDataSource, int> CurrentItemIndexAndCurrentItemIndexChangedBinding(
            [NotNull] this IItemReference<UIPageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemTwoWayCustomBinding<UIPageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged += eventHandler,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged -= eventHandler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, eventArgs) => eventArgs?.Index ?? pageViewControllerDataSource.NotNull().CurrentItemIndex,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.NotNull().CurrentItemIndex = currentItemIndex,
                () => "CurrentItemIndexAndCurrentItemIndexChanged");
        }

        [NotNull]
        public static TargetItemBinding<UIPageViewControllerObservableDataSource, int> CurrentItemIndexBinding(
            [NotNull] this IItemReference<UIPageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<UIPageViewControllerObservableDataSource, int>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.NotNull().CurrentItemIndex = currentItemIndex,
                () => "CurrentItemIndex");
        }

        [NotNull]
        public static TargetItemBinding<UIPageViewControllerObservableDataSource, int> CurrentItemIndexChangedBinding(
            [NotNull] this IItemReference<UIPageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<UIPageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged += eventHandler,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged -= eventHandler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, eventArgs) => eventArgs?.Index ?? pageViewControllerDataSource.NotNull().CurrentItemIndex,
                () => "CurrentItemIndexChanged");
        }

        [NotNull]
        public static TargetItemBinding<UIPageViewControllerObservableDataSource, IEnumerable<object>> ItemsBinding(
            [NotNull] this IItemReference<UIPageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<UIPageViewControllerObservableDataSource, IEnumerable<object>>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, items) => pageViewControllerDataSource.NotNull().Items = items,
                () => "Items");
        }
    }
}
