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
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class ObservableCollection<TItem> : System.Collections.ObjectModel.ObservableCollection<TItem>
    {
        private const string CountString = "Count";
        private const string IndexerName = "Item[]";

        public ObservableCollection()
        {
        }

        public ObservableCollection([NotNull] IEnumerable<TItem> items)
            : base(items)
        {
        }

        public void AddRange([NotNull] IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var startIndex = Items.NotNull().Count;

            InsertRange(startIndex, items);
        }

        public void InsertRange(int index, [NotNull] IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            CheckReentrancy();

            var newItems = items.ToList().NotNull();

            if (newItems.Any())
            {
                var startIndex = index;
                var currentIndex = startIndex;
                var existingItems = Items.NotNull();

                foreach (var newItem in newItems)
                {
                    existingItems.Insert(currentIndex, newItem);

                    currentIndex++;
                }

                OnPropertyChanged(new PropertyChangedEventArgs(CountString));
                OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, newItems, startIndex));
            }
        }

        public void RemoveRange(int index, int count)
        {
            CheckReentrancy();

            var startIndex = index;
            var currentIndex = startIndex;
            var endIndex = startIndex + count;
            var existingItems = Items.NotNull();
            var removedItems = new List<TItem>();

            while (currentIndex < endIndex)
            {
                removedItems.Add(existingItems[startIndex]);
                existingItems.RemoveAt(startIndex);

                currentIndex++;
            }

            OnPropertyChanged(new PropertyChangedEventArgs(CountString));
            OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, removedItems, startIndex));
        }

        public void ReplaceRange(int index, [NotNull] IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            CheckReentrancy();

            var newItems = items.ToList().NotNull();

            if (newItems.Any())
            {
                var startIndex = index;
                var currentIndex = startIndex;
                var existingItems = Items.NotNull();
                var replacedItems = new List<TItem>();

                foreach (var newItem in newItems)
                {
                    replacedItems.Add(existingItems[currentIndex]);
                    existingItems[currentIndex] = newItem;

                    currentIndex++;
                }

                OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, replacedItems, startIndex));
            }
        }
    }

    public class ObservableCollection<TGroup, TItem> : ObservableCollection<TItem>, IGrouping<TGroup, TItem>
    {
        public ObservableCollection([NotNull] TGroup key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
        }

        public ObservableCollection([NotNull] TGroup key, [NotNull] IEnumerable<TItem> items)
            : base(items)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
        }

        [NotNull]
        public TGroup Key { get; }
    }
}
