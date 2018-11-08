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
using System.Linq;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class BindingSetExtensions
    {
        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIPageViewControllerObservableDataSource pageViewControllerDataSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(pageViewControllerDataSource)
                .For(v => v.NotNull().ItemsBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UIPickerViewObservableModel pickerViewModel)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(pickerViewModel)
                .For(v => v.NotNull().ItemsBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<IGrouping<object, object>>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UICollectionViewObservableGroupedSource collectionViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(collectionViewSource)
                .For(v => v.NotNull().GroupedItemsBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UICollectionViewObservablePlainSource collectionViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(collectionViewSource)
                .For(v => v.NotNull().ItemsBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<IGrouping<object, object>>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UITableViewObservableGroupedSource tableViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(tableViewSource)
                .For(v => v.NotNull().GroupedItemsBinding());
        }

        [NotNull]
        public static ISourceItemBindingBuilder<TSourceItem, IEnumerable<object>> BindDefault<TSourceItem>(
            [NotNull] this BindingSet<TSourceItem> bindingSet,
            [CanBeNull] UITableViewObservablePlainSource tableViewSource)
            where TSourceItem : class
        {
            if (bindingSet == null)
                throw new ArgumentNullException(nameof(bindingSet));

            return bindingSet.Bind(tableViewSource)
                .For(v => v.NotNull().ItemsBinding());
        }
    }
}
