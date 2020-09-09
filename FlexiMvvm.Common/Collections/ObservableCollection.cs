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

namespace FlexiMvvm.Collections
{
    public class ObservableCollection<TItem> : System.Collections.ObjectModel.ObservableCollection<TItem>
    {
        private const string CountString = "Count";
        private const string IndexerName = "Item[]";

        public ObservableCollection()
        {
        }

        public ObservableCollection(IEnumerable<TItem> items)
            : base(items)
        {
        }

        public void AddRange(IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            var startIndex = Items.Count;

            InsertRange(startIndex, items);
        }

        public void InsertRange(int index, IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            CheckReentrancy();

            var newItems = items.ToList();

            if (newItems.Any())
            {
                var startIndex = index;
                var currentIndex = startIndex;
                var existingItems = Items;

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
            var existingItems = Items;
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

        public void ReplaceRange(int index, IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            CheckReentrancy();

            var newItems = items.ToList();

            if (newItems.Any())
            {
                var startIndex = index;
                var currentIndex = startIndex;
                var existingItems = Items;
                var replacedItems = new List<TItem>();

                foreach (var newItem in newItems)
                {
                    if (currentIndex < existingItems.Count)
                    {
                        replacedItems.Add(existingItems[currentIndex]);
                        existingItems[currentIndex] = newItem;
                    }
                    else
                    {
                        existingItems.Insert(currentIndex, newItem);
                    }

                    currentIndex++;
                }

                if (newItems.Count != replacedItems.Count)
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(CountString));
                }

                OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, newItems, replacedItems, startIndex));
            }
        }

        public void ReplaceWith(IEnumerable<TItem> items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            CheckReentrancy();

            var newItems = items.ToList();
            var existingItems = Items;

            if (newItems.Any() || existingItems.Any())
            {
                existingItems.Clear();

                foreach (var newItem in newItems)
                {
                    existingItems.Add(newItem);
                }

                OnPropertyChanged(new PropertyChangedEventArgs(CountString));
                OnPropertyChanged(new PropertyChangedEventArgs(IndexerName));
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
    }

    public class ObservableCollection : ObservableCollection<object>
    {
        public ObservableCollection()
        {
        }

        public ObservableCollection(IEnumerable<object> items)
            : base(items)
        {
        }

        public ObservableCollection(params object[] items)
            : base(items)
        {
        }
    }

    [Obsolete("ObservableCollection<TGroup, TItem> will be removed soon. Use GroupingObservableCollection<TKey, TItem> instead.")]
    public class ObservableCollection<TGroup, TItem> : ObservableCollection<TItem>, IGrouping<TGroup, TItem>
    {
        public ObservableCollection(TGroup key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
        }

        public ObservableCollection(TGroup key, IEnumerable<TItem> items)
            : base(items)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            Key = key;
        }

        public TGroup Key { get; }
    }
}
