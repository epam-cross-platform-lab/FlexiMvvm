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
using Android.Support.V4.App;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class FragmentStatePagerObservableAdapter : FragmentStatePagerAdapter
    {
        [NotNull]
        private readonly Func<object, Fragment> _fragmentFactory;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object> _items;
        [CanBeNull]
        [ItemNotNull]
        private DisposableCollection _itemsSubscriptions;

        public FragmentStatePagerObservableAdapter(
            [NotNull] FragmentManager fragmentManager,
            [NotNull] Func<object, Fragment> fragmentFactory)
            : base(fragmentManager)
        {
            _fragmentFactory = fragmentFactory ?? throw new ArgumentNullException(nameof(fragmentFactory));
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
                    NotifyDataSetChanged();
                }
            }
        }

        public override int Count => Items?.Count() ?? 0;

        [NotNull]
        [ItemNotNull]
        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        public override Fragment GetItem(int position)
        {
            if (Items == null)
                throw new InvalidOperationException($"Unable to get item at \"{position}\" position due to \"{nameof(Items)}\" collection is null.");

            return _fragmentFactory(Items.ElementAt(position));
        }

        private void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = new DisposableCollection();

            if (Items is INotifyCollectionChanged observableItems)
            {
                observableItems.CollectionChangedWeakSubscribe(Items_CollectionChanged).DisposeWith(ItemsSubscriptions);
            }
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            NotifyDataSetChanged();
        }
    }
}
