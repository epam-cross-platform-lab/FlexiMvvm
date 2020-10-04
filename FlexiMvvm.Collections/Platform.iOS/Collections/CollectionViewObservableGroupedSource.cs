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
using Microsoft.Extensions.Logging;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class CollectionViewObservableGroupedSource : CollectionViewObservableSource
    {
        private readonly Func<object?, UICollectionElementKindSection, string>? _sectionHeaderFooterCellReuseIdentifierFactory;
        private IEnumerable<IGrouping<object?, object?>?>? _groupedItems;

        public CollectionViewObservableGroupedSource(UICollectionView collectionView)
            : base(collectionView)
        {
        }

        [Obsolete("CollectionViewObservableGroupedSource(UICollectionView collectionView, Func<object?, string> itemCellReuseIdentifierFactory, Func<object?, UICollectionElementKindSection, string> ? sectionHeaderFooterCellReuseIdentifierFactory = null) will be removed soon. Use CollectionViewObservableGroupedSource(UICollectionView collectionView) constructor instead.")]
        public CollectionViewObservableGroupedSource(
            UICollectionView collectionView,
            Func<object?, string> itemCellReuseIdentifierFactory,
            Func<object?, UICollectionElementKindSection, string>? sectionHeaderFooterCellReuseIdentifierFactory = null)
            : base(collectionView, itemCellReuseIdentifierFactory)
        {
            _sectionHeaderFooterCellReuseIdentifierFactory = sectionHeaderFooterCellReuseIdentifierFactory;
        }

        public IEnumerable<IGrouping<object?, object?>?>? GroupedItems
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

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return GroupedItems?.Count() ?? 0;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return GroupedItems != null ? GetItemsGroup(section)?.Count() ?? 0 : 0;
        }

        public sealed override UICollectionReusableView GetViewForSupplementaryElement(
            UICollectionView collectionView,
            NSString elementKind,
            NSIndexPath indexPath)
        {
            var elementKindSection = GetElementKindSection(elementKind);

            return GetSectionHeaderFooterCell(collectionView, elementKindSection, indexPath);
        }

        public virtual string GetSectionHeaderFooterCellReuseIdentifier(object? group, UICollectionElementKindSection elementKindSection)
        {
            var reuseIdentifier = (_sectionHeaderFooterCellReuseIdentifierFactory?.Invoke(group, elementKindSection)).SelfOrEmpty();

            if (string.IsNullOrEmpty(reuseIdentifier))
            {
                Logger.LogDebug(
                    $"Section header footer cell reuse identifier factory is 'null' or returned empty/null reuse identifier for " +
                    $"'{elementKindSection}' element kind section. Use '{nameof(CollectionViewObservableSectionHeaderFooterCell)}' as fallback cell.");

                reuseIdentifier = CollectionViewObservableSectionHeaderFooterCell.ReuseIdentifier;
            }

            return reuseIdentifier;
        }

        public virtual UICollectionReusableView GetSectionHeaderFooterCell(
            UICollectionView collectionView,
            UICollectionElementKindSection elementKindSection,
            NSIndexPath indexPath)
        {
            var itemsGroup = GetItemsGroup(indexPath.Section);
            var group = itemsGroup?.Key;
            var cellReuseIdentifier = GetSectionHeaderFooterCellReuseIdentifier(group, elementKindSection);
            var cell = (CollectionViewObservableSectionHeaderFooterCell)collectionView.DequeueReusableSupplementaryView(
                elementKindSection,
                cellReuseIdentifier,
                indexPath);

            cell.Initialize(CellsSharedData);
            PrepareSectionHeaderFooterCell(collectionView, cell, elementKindSection, indexPath);
            cell.Bind(ItemsContext, null);

            return cell;
        }

        public virtual void PrepareSectionHeaderFooterCell(
            UICollectionView collectionView,
            CollectionViewObservableSectionHeaderFooterCell cell,
            UICollectionElementKindSection elementKindSection,
            NSIndexPath indexPath)
        {
        }

        protected virtual IGrouping<object?, object?>? GetItemsGroup(nint section)
        {
            if (GroupedItems == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get items group at '{section}' section due to '{nameof(GroupedItems)}' collection is 'null'.");
            }

            return GroupedItems.ElementAt((int)section);
        }

        protected override object? GetItem(NSIndexPath indexPath)
        {
            if (indexPath == null)
                throw new ArgumentNullException(nameof(indexPath));

            var itemsGroup = GetItemsGroup(indexPath.Section);

            if (itemsGroup == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get item at '{indexPath.Row}' position due to items group at '{indexPath.Section}' section is 'null'.");
            }

            return itemsGroup.ElementAt(indexPath.Row);
        }

        private protected override void RefreshItemsSubscriptions()
        {
            base.RefreshItemsSubscriptions();

            if (GroupedItems is INotifyCollectionChanged observableGroupedItems)
            {
                observableGroupedItems.CollectionChangedWeakSubscribe(GroupedItems_CollectionChanged).DisposeWith(ItemsSubscriptions);

                foreach (var itemsGroup in GroupedItems)
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
                    CollectionView.PerformBatchUpdates(() => CollectionView.InsertSections(args.ToNewIndexSet()), null);
                    break;
                case NotifyCollectionChangedAction.Move:
                    CollectionView.MoveSection(args.OldStartingIndex, args.NewStartingIndex);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    CollectionView.PerformBatchUpdates(() => CollectionView.ReloadSections(args.ToNewIndexSet()), null);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    CollectionView.PerformBatchUpdates(() => CollectionView.DeleteSections(args.ToOldIndexSet()), null);
                    break;
                default:
                    CollectionView.ReloadData();
                    break;
            }
        }

        private void GroupedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RefreshItemsSubscriptions();
            ReloadSections(e);
        }

        private void ItemsGroup_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var changedItemsGroup = (IGrouping<object, object>)sender;
            var section = 0;

            foreach (var itemsGroup in GroupedItems)
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
