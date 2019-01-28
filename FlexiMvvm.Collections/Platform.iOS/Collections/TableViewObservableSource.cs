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
using System.Collections.Specialized;
using FlexiMvvm.Collections.Core;
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public abstract class TableViewObservableSource : UITableViewSource
    {
        protected const float ZeroHeight = 0.01f;

        [NotNull]
        private readonly Func<object, string> _itemCellReuseIdFactory;
        [CanBeNull]
        [ItemNotNull]
        private DisposableCollection _itemsSubscriptions;

        private protected TableViewObservableSource(
            [NotNull] UITableView tableView,
            [NotNull] Func<object, string> itemCellReuseIdFactory)
        {
            if (tableView == null)
                throw new ArgumentNullException(nameof(tableView));
            if (itemCellReuseIdFactory == null)
                throw new ArgumentNullException(nameof(itemCellReuseIdFactory));

            TableViewWeakReference = new WeakReference<UITableView>(tableView);
            _itemCellReuseIdFactory = itemCellReuseIdFactory;
        }

        public event EventHandler<SelectionChangedEventArgs> RowSelectedCalled;

        public event EventHandler<SelectionChangedEventArgs> RowDeselectedCalled;

        [CanBeNull]
        public object ItemsContext { get; set; }

        [NotNull]
        protected WeakReference<UITableView> TableViewWeakReference { get; }

        [NotNull]
        [ItemNotNull]
        private protected DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        [NotNull]
        public override UITableViewCell GetCell([NotNull] UITableView tableView, [NotNull] NSIndexPath indexPath)
        {
            var item = GetItem(indexPath);
            var itemCellReuseId = _itemCellReuseIdFactory(item);
            var itemCell = (TableViewObservableItemCell)tableView.DequeueReusableCell(itemCellReuseId, indexPath).NotNull();

            itemCell.Bind(ItemsContext, item);

            return itemCell;
        }

        public override void RowSelected([NotNull] UITableView tableView, [NotNull] NSIndexPath indexPath)
        {
            RowSelectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        public override void RowDeselected([NotNull] UITableView tableView, [NotNull] NSIndexPath indexPath)
        {
            RowDeselectedCalled?.Invoke(this, new SelectionChangedEventArgs(GetItem(indexPath)));
        }

        [CanBeNull]
        protected abstract object GetItem([NotNull] NSIndexPath indexPath);

        private protected virtual void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();
        }

        protected abstract void ReloadSections(
            [NotNull] NotifyCollectionChangedEventArgs args,
            UITableViewRowAnimation withRowAnimation = UITableViewRowAnimation.Automatic);

        protected virtual void ReloadSection(
            nint section,
            [NotNull] NotifyCollectionChangedEventArgs args,
            UITableViewRowAnimation withRowAnimation = UITableViewRowAnimation.Automatic)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (TableViewWeakReference.TryGetTarget(out var tableView))
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        tableView.SupportPerformBatchUpdates(() => tableView.InsertRows(args.ToNewIndexPaths(section), withRowAnimation));
                        break;
                    case NotifyCollectionChangedAction.Move:
                        tableView.MoveRow(args.ToOldIndexPath(section), args.ToNewIndexPath(section));
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        tableView.SupportPerformBatchUpdates(() => tableView.ReloadRows(args.ToNewIndexPaths(section), withRowAnimation));
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        tableView.SupportPerformBatchUpdates(() => tableView.DeleteRows(args.ToOldIndexPaths(section), withRowAnimation));
                        break;
                    default:
                        tableView.ReloadSections(NSIndexSet.FromIndex(section), withRowAnimation);
                        break;
                }
            }
        }
    }
}
