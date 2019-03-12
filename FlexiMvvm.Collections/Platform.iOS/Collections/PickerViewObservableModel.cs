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
using UIKit;

namespace FlexiMvvm.Collections
{
    /// <summary>
    /// A concrete <see cref="UIPickerViewModel"/> that is backed by a collection of arbitrary objects for consumption by a <see cref="UIPickerView"/>.
    /// Can track changes of <see cref="INotifyCollectionChanged"/> and notify <see cref="UIPickerView"/> about them.
    /// </summary>
    /// <typeparam name="T">The type of the collection item.</typeparam>
    public class PickerViewObservableModel<T> : UIPickerViewModel, IItemsSource<T>
    {
        private const int DefaultComponentCount = 1;
        private const int DefaultComponentIndex = 0;

        [Weak]
        private readonly UIPickerView _pickerView;
        private IEnumerable<T>? _items;
        private DisposableCollection? _itemsSubscriptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="PickerViewObservableModel{T}"/> class.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public PickerViewObservableModel(UIPickerView pickerView)
        {
            _pickerView = pickerView ?? throw new ArgumentNullException(nameof(pickerView));
        }

        /// <summary>
        /// Raised when <see cref="Selected(UIPickerView, nint, nint)"/> method has called.
        /// </summary>
        public event EventHandler<PickerViewItemSelectedEventArgs> SelectedCalled;

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
                    ReloadComponent(_pickerView, DefaultComponentIndex);
                }
            }
        }

        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        /// <summary>
        /// Called by the picker view when it needs the number of components.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <returns>The number of components that the picker view should display.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public override nint GetComponentCount(UIPickerView pickerView)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            // TODO: add multiple components support
            return DefaultComponentCount;
        }

        /// <summary>
        /// Called by the picker view when it needs the number of rows for a specified component.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <param name="component">The component index of the <paramref name="pickerView"/>.</param>
        /// <returns>The number of rows for the component.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            // TODO: add multiple components support
            return component == DefaultComponentIndex
                ? Items?.Count() ?? 0
                : 0;
        }

        /// <summary>
        /// Called by the picker view when it needs the title to use for a given row in a given component.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <param name="row">The row index of the <paramref name="component"/>.</param>
        /// <param name="component">The component index of the <paramref name="pickerView"/>.</param>
        /// <returns>The title of the indicated component row.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public override string GetTitle(UIPickerView pickerView, nint row, nint component)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            // TODO: add multiple components support
            var index = (int)row;

            return component == DefaultComponentIndex
                ? Items?.ElementAt(index)?.ToString() ?? string.Empty
                : string.Empty;
        }

        /// <summary>
        /// Called by the picker view when the user selects a row in a component.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <param name="row">The row index of the <paramref name="component"/>.</param>
        /// <param name="component">The component index of the <paramref name="pickerView"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            SelectedCalled?.Invoke(this, new PickerViewItemSelectedEventArgs(row, component));
        }

        /// <summary>
        /// Reloads a particular component of the picker view.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <param name="component">The component index of the <paramref name="pickerView"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        protected virtual void ReloadComponent(UIPickerView pickerView, nint component)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            pickerView.ReloadComponent(component);
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
            ReloadComponent(_pickerView, DefaultComponentIndex);
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
    public class PickerViewObservableModel : PickerViewObservableModel<object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PickerViewObservableModel"/> class.
        /// </summary>
        /// <param name="pickerView">The picker view.</param>
        /// <exception cref="ArgumentNullException"><paramref name="pickerView"/> is <c>null</c>.</exception>
        public PickerViewObservableModel(UIPickerView pickerView)
            : base(pickerView)
        {
        }
    }
}
