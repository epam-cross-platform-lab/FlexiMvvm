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
using System.Collections.Specialized;
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public abstract class UICollectionViewObservableSourceBase : UICollectionViewSource
    {
        [NotNull]
        private readonly Func<object, string> _itemCellReuseIdFactory;
        [CanBeNull]
        [ItemNotNull]
        private DisposableCollection _itemsSubscriptions;

        private protected UICollectionViewObservableSourceBase(
            [NotNull] UICollectionView collectionView,
            [NotNull] Func<object, string> itemCellReuseIdFactory)
        {
            if (collectionView == null)
                throw new ArgumentNullException(nameof(collectionView));
            if (itemCellReuseIdFactory == null)
                throw new ArgumentNullException(nameof(itemCellReuseIdFactory));

            CollectionViewWeakReference = new WeakReference<UICollectionView>(collectionView);
            _itemCellReuseIdFactory = itemCellReuseIdFactory;
        }

        public event EventHandler<SelectionChangedEventArgs> ItemSelectedCalled;

        public event EventHandler<SelectionChangedEventArgs> ItemDeselectedCalled;

        [CanBeNull]
        public object ItemsContext { get; set; }

        [NotNull]
        protected WeakReference<UICollectionView> CollectionViewWeakReference { get; }

        [NotNull]
        [ItemNotNull]
        private protected DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        [NotNull]
        public override UICollectionViewCell GetCell([NotNull] UICollectionView collectionView, [NotNull] NSIndexPath indexPath)
        {
            var item = GetItem(indexPath);
            var itemCellReuseId = _itemCellReuseIdFactory(item);
            var itemCell = (UICollectionViewObservableItemCell)collectionView.DequeueReusableCell(itemCellReuseId, indexPath).NotNull();

            itemCell.Bind(ItemsContext, item);

            return itemCell;
        }

        public override void ItemSelected([NotNull] UICollectionView collectionView, [NotNull] NSIndexPath indexPath)
        {
            ItemSelectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        public override void ItemDeselected([NotNull] UICollectionView collectionView, [NotNull] NSIndexPath indexPath)
        {
            ItemDeselectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        [CanBeNull]
        protected abstract object GetItem([NotNull] NSIndexPath indexPath);

        private protected virtual void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();
        }

        protected abstract void ReloadSections([NotNull] NotifyCollectionChangedEventArgs args);

        protected virtual void ReloadSection(nint section, [NotNull] NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (CollectionViewWeakReference.TryGetTarget(out var collectionView))
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        collectionView.PerformBatchUpdates(() => collectionView.InsertItems(args.ToNewIndexPaths(section)), null);
                        break;
                    case NotifyCollectionChangedAction.Move:
                        collectionView.MoveItem(args.ToOldIndexPath(section), args.ToNewIndexPath(section));
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        collectionView.PerformBatchUpdates(() => collectionView.ReloadItems(args.ToNewIndexPaths(section)), null);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        collectionView.PerformBatchUpdates(() => collectionView.DeleteItems(args.ToOldIndexPaths(section)), null);
                        break;
                    default:
                        collectionView.ReloadSections(NSIndexSet.FromIndex(section));
                        break;
                }
            }
        }

        private protected UICollectionElementKindSection GetElementKindSection([NotNull] NSString elementKind)
        {
            if (elementKind == UICollectionElementKindSectionKey.Header)
            {
                return UICollectionElementKindSection.Header;
            }

            if (elementKind == UICollectionElementKindSectionKey.Footer)
            {
                return UICollectionElementKindSection.Footer;
            }

            throw new ArgumentException($"\"{elementKind}\" element kind section is unknown.");
        }
    }
}
