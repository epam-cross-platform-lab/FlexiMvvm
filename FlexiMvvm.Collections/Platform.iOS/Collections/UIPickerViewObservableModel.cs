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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UIPickerViewObservableModel : UIPickerViewModel
    {
        private const int ComponentDefaultCount = 1;
        private const int ComponentDefaultIndex = 0;

        [NotNull]
        private readonly WeakReference<UIPickerView> _pickerViewWeakReference;
        [CanBeNull]
        [ItemCanBeNull]
        private IEnumerable<object> _items;
        [CanBeNull]
        private object _selectedItem;
        [CanBeNull]
        private DisposableCollection _itemsSubscriptions;

        public UIPickerViewObservableModel([NotNull] UIPickerView pickerView)
        {
            if (pickerView == null)
                throw new ArgumentNullException(nameof(pickerView));

            _pickerViewWeakReference = new WeakReference<UIPickerView>(pickerView);
        }

        public event EventHandler<SelectionChangedEventArgs> SelectedCalled;

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
                    ReloadComponent(ComponentDefaultIndex);
                }
            }
        }

        [CanBeNull]
        public object SelectedItem
        {
            get => GetSelectedItem();
            set
            {
                if (SetSelectedItem(value, false))
                {
                    SelectItem(value, ComponentDefaultIndex);
                }
            }
        }

        [NotNull]
        private DisposableCollection ItemsSubscriptions => _itemsSubscriptions ?? (_itemsSubscriptions = new DisposableCollection());

        [CanBeNull]
        private object GetSelectedItem()
        {
            return _selectedItem;
        }

        private bool SetSelectedItem([CanBeNull] object item, bool raiseEvent = true)
        {
            if (!ReferenceEquals(_selectedItem, item))
            {
                _selectedItem = item;

                if (raiseEvent)
                {
                    SelectedCalled?.Invoke(this, new SelectionChangedEventArgs(_selectedItem));
                }

                return true;
            }

            return false;
        }

        public override nint GetComponentCount([NotNull] UIPickerView pickerView)
        {
            return ComponentDefaultCount;
        }

        public override nint GetRowsInComponent([NotNull] UIPickerView pickerView, nint component)
        {
            return Items?.Count() ?? 0;
        }

        public override string GetTitle([NotNull] UIPickerView pickerView, nint row, nint component)
        {
            return GetItem(row)?.ToString();
        }

        public override void Selected([NotNull] UIPickerView pickerView, nint row, nint component)
        {
            SetSelectedItem(GetItem(row));
        }

        [CanBeNull]
        private object GetItem(nint row)
        {
            return Items?.ElementAt((int)row);
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

        private void ReloadComponent(int component)
        {
            if (_pickerViewWeakReference.TryGetTarget(out var pickerView))
            {
                pickerView.ReloadComponent(component);
            }
        }

        private void SelectItem([CanBeNull] object selectedItem, int component)
        {
            if (_pickerViewWeakReference.TryGetTarget(out var pickerView) && Items != null)
            {
                var selectedItemPosition = -1;

                for (var i = 0; i < Items.Count(); i++)
                {
                    if (ReferenceEquals(Items.ElementAt(i), selectedItem))
                    {
                        selectedItemPosition = i;
                        break;
                    }
                }

                if (selectedItemPosition != -1)
                {
                    pickerView.Select(selectedItemPosition, component, true);
                }
            }
        }

        private void Items_CollectionChanged([NotNull] object sender, [NotNull] NotifyCollectionChangedEventArgs e)
        {
            ReloadComponent(ComponentDefaultIndex);
        }
    }
}
