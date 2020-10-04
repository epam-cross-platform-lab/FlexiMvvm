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
using Foundation;
using Microsoft.Extensions.Logging;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class CollectionViewObservablePlainSource : CollectionViewObservableSource, IItemsSource<object?>
    {
        protected const int DefaultSection = 0;
        protected const int DefaultSectionCount = 1;

        private readonly Func<UICollectionElementKindSection, string>? _sectionHeaderFooterCellReuseIdentifierFactory;
        private IEnumerable<object?>? _items;

        public CollectionViewObservablePlainSource(UICollectionView collectionView)
            : base(collectionView)
        {
        }

        [Obsolete("CollectionViewObservablePlainSource(UICollectionView collectionView, Func<object?, string> itemCellReuseIdentifierFactory, Func<UICollectionElementKindSection, string>? sectionHeaderFooterCellReuseIdentifierFactory = null) will be removed soon. Use CollectionViewObservablePlainSource(UICollectionView collectionView) constructor instead.")]
        public CollectionViewObservablePlainSource(
            UICollectionView collectionView,
            Func<object?, string> itemCellReuseIdentifierFactory,
            Func<UICollectionElementKindSection, string>? sectionHeaderFooterCellReuseIdentifierFactory = null)
            : base(collectionView, itemCellReuseIdentifierFactory)
        {
            _sectionHeaderFooterCellReuseIdentifierFactory = sectionHeaderFooterCellReuseIdentifierFactory;
        }

        public IEnumerable<object?>? Items
        {
            get => _items;
            set
            {
                if (!ReferenceEquals(_items, value))
                {
                    _items = value;

                    RefreshItemsSubscriptions();
                    ReloadSections(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        public override nint NumberOfSections(UICollectionView collectionView)
        {
            return DefaultSectionCount;
        }

        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return section == DefaultSection && Items != null ? Items.Count() : 0;
        }

        public sealed override UICollectionReusableView GetViewForSupplementaryElement(
            UICollectionView collectionView,
            NSString elementKind,
            NSIndexPath indexPath)
        {
            var elementKindSection = GetElementKindSection(elementKind);

            return GetSectionHeaderFooterCell(collectionView, elementKindSection, indexPath);
        }

        public virtual string GetSectionHeaderFooterCellReuseIdentifier(UICollectionElementKindSection elementKindSection)
        {
            var reuseIdentifier = (_sectionHeaderFooterCellReuseIdentifierFactory?.Invoke(elementKindSection)).SelfOrEmpty();

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
            var cellReuseIdentifier = GetSectionHeaderFooterCellReuseIdentifier(elementKindSection);
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

        protected override object? GetItem(NSIndexPath indexPath)
        {
            if (indexPath == null)
                throw new ArgumentNullException(nameof(indexPath));

            if (indexPath.Section != DefaultSection)
            {
                throw new InvalidOperationException(
                    $"Unable to get item for '{indexPath.Section}' section. Only '{DefaultSection}' section is supported.");
            }

            if (Items == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get item at '{indexPath.Row}' position due to '{nameof(Items)}' collection is null.");
            }

            return Items.ElementAt(indexPath.Row);
        }

        private protected override void RefreshItemsSubscriptions()
        {
            base.RefreshItemsSubscriptions();

            if (Items is INotifyCollectionChanged observableItems)
            {
                observableItems.CollectionChangedWeakSubscribe(Items_CollectionChanged).DisposeWith(ItemsSubscriptions);
            }
        }

        protected override void ReloadSections(NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            CollectionView.ReloadData();
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ReloadSection(DefaultSection, e);
        }
    }
}
