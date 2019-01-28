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
using System.Linq;
using FlexiMvvm.Collections.Core;
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class CollectionViewObservableGroupedSource : CollectionViewObservableSource
    {
        [CanBeNull]
        private readonly Func<object, UICollectionElementKindSection, string> _sectionHeaderFooterCellReuseIdFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<IGrouping<object, object>> _groupedItems;

        public CollectionViewObservableGroupedSource(
            [NotNull] UICollectionView collectionView,
            [NotNull] Func<object, string> itemCellReuseIdFactory,
            [CanBeNull] Func<object, UICollectionElementKindSection, string> sectionHeaderFooterCellReuseIdFactory = null)
            : base(collectionView, itemCellReuseIdFactory)
        {
            _sectionHeaderFooterCellReuseIdFactory = sectionHeaderFooterCellReuseIdFactory;
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

        public override nint NumberOfSections([NotNull] UICollectionView collectionView)
        {
            return GroupedItems?.Count() ?? 0;
        }

        public override nint GetItemsCount([NotNull] UICollectionView collectionView, nint section)
        {
            return GroupedItems != null ? GetItemsGroup(section)?.Count() ?? 0 : 0;
        }

        [NotNull]
        public override UICollectionReusableView GetViewForSupplementaryElement(
            [NotNull] UICollectionView collectionView,
            [NotNull] NSString elementKind,
            [NotNull] NSIndexPath indexPath)
        {
            if (_sectionHeaderFooterCellReuseIdFactory == null)
            {
                throw new InvalidOperationException(
                    "\"sectionHeaderFooterCellReuseIdFactory\" constructor parameter should be specified " +
                    "in order to create a view for header or footer.");
            }

            var itemsGroup = GetItemsGroup(indexPath.Section);
            var group = itemsGroup?.Key;
            var sectionHeaderFooterCellReuseId = _sectionHeaderFooterCellReuseIdFactory(group, GetElementKindSection(elementKind));
            var sectionHeaderFooterCell = (CollectionViewObservableSectionHeaderFooterCell)collectionView.DequeueReusableSupplementaryView(
                elementKind,
                sectionHeaderFooterCellReuseId,
                indexPath).NotNull();

            sectionHeaderFooterCell.Bind(ItemsContext, group);

            return sectionHeaderFooterCell;
        }

        [CanBeNull]
        protected virtual IGrouping<object, object> GetItemsGroup(nint section)
        {
            if (GroupedItems == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get items group at \"{section}\" section due to \"{nameof(GroupedItems)}\" collection is null.");
            }

            return GroupedItems.ElementAt((int)section);
        }

        protected override object GetItem(NSIndexPath indexPath)
        {
            var itemsGroup = GetItemsGroup(indexPath.Section);

            if (itemsGroup == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get item at \"{indexPath.Row}\" position due to items group at \"{indexPath.Section}\" section is null.");
            }

            return itemsGroup.ElementAt(indexPath.Row);
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

            if (CollectionViewWeakReference.TryGetTarget(out var collectionView))
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        collectionView.PerformBatchUpdates(() => collectionView.InsertSections(args.ToNewIndexSet()), null);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        collectionView.MoveSection(args.OldStartingIndex, args.NewStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        collectionView.PerformBatchUpdates(() => collectionView.ReloadSections(args.ToNewIndexSet()), null);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        collectionView.PerformBatchUpdates(() => collectionView.DeleteSections(args.ToOldIndexSet()), null);
                        break;
                    default:
                        collectionView.ReloadData();
                        break;
                }
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
