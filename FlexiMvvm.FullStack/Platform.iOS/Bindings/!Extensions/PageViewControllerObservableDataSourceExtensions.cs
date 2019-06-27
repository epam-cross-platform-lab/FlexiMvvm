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

namespace FlexiMvvm.Bindings
{
    public static class PageViewControllerObservableDataSourceExtensions
    {
        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexAndCurrentItemIndexChangedBinding(
            this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemTwoWayCustomBinding<PageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, handler) => pageViewControllerDataSource.CurrentItemIndexChanged += handler,
                (pageViewControllerDataSource, handler) => pageViewControllerDataSource.CurrentItemIndexChanged -= handler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, args) => args?.Index ?? pageViewControllerDataSource.CurrentItemIndex,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.CurrentItemIndex = currentItemIndex,
                () => $"{nameof(PageViewControllerObservableDataSource.CurrentItemIndex)}And{nameof(PageViewControllerObservableDataSource.CurrentItemIndexChanged)}");
        }

        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexBinding(
            this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<PageViewControllerObservableDataSource, int>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, currentItemIndex) => pageViewControllerDataSource.CurrentItemIndex = currentItemIndex,
                () => $"{nameof(PageViewControllerObservableDataSource.CurrentItemIndex)}");
        }

        public static TargetItemBinding<PageViewControllerObservableDataSource, int> CurrentItemIndexChangedBinding(
            this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<PageViewControllerObservableDataSource, int, IndexChangedEventArgs>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, handler) => pageViewControllerDataSource.CurrentItemIndexChanged += handler,
                (pageViewControllerDataSource, handler) => pageViewControllerDataSource.CurrentItemIndexChanged -= handler,
                (pageViewControllerDataSource, canExecuteCommand) => { },
                (pageViewControllerDataSource, args) => args?.Index ?? pageViewControllerDataSource.CurrentItemIndex,
                () => $"{nameof(PageViewControllerObservableDataSource.CurrentItemIndexChanged)}");
        }

        public static TargetItemBinding<PageViewControllerObservableDataSource, IEnumerable<object>> ItemsBinding(
            this IItemReference<PageViewControllerObservableDataSource> pageViewControllerDataSourceReference)
        {
            if (pageViewControllerDataSourceReference == null)
                throw new ArgumentNullException(nameof(pageViewControllerDataSourceReference));

            return new TargetItemOneWayCustomBinding<PageViewControllerObservableDataSource, IEnumerable<object>>(
                pageViewControllerDataSourceReference,
                (pageViewControllerDataSource, items) => pageViewControllerDataSource.Items = items,
                () => $"{nameof(PageViewControllerObservableDataSource.Items)}");
        }
    }
}
