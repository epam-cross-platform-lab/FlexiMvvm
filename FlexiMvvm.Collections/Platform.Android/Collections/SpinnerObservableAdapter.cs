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
using Android.Content;
using Android.Content.Res;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FlexiMvvm.Collections
{
    /// <summary>
    /// A concrete <see cref="BaseAdapter"/> that is backed by a collection of arbitrary objects for consumption by a <see cref="Spinner"/>.
    /// Can track changes of <see cref="INotifyCollectionChanged"/> Items and notify <see cref="Spinner"/> about them.
    /// </summary>
    /// <typeparam name="T">The type of the collection item.</typeparam>
    public class SpinnerObservableAdapter<T> : BaseAdapter<T>, IThemedSpinnerAdapter, IItemsSource<T>
    {
        private readonly ArrayAdapter<T> _adapter;
        private DisposableCollection? _itemsSubscriptions;
        private IEnumerable<T>? _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter{T}"/> class.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="resource">The resource ID for a layout file containing a <see cref="TextView"/> to use when instantiating views.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <c>null</c>.</exception>
        public SpinnerObservableAdapter(Context context, int resource)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _adapter = new ArrayAdapter<T>(context, resource);
            _adapter.SetNotifyOnChange(false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter{T}"/> class.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="resource">The resource ID for a layout file containing a <see cref="TextView"/> to use when instantiating views.</param>
        /// <param name="textViewResourceId">The id of the <see cref="TextView"/> within the layout resource to be populated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <c>null</c>.</exception>
        public SpinnerObservableAdapter(Context context, int resource, int textViewResourceId)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            _adapter = new ArrayAdapter<T>(context, resource, textViewResourceId);
            _adapter.SetNotifyOnChange(false);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter{T}"/> class. Used when creating managed representations of JNI objects; called by the runtime.
        /// </summary>
        /// <param name="handle">A <see cref="IntPtr"/> containing a Java Native Interface (JNI) object reference.</param>
        /// <param name="transfer">A <see cref="JniHandleOwnership"/> indicating how to handle <paramref name="handle"/>.</param>
        public SpinnerObservableAdapter(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
            _adapter = new ArrayAdapter<T>(handle, transfer);
            _adapter.SetNotifyOnChange(false);
        }

        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        /// <summary>
        /// Gets the context associated with this adapter.
        /// <para>The context is used to create views from the resource passed to the constructor.</para>
        /// </summary>
        public virtual Context Context => _adapter.Context;

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
        public override int Count => _adapter.Count;

        /// <summary>
        /// Gets or sets the <see cref="Resources.Theme"/> against which drop-down views are inflated.
        /// <para>By default, drop-down views are inflated against the theme of the <see cref="Android.Content.Context" /> passed to the adapter's constructor.</para>
        /// </summary>
        public Resources.Theme DropDownViewTheme
        {
            get => _adapter.DropDownViewTheme;
            set => _adapter.DropDownViewTheme = value;
        }

        /// <summary>
        /// Gets the item at the specified position in the collection.
        /// </summary>
        /// <param name="position">The zero-based position of the item to get.</param>
        /// <returns>The item at the specified position.</returns>
        public override T this[int position] => _adapter.GetItem(position);

        /// <summary>
        /// Get the data item associated with the specified position in the collection.
        /// </summary>
        /// <param name="position">Position of the item whose data we want within the adapter's collection.</param>
        /// <returns>The data at the specified position. Can be <c>null</c>.</returns>
        public override Java.Lang.Object? GetItem(int position)
        {
            return ((ArrayAdapter)_adapter).GetItem(position);
        }

        /// <summary>
        /// Get the row id associated with the specified position in the collection.
        /// </summary>
        /// <param name="position">The position of the item within the adapter's collection whose row id we want.</param>
        /// <returns>The id of the item at the specified position.</returns>
        public override long GetItemId(int position)
        {
            return _adapter.GetItemId(position);
        }

        /// <summary>
        /// Gets the position of the specified item in the collection.
        /// </summary>
        /// <param name="item">The item to retrieve the position of. Can be <c>null</c>.</param>
        /// <returns>The position of the specified item.</returns>
        public int GetPosition(Java.Lang.Object? item)
        {
            return _adapter.GetPosition(item);
        }

        /// <summary>
        /// Get a <see cref="View"/> that displays the data at the specified position in the collection.
        /// </summary>
        /// <param name="position">The position of the item within the adapter's collection of the item whose view we want.</param>
        /// <param name="convertView">The old view to reuse, if possible. Can be <c>null</c>.</param>
        /// <param name="parent">The parent that this view will eventually be attached to.</param>
        /// <returns>A <see cref="View"/> corresponding to the data at the specified position.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parent"/> is <c>null</c>.</exception>
        public override View GetView(int position, View? convertView, ViewGroup parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return _adapter.GetView(position, convertView, parent);
        }

        /// <summary>
        /// Gets a <see cref="View"/> that displays in the drop down popup the data at the specified position in the collection.
        /// </summary>
        /// <param name="position">The index of the item whose view we want.</param>
        /// <param name="convertView">The old view to reuse, if possible. Can be <c>null</c>.</param>
        /// <param name="parent">The parent that this view will eventually be attached to.</param>
        /// <returns>A <see cref="View"/> corresponding to the data at the specified position.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="parent"/> is <c>null</c>.</exception>
        public override View GetDropDownView(int position, View? convertView, ViewGroup parent)
        {
            if (parent == null)
                throw new ArgumentNullException(nameof(parent));

            return _adapter.GetDropDownView(position, convertView, parent);
        }

        /// <summary>
        /// Sets the layout resource to create the drop down views.
        /// </summary>
        /// <param name="resource">The layout resource defining the drop down views.</param>
        public virtual void SetDropDownViewResource(int resource)
        {
            _adapter.SetDropDownViewResource(resource);
        }

        /// <summary>
        /// Updates the adapter based on passed <paramref name="args"/>. Notifies the <see cref="Spinner"/> about changes.
        /// </summary>
        /// <param name="args">The <see cref="Items"/> collection changes needs to be applied.</param>
        /// <exception cref="ArgumentNullException"><paramref name="args"/> is <c>null</c>.</exception>
        protected virtual void Reload(NotifyCollectionChangedEventArgs args)
        {
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            switch (args.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    var index = args.NewStartingIndex;

                    foreach (T item in args.NewItems)
                    {
                        _adapter.Insert(item, index);
                        index++;
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (T item in args.OldItems)
                    {
                        _adapter.Remove(item);
                    }

                    break;
                default:
                    _adapter.Clear();
                    _adapter.AddAll(Items?.ToList());
                    break;
            }

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
    public class SpinnerObservableAdapter : SpinnerObservableAdapter<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter"/> class.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="resource">The resource ID for a layout file containing a <see cref="TextView"/> to use when instantiating views.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <c>null</c>.</exception>
        public SpinnerObservableAdapter(Context context, int resource)
            : base(context, resource)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter"/> class.
        /// </summary>
        /// <param name="context">The current context.</param>
        /// <param name="resource">The resource ID for a layout file containing a <see cref="TextView"/> to use when instantiating views.</param>
        /// <param name="textViewResourceId">The id of the <see cref="TextView"/> within the layout resource to be populated.</param>
        /// <exception cref="ArgumentNullException"><paramref name="context"/> is <c>null</c>.</exception>
        public SpinnerObservableAdapter(Context context, int resource, int textViewResourceId)
            : base(context, resource, textViewResourceId)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpinnerObservableAdapter"/> class. Used when creating managed representations of JNI objects; called by the runtime.
        /// </summary>
        /// <param name="handle">A <see cref="IntPtr"/> containing a Java Native Interface (JNI) object reference.</param>
        /// <param name="transfer">A <see cref="JniHandleOwnership"/> indicating how to handle <paramref name="handle"/>.</param>
        public SpinnerObservableAdapter(IntPtr handle, JniHandleOwnership transfer)
            : base(handle, transfer)
        {
        }
    }
}
