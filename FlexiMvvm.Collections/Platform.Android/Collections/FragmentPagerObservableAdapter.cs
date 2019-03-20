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
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace FlexiMvvm.Collections
{
    /// <summary>
    /// Implementation of <see cref="PagerAdapter"/> that represents each page as a <see cref="Fragment"/>
    /// that is persistently kept in the fragment manager as long as the user can return to the page.
    /// Can track changes of <see cref="INotifyCollectionChanged"/> Items and notify adapter consumer about them.
    /// </summary>
    /// <typeparam name="T">The type of the collection item.</typeparam>
    public class FragmentPagerObservableAdapter<T> : FragmentPagerAdapter, IItemsSource<T>
    {
        private readonly Func<T, Fragment> _fragmentFactory;
        private DisposableCollection? _itemsSubscriptions;
        private IEnumerable<T>? _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="FragmentPagerObservableAdapter{T}"/> class.
        /// </summary>
        /// <param name="fragmentManager">The fragment manager.</param>
        /// <param name="fragmentFactory">The factory which creates <see cref="Fragment"/> instance for the provided item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fragmentFactory"/> is <c>null</c>.</exception>
        public FragmentPagerObservableAdapter(
            FragmentManager fragmentManager,
            Func<T, Fragment> fragmentFactory)
            : base(fragmentManager)
        {
            _fragmentFactory = fragmentFactory ?? throw new ArgumentNullException(nameof(fragmentFactory));
        }

        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        /// <inheritdoc />
        public IEnumerable<T>? Items
        {
            get => _items;
            set
            {
                if (!ReferenceEquals(_items, value))
                {
                    _items = value;

                    RefreshItemsSubscriptions();
                    Reload(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                }
            }
        }

        /// <summary>
        /// Gets the count of items that are in the collection represented by this adapter.
        /// </summary>
        public override int Count => Items?.Count() ?? 0;

        /// <summary>
        /// Return the <see cref="Fragment"/> associated with a specified position.
        /// </summary>
        /// <param name="position">The position for which the fragment should be returned.</param>
        /// <returns>The <see cref="Fragment"/> instance.</returns>
        /// <exception cref="InvalidOperationException">Unable to get item due to <see cref="Items"/> collection is <c>null</c>.</exception>
        public override Fragment GetItem(int position)
        {
            if (Items == null)
                throw new InvalidOperationException($"Unable to get item at '{position}' position due to '{nameof(Items)}' collection is 'null'.");

            return _fragmentFactory(Items.ElementAt(position));
        }

        /// <summary>
        /// Updates the adapter based on passed <paramref name="args"/>. Notifies the adapter consumer about changes.
        /// </summary>
        /// <param name="args">The <see cref="Items"/> collection changes needs to be applied.</param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <c>null</c>.</exception>
        protected virtual void Reload(NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            NotifyDataSetChanged();
        }

        private void RefreshItemsSubscriptions()
        {
            _itemsSubscriptions?.Dispose();
            _itemsSubscriptions = null;

            if (Items is INotifyCollectionChanged observableItems)
            {
                observableItems.CollectionChangedWeakSubscribe(Items_CollectionChanged).DisposeWith(ItemsSubscriptions);
            }
        }

        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Reload(e);
        }

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _itemsSubscriptions?.Dispose();
                _itemsSubscriptions = null;
            }

            base.Dispose(disposing);
        }
    }

    /// <inheritdoc />
    public class FragmentPagerObservableAdapter : FragmentPagerObservableAdapter<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FragmentPagerObservableAdapter"/> class.
        /// </summary>
        /// <param name="fragmentManager">The fragment manager.</param>
        /// <param name="fragmentFactory">The factory which creates <see cref="Fragment"/> instance for the provided item.</param>
        /// <exception cref="ArgumentNullException"><paramref name="fragmentFactory"/> is <c>null</c>.</exception>
        public FragmentPagerObservableAdapter(
            FragmentManager fragmentManager,
            Func<object, Fragment> fragmentFactory)
            : base(fragmentManager, fragmentFactory)
        {
        }
    }
}
