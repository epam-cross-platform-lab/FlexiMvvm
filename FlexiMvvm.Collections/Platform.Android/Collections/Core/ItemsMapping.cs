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

using System.Collections.Generic;
using System.Collections.Specialized;
using Android.Support.V7.Widget;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections.Core
{
    internal abstract class ItemsMapping
    {
        protected const int HeaderCount = 1;
        protected const int SectionHeaderCount = 1;
        protected const int SectionFooterCount = 1;

        [CanBeNull]
        private List<ItemMap> _itemsMap;

        [NotNull]
        [ItemNotNull]
        private protected List<ItemMap> ItemsMap => _itemsMap ?? (_itemsMap = new List<ItemMap>());

        internal int Count => ItemsMap.Count;

        [NotNull]
        internal ItemMap ElementAt(int index)
        {
            return ItemsMap[index];
        }

        internal abstract void Reload([NotNull] RecyclerViewObservableAdapter adapter);

        internal void AddItems(int section, [NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            var newStartingIndex = GetItemPlainOffset(section, args.NewStartingIndex);
            var count = 0;

            foreach (var item in args.NewItems.NotNull())
            {
                ItemsMap.Insert(newStartingIndex + count++, ItemMap.CreateForItem(item));
            }

            adapter.NotifyItemRangeInserted(newStartingIndex, count);
        }

        internal void MoveItem(int section, [NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            if (args.OldStartingIndex != args.NewStartingIndex)
            {
                var oldStartingIndex = GetItemPlainOffset(section, args.OldStartingIndex);
                var newStartingIndex = GetItemPlainOffset(section, args.NewStartingIndex);

                MoveItem(oldStartingIndex, newStartingIndex, adapter);
            }
        }

        private protected void MoveItem(int oldStartingIndex, int newStartingIndex, [NotNull] RecyclerView.Adapter adapter)
        {
            var item = ItemsMap[oldStartingIndex];
            ItemsMap.RemoveAt(oldStartingIndex);
            ItemsMap.Insert(newStartingIndex, item);

            adapter.NotifyItemMoved(oldStartingIndex, newStartingIndex);
        }

        internal void ReplaceItems(int section, [NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            var oldStartingIndex = GetItemPlainOffset(section, args.OldStartingIndex);
            var count = 0;

            foreach (var item in args.NewItems.NotNull())
            {
                ItemsMap[oldStartingIndex + count++] = ItemMap.CreateForItem(item);
            }

            adapter.NotifyItemRangeChanged(oldStartingIndex, count);
        }

        internal void RemoveItems(int section, [NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            var oldStartingIndex = GetItemPlainOffset(section, args.OldStartingIndex);
            var count = args.OldItems.NotNull().Count;

            ItemsMap.RemoveRange(oldStartingIndex, count);

            adapter.NotifyItemRangeRemoved(oldStartingIndex, count);
        }

        private protected int GetSectionPlainOffset(int section)
        {
            var offset = HeaderCount;
            var i = 0;

            while (i < section)
            {
                if (ItemsMap[offset++].ItemKind == ItemKind.SectionFooter)
                {
                    i++;
                }
            }

            return offset;
        }

        private int GetItemPlainOffset(int section, int row)
        {
            return GetSectionPlainOffset(section) + SectionHeaderCount + row;
        }
    }
}
