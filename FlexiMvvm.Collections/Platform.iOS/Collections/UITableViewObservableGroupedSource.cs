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
    public class UITableViewObservableGroupedSource : UITableViewObservableSourceBase
    {
        [CanBeNull]
        private readonly Func<object, string> _sectionHeaderCellReuseIdFactory;
        [CanBeNull]
        private readonly Func<object, string> _sectionFooterCellReuseIdFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<IGrouping<object, object>> _groupedItems;

        public UITableViewObservableGroupedSource(
            [NotNull] UITableView tableView,
            [NotNull] Func<object, string> itemCellReuseIdFactory,
            [CanBeNull] Func<object, string> sectionHeaderCellReuseIdFactory = null,
            [CanBeNull] Func<object, string> sectionFooterCellReuseIdFactory = null)
            : base(tableView, itemCellReuseIdFactory)
        {
            _sectionHeaderCellReuseIdFactory = sectionHeaderCellReuseIdFactory;
            _sectionFooterCellReuseIdFactory = sectionFooterCellReuseIdFactory;
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

        public override nint NumberOfSections([NotNull] UITableView tableView)
        {
            return GroupedItems?.Count() ?? 0;
        }

        public override nint RowsInSection([NotNull] UITableView tableview, nint section)
        {
            return GroupedItems != null ? GetItemsGroup(section)?.Count() ?? 0 : 0;
        }

        public override nfloat GetHeightForHeader([NotNull] UITableView tableView, nint section)
        {
            return _sectionHeaderCellReuseIdFactory != null ? UITableView.AutomaticDimension : ZeroHeight;
        }

        [CanBeNull]
        public override UIView GetViewForHeader([NotNull] UITableView tableView, nint section)
        {
            UITableViewObservableSectionHeaderFooterCell sectionHeaderCell = null;

            if (_sectionHeaderCellReuseIdFactory != null)
            {
                var itemsGroup = GetItemsGroup(section);
                var group = itemsGroup?.Key;
                var sectionHeaderCellReuseId = _sectionHeaderCellReuseIdFactory(group);
                sectionHeaderCell = (UITableViewObservableSectionHeaderFooterCell)tableView.DequeueReusableHeaderFooterView(
                    sectionHeaderCellReuseId).NotNull();

                sectionHeaderCell.Bind(ItemsContext, group);
            }

            return sectionHeaderCell;
        }

        public override nfloat GetHeightForFooter([NotNull] UITableView tableView, nint section)
        {
            return _sectionFooterCellReuseIdFactory != null ? UITableView.AutomaticDimension : ZeroHeight;
        }

        [CanBeNull]
        public override UIView GetViewForFooter([NotNull] UITableView tableView, nint section)
        {
            UITableViewObservableSectionHeaderFooterCell sectionFooterCell = null;

            if (_sectionFooterCellReuseIdFactory != null)
            {
                var itemsGroup = GetItemsGroup(section);
                var group = itemsGroup?.Key;
                var sectionFooterCellReuseId = _sectionFooterCellReuseIdFactory(group);
                sectionFooterCell = (UITableViewObservableSectionHeaderFooterCell)tableView.DequeueReusableHeaderFooterView(
                    sectionFooterCellReuseId).NotNull();

                sectionFooterCell.Bind(ItemsContext, group);
            }

            return sectionFooterCell;
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

        protected override void ReloadSections(
            NotifyCollectionChangedEventArgs args,
            UITableViewRowAnimation withRowAnimation = UITableViewRowAnimation.Automatic)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (TableViewWeakReference.TryGetTarget(out var tableView))
            {
                switch (args.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        tableView.SupportPerformBatchUpdates(() => tableView.InsertSections(args.ToNewIndexSet(), withRowAnimation));
                        break;
                    case NotifyCollectionChangedAction.Move:
                        tableView.MoveSection(args.OldStartingIndex, args.NewStartingIndex);
                        break;
                    case NotifyCollectionChangedAction.Replace:
                        tableView.SupportPerformBatchUpdates(() => tableView.ReloadSections(args.ToNewIndexSet(), withRowAnimation));
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        tableView.SupportPerformBatchUpdates(() => tableView.DeleteSections(args.ToOldIndexSet(), withRowAnimation));
                        break;
                    default:
                        tableView.ReloadData();
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
