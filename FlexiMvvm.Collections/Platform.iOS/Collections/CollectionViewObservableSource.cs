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
using FlexiMvvm.Collections.Core;
using FlexiMvvm.Configuration;
using Foundation;
using Microsoft.Extensions.Logging;
using UIKit;

namespace FlexiMvvm.Collections
{
    public abstract class CollectionViewObservableSource : UICollectionViewSource
    {
        [Weak]
        private readonly UICollectionView _collectionView;
        private readonly Func<object?, string>? _itemCellReuseIdentifierFactory;
        private ILogger? _logger;
        private DisposableCollection? _itemsSubscriptions;

        private protected CollectionViewObservableSource(UICollectionView collectionView)
        {
            if (collectionView == null)
                throw new ArgumentNullException(nameof(collectionView));

            _collectionView = collectionView;

            _collectionView.RegisterClassForSupplementaryView(
                typeof(CollectionViewObservableSectionHeaderFooterCell),
                UICollectionElementKindSection.Header,
                CollectionViewObservableSectionHeaderFooterCell.ReuseIdentifier);
            _collectionView.RegisterClassForSupplementaryView(
                typeof(CollectionViewObservableSectionHeaderFooterCell),
                UICollectionElementKindSection.Footer,
                CollectionViewObservableSectionHeaderFooterCell.ReuseIdentifier);
            _collectionView.RegisterClassForCell(typeof(CollectionViewObservableItemCell), CollectionViewObservableItemCell.ReuseIdentifier);
        }

        [Obsolete]
        private protected CollectionViewObservableSource(UICollectionView collectionView, Func<object?, string> itemCellReuseIdentifierFactory)
            : this(collectionView)
        {
            if (itemCellReuseIdentifierFactory == null)
                throw new ArgumentNullException(nameof(itemCellReuseIdentifierFactory));

            _itemCellReuseIdentifierFactory = itemCellReuseIdentifierFactory;
        }

        public event EventHandler<SelectionChangedEventArgs>? ItemSelectedCalled;

        public event EventHandler<SelectionChangedEventArgs>? ItemDeselectedCalled;

        private protected ILogger Logger => _logger ??= FlexiMvvmConfig.Instance.GetLoggerFactory().CreateLogger(GetType());

        protected CellsSharedData CellsSharedData { get; } = new CellsSharedData();

        public object? ItemsContext { get; set; }

        protected UICollectionView CollectionView => _collectionView;

        private protected DisposableCollection ItemsSubscriptions => _itemsSubscriptions ??= new DisposableCollection();

        public virtual string GetCellReuseIdentifier(object? item)
        {
            var reuseIdentifier = (_itemCellReuseIdentifierFactory?.Invoke(item)).SelfOrEmpty();

            if (string.IsNullOrEmpty(reuseIdentifier))
            {
                Logger.LogDebug(
                    $"Item cell reuse identifier factory is 'null' or returned empty/null reuse identifier. " +
                    $"Use '{nameof(CollectionViewObservableItemCell)}' as fallback cell.");

                reuseIdentifier = CollectionViewObservableItemCell.ReuseIdentifier;
            }

            return reuseIdentifier;
        }

        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var item = GetItem(indexPath);
            var cellReuseIdentifier = GetCellReuseIdentifier(item);
            var cell = (CollectionViewObservableItemCell)collectionView.DequeueReusableCell(cellReuseIdentifier, indexPath);

            cell.Initialize(CellsSharedData);
            PrepareCell(collectionView, cell, indexPath);
            cell.Bind(ItemsContext, item);

            return cell;
        }

        public virtual void PrepareCell(UICollectionView collectionView, CollectionViewObservableItemCell cell, NSIndexPath indexPath)
        {
        }

        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            ItemSelectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        public override void ItemDeselected(UICollectionView collectionView, NSIndexPath indexPath)
        {
            ItemDeselectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        protected abstract object? GetItem(NSIndexPath indexPath);

        private protected virtual void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();
        }

        protected abstract void ReloadSections(NotifyCollectionChangedEventArgs args);

        protected virtual void ReloadSection(nint section, NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    CollectionView.PerformBatchUpdates(() => CollectionView.InsertItems(args.ToNewIndexPaths(section)), null);
                    break;
                case NotifyCollectionChangedAction.Move:
                    CollectionView.MoveItem(args.ToOldIndexPath(section), args.ToNewIndexPath(section));
                    break;
                case NotifyCollectionChangedAction.Replace:
                    CollectionView.PerformBatchUpdates(() => CollectionView.ReloadItems(args.ToNewIndexPaths(section)), null);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    CollectionView.PerformBatchUpdates(() => CollectionView.DeleteItems(args.ToOldIndexPaths(section)), null);
                    break;
                default:
                    CollectionView.ReloadSections(NSIndexSet.FromIndex(section));
                    break;
            }
        }

        private protected UICollectionElementKindSection GetElementKindSection(NSString elementKind)
        {
            if (elementKind == UICollectionElementKindSectionKey.Header)
            {
                return UICollectionElementKindSection.Header;
            }

            if (elementKind == UICollectionElementKindSectionKey.Footer)
            {
                return UICollectionElementKindSection.Footer;
            }

            throw new ArgumentException($"'{elementKind}' element kind section is unknown.");
        }
    }
}
