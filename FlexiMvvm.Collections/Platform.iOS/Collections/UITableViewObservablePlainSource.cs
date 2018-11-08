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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UITableViewObservablePlainSource : UITableViewObservableSourceBase
    {
        protected const int DefaultSection = 0;
        protected const int DefaultSectionCount = 1;

        [CanBeNull]
        private readonly Func<string> _sectionHeaderCellReuseIdFactory;
        [CanBeNull]
        private readonly Func<string> _sectionFooterCellReuseIdFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object> _items;

        public UITableViewObservablePlainSource(
            [NotNull] UITableView tableView,
            [NotNull] Func<object, string> itemCellReuseIdFactory,
            [CanBeNull] Func<string> sectionHeaderCellReuseIdFactory = null,
            [CanBeNull] Func<string> sectionFooterCellReuseIdFactory = null)
            : base(tableView, itemCellReuseIdFactory)
        {
            _sectionHeaderCellReuseIdFactory = sectionHeaderCellReuseIdFactory;
            _sectionFooterCellReuseIdFactory = sectionFooterCellReuseIdFactory;
        }

        [CanBeNull]
        [ItemCanBeNull]
        public IEnumerable<object> Items
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

        public override nint NumberOfSections([NotNull] UITableView tableView)
        {
            return DefaultSectionCount;
        }

        public override nint RowsInSection([NotNull] UITableView tableview, nint section)
        {
            return section == DefaultSection && Items != null ? Items.Count() : 0;
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
                var sectionHeaderCellReuseId = _sectionHeaderCellReuseIdFactory();
                sectionHeaderCell = (UITableViewObservableSectionHeaderFooterCell)tableView.DequeueReusableHeaderFooterView(
                    sectionHeaderCellReuseId).NotNull();

                sectionHeaderCell.Bind(ItemsContext, null);
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
                var sectionFooterCellReuseId = _sectionFooterCellReuseIdFactory();
                sectionFooterCell = (UITableViewObservableSectionHeaderFooterCell)tableView.DequeueReusableHeaderFooterView(
                    sectionFooterCellReuseId).NotNull();

                sectionFooterCell.Bind(ItemsContext, null);
            }

            return sectionFooterCell;
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

        protected override void ReloadSections(
            NotifyCollectionChangedEventArgs args,
            UITableViewRowAnimation withRowAnimation = UITableViewRowAnimation.Automatic)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (TableViewWeakReference.TryGetTarget(out var tableView))
            {
                tableView.ReloadData();
            }
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            ReloadSection(DefaultSection, e);
        }
    }
}
