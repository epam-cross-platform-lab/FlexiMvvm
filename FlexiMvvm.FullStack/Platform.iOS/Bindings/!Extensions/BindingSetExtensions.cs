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
using System.Linq;
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.ItemsBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            PageViewControllerObservableDataSource pageViewControllerDataSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(pageViewControllerDataSource)
                .For(v => v.ItemsBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.GroupedItemsBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<IGrouping<object, object>>> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            CollectionViewObservableGroupedSource collectionViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(collectionViewSource)
                .For(v => v.GroupedItemsBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.ItemsBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            CollectionViewObservablePlainSource collectionViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(collectionViewSource)
                .For(v => v.ItemsBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.GroupedItemsBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<IGrouping<object, object>>> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            TableViewObservableGroupedSource tableViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(tableViewSource)
                .For(v => v.GroupedItemsBinding());
        }

        [Obsolete("BindDefault will be removed soon. Use Bind(view).For(v => v.ItemsBinding()) construction instead.")]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            this BindingSet<TSourceItem> bindingSet,
            TableViewObservablePlainSource tableViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(tableViewSource)
                .For(v => v.ItemsBinding());
        }
    }
}
