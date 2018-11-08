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
using System.Collections.Specialized;
using System.Linq;
using Android.Support.V7.Widget;
using FlexiMvvm.Collections.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public abstract class RecyclerViewObservableGroupedAdapterBase : RecyclerViewObservableAdapterBase
    {
        [NotNull]
        private readonly GroupedItemsMapping _groupedItemsMapping = new GroupedItemsMapping();
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<IGrouping<object, object>> _groupedItems;

        protected RecyclerViewObservableGroupedAdapterBase([NotNull] RecyclerView recyclerView)
            : base(recyclerView)
        {
        }

        [CanBeNull]
        [ItemCanBeNull]
        public IEnumerable<IGrouping<object, object>> GroupedItems
        {
            get => _groupedItems;
            set
            {
                if (!ReferenceEquals(_groupedItems, value))
                {
                    _groupedItems = value;

                    RefreshItemsSubscriptions();
                    ReloadSections(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        public override int GetSectionsCount()
        {
            return GroupedItems?.Count() ?? 0;
        }

        public override int GetSectionItemsCount(int section)
        {
            return GetItemsGroup(section)?.Count() ?? 0;
        }

        public override int GetItemViewType(int position)
        {
            var itemMap = GetItemMap(position);

            switch (itemMap.Type)
            {
                case ItemType.SectionHeader:
                    return ViewType.GetTarget(ItemType.SectionHeader, OnGetSectionHeaderViewType(itemMap.Group));
                case ItemType.SectionFooter:
                    return ViewType.GetTarget(ItemType.SectionFooter, OnGetSectionFooterViewType(itemMap.Group));
                default:
                    return base.GetItemViewType(position);
            }
        }

        protected virtual int OnGetSectionHeaderViewType([CanBeNull] object group)
        {
            return DefaultViewType;
        }

        protected virtual int OnGetSectionFooterViewType([CanBeNull] object group)
        {
            return DefaultViewType;
        }

        private protected override ItemsMappingBase GetItemsMapping()
        {
            return _groupedItemsMapping;
        }

        [CanBeNull]
        protected internal virtual IGrouping<object, object> GetItemsGroup(int section)
        {
            if (GroupedItems == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get items group at \"{section}\" section due to \"{nameof(GroupedItems)}\" collection is null.");
            }

            return GroupedItems.ElementAt(section);
        }

        protected internal override object GetItem(int section, int row)
        {
            var itemsGroup = GetItemsGroup(section);

            if (itemsGroup == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get item at \"{row}\" position due to items group at \"{section}\" section is null.");
            }

            return itemsGroup.ElementAt(row);
        }

        private protected override void RefreshItemsSubscriptions()
        {
            base.RefreshItemsSubscriptions();

            if (GroupedItems is INotifyCollectionChanged observableGroupedItems)
            {
                observableGroupedItems.CollectionChangedWeakSubscribe(GroupedItems_CollectionChanged).DisposeWith(ItemsSubscriptions);

                foreach (var itemsGroup in GroupedItems.NotNull())
                {
                    if (itemsGroup is INotifyCollectionChanged observableItemsGroup)
                    {
                        observableItemsGroup.CollectionChangedWeakSubscribe(ItemsGroup_CollectionChanged).DisposeWith(ItemsSubscriptions);
                    }
                }
            }
        }

        protected override void ReloadSections(NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    _groupedItemsMapping.AddGroups(args, this);
                    break;
                case NotifyCollectionChangedAction.Move:
                    _groupedItemsMapping.MoveGroup(args, this);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    _groupedItemsMapping.ReplaceGroups(args, this);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    _groupedItemsMapping.RemoveGroups(args, this);
                    break;
                default:
                    _groupedItemsMapping.Reload(this);
                    break;
            }
        }

        private void GroupedItems_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            RefreshItemsSubscriptions();
            ReloadSections(e);
        }

        private void ItemsGroup_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            var changedItemsGroup = (IGrouping<object, object>)sender;
            var section = 0;

            foreach (var itemsGroup in GroupedItems.NotNull())
            {
                if (ReferenceEquals(itemsGroup, changedItemsGroup))
                {
                    ReloadSection(section, e);
                    break;
                }

                section++;
            }
        }
    }
}
