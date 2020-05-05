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
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
#if __ANDROID_29__
using AndroidX.RecyclerView.Widget;
#else
using Android.Support.V7.Widget;
#endif
using JetBrains.Annotations;

namespace FlexiMvvm.Collections.Core
{
    internal class GroupedItemsMapping : ItemsMapping
    {
        internal override void Reload(RecyclerViewObservableAdapter adapter)
        {
            var groupedAdapter = (RecyclerViewObservableGroupedAdapter)adapter;

            ItemsMap.Clear();
            ItemsMap.Add(ItemMap.CreateForHeader());

            var sectionsCount = groupedAdapter.GetSectionsCount();

            for (var section = 0; section < sectionsCount; section++)
            {
                ItemsMap.Add(ItemMap.CreateForSectionHeader(groupedAdapter.GetItemsGroup(section)?.Key));

                var sectionItemsCount = groupedAdapter.GetSectionItemsCount(section);

                for (var row = 0; row < sectionItemsCount; row++)
                {
                    ItemsMap.Add(ItemMap.CreateForItem(groupedAdapter.GetItem(section, row)));
                }

                ItemsMap.Add(ItemMap.CreateForSectionFooter(groupedAdapter.GetItemsGroup(section)?.Key));
            }

            ItemsMap.Add(ItemMap.CreateForFooter());

            groupedAdapter.NotifyDataSetChanged();
        }

        internal void AddGroups([NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            var newStartingIndex = GetSectionPlainOffset(args.NewStartingIndex);
            var count = 0;

            foreach (IGrouping<object, object> itemsGroup in args.NewItems.NotNull())
            {
                ItemsMap.Insert(newStartingIndex + count++, ItemMap.CreateForSectionHeader(itemsGroup?.Key));

                if (itemsGroup != null)
                {
                    foreach (var item in itemsGroup)
                    {
                        ItemsMap.Insert(newStartingIndex + count++, ItemMap.CreateForItem(item));
                    }
                }

                ItemsMap.Insert(newStartingIndex + count++, ItemMap.CreateForSectionFooter(itemsGroup?.Key));
            }

            adapter.NotifyItemRangeInserted(newStartingIndex, count);
        }

        internal void MoveGroup([NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            if (args.OldStartingIndex != args.NewStartingIndex)
            {
                var oldStartingIndex = GetSectionPlainOffset(args.OldStartingIndex);
                var newStartingIndex = GetSectionPlainOffset(args.NewStartingIndex);
                var count = GetSectionsLength(args.OldItems.NotNull());

                for (var i = 0; i < count; i++)
                {
                    MoveItem(oldStartingIndex + i, newStartingIndex + i, adapter);
                }
            }
        }

        internal void ReplaceGroups([NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerViewObservableGroupedAdapter adapter)
        {
            RemoveGroups(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, args.OldItems, args.OldStartingIndex), adapter);
            AddGroups(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, args.NewItems, args.NewStartingIndex), adapter);
        }

        internal void RemoveGroups([NotNull] NotifyCollectionChangedEventArgs args, [NotNull] RecyclerView.Adapter adapter)
        {
            var oldStartingIndex = GetSectionPlainOffset(args.OldStartingIndex);
            var count = GetSectionsLength(args.OldItems.NotNull());

            ItemsMap.RemoveRange(oldStartingIndex, count);

            adapter.NotifyItemRangeRemoved(oldStartingIndex, count);
        }

        private int GetSectionsLength([NotNull] IList groupedItems)
        {
            var length = 0;

            foreach (IGrouping<object, object> itemsGroup in groupedItems)
            {
                length += SectionHeaderCount + itemsGroup?.Count() ?? 0 + SectionFooterCount;
            }

            return length;
        }
    }
}
