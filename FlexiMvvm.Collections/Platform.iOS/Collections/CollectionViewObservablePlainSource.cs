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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class CollectionViewObservablePlainSource : CollectionViewObservableSource, IItemsSource<object>
    {
        protected const int DefaultSection = 0;
        protected const int DefaultSectionCount = 1;

        [CanBeNull]
        private readonly Func<UICollectionElementKindSection, string> _sectionHeaderFooterCellReuseIdFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object>? _items;

        public CollectionViewObservablePlainSource(
            [NotNull] UICollectionView collectionView,
            [NotNull] Func<object, string> itemCellReuseIdFactory,
            [CanBeNull] Func<UICollectionElementKindSection, string> sectionHeaderFooterCellReuseIdFactory = null)
            : base(collectionView, itemCellReuseIdFactory)
        {
            _sectionHeaderFooterCellReuseIdFactory = sectionHeaderFooterCellReuseIdFactory;
        }

        [CanBeNull]
        [ItemCanBeNull]
        public IEnumerable<object>? Items
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

        public override nint NumberOfSections([NotNull] UICollectionView collectionView)
        {
            return DefaultSectionCount;
        }

        public override nint GetItemsCount([NotNull] UICollectionView collectionView, nint section)
        {
            return section == DefaultSection && Items != null ? Items.Count() : 0;
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
                    "in order to create a view for section header or footer.");
            }

            var sectionHeaderFooterCellReuseId = _sectionHeaderFooterCellReuseIdFactory(GetElementKindSection(elementKind));
            var sectionHeaderFooterCell = (CollectionViewObservableSectionHeaderFooterCell)collectionView.DequeueReusableSupplementaryView(
                elementKind,
                sectionHeaderFooterCellReuseId,
                indexPath).NotNull();

            sectionHeaderFooterCell.Bind(ItemsContext, null);

            return sectionHeaderFooterCell;
        }

        protected override object GetItem(NSIndexPath indexPath)
        {
            if (indexPath.Section != DefaultSection)
            {
                throw new InvalidOperationException(
                    $"Unable to get item for \"{indexPath.Section}\" section. Only \"{DefaultSection}\" section is supported.");
            }

            if (Items == null)
            {
                throw new InvalidOperationException(
                    $"Unable to get item at \"{indexPath.Row}\" position due to \"{nameof(Items)}\" collection is null.");
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

            if (CollectionViewWeakReference.TryGetTarget(out var collectionView))
            {
                collectionView.ReloadData();
            }
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            ReloadSection(DefaultSection, e);
        }
    }
}
