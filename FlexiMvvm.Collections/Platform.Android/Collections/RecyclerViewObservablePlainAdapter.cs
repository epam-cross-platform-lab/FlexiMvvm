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
using Android.Support.V7.Widget;
using FlexiMvvm.Collections.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public abstract class RecyclerViewObservablePlainAdapter : RecyclerViewObservableAdapter, IItemsSource<object>
    {
        protected const int DefaultSection = 0;
        protected const int DefaultSectionCount = 1;

        [NotNull]
        private readonly PlainItemsMapping _itemsMapping = new PlainItemsMapping();
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object>? _items;

        protected RecyclerViewObservablePlainAdapter([NotNull] RecyclerView recyclerView)
            : base(recyclerView)
        {
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

        public override int GetSectionsCount()
        {
            return DefaultSectionCount;
        }

        public override int GetSectionItemsCount(int section)
        {
            return section == DefaultSection ? Items?.Count() ?? 0 : 0;
        }

        public override int GetItemViewType(int position)
        {
            var itemMap = GetItemMap(position);

            switch (itemMap.ItemKind)
            {
                case ItemKind.SectionHeader:
                    return ItemViewType.Combine(ItemKind.SectionHeader, DefaultViewType);
                case ItemKind.SectionFooter:
                    return ItemViewType.Combine(ItemKind.SectionFooter, DefaultViewType);
                default:
                    return base.GetItemViewType(position);
            }
        }

        private protected override ItemsMapping GetItemsMapping()
        {
            return _itemsMapping;
        }

        protected internal override object GetItem(int section, int row)
        {
            if (section != DefaultSection)
                throw new InvalidOperationException($"Unable to get item for \"{section}\" section. Only \"{DefaultSection}\" section is supported.");
            if (Items == null)
                throw new InvalidOperationException($"Unable to get item at \"{row}\" position due to \"{nameof(Items)}\" collection is null.");

            return Items.ElementAt(row);
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

            _itemsMapping.Reload(this);
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            ReloadSection(DefaultSection, e);
        }
    }
}
