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
using System.Collections.Generic;
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class PageViewControllerObservableDataSourceBindings
    {
        [NotNull]
        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexAndCurrentItemIndexChangedBinding(
            [NotNull] this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemTwoWayCustomBinding<PageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged += eventHandler,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged -= eventHandler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, eventArgs) => eventArgs?.Index ?? pageViewControllerDataSource.NotNull().CurrentItemIndex,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.NotNull().CurrentItemIndex = currentItemIndex,
                () => "CurrentItemIndexAndCurrentItemIndexChanged");
        }

        [NotNull]
        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexBinding(
            [NotNull] this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<PageViewControllerObservableDataSource, int>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.NotNull().CurrentItemIndex = currentItemIndex,
                () => "CurrentItemIndex");
        }

        [NotNull]
        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexChangedBinding(
            [NotNull] this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<PageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged += eventHandler,
                (pageViewControllerDataSource, eventHandler) => pageViewControllerDataSource.NotNull().CurrentItemIndexChanged -= eventHandler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, eventArgs) => eventArgs?.Index ?? pageViewControllerDataSource.NotNull().CurrentItemIndex,
                () => "CurrentItemIndexChanged");
        }

        [NotNull]
        public static TargetItemBinding<PageViewControllerObservableDataSource, IEnumerable<object>> ItemsBinding(
            [NotNull] this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<PageViewControllerObservableDataSource, IEnumerable<object>>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, items) => pageViewControllerDataSource.NotNull().Items = items,
                () => "Items");
        }
    }
}
