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

using System.ComponentModel;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Source
{
    internal class SourceItemPropertyBinding<TItem, TValue> : SourceItemBinding<TItem, TValue>
        where TItem : class
    {
        [NotNull]
        private readonly ItemValueAccessor<TItem, TValue> _itemValueAccessor;

        internal SourceItemPropertyBinding(
            [NotNull] ItemReference<TItem> itemReference,
            [NotNull] ItemValueAccessor<TItem, TValue> itemValueAccessor)
            : base(itemReference, itemValueAccessor.ToString)
        {
            _itemValueAccessor = itemValueAccessor;
        }

        protected internal override BindingMode BindingMode => _itemValueAccessor.CanSetValue ? BindingMode.TwoWay : BindingMode.OneWay;

        protected internal override bool TryGetItem(out TItem item)
        {
            return base.TryGetItem(out item) && _itemValueAccessor.TryGetValueOwnerItem(item, out _);
        }

        protected internal override void SubscribeToEvents(TItem item)
        {
            if (_itemValueAccessor.TryGetValueOwnerItem(item, out var valueOwnerItem))
            {
                if (valueOwnerItem is INotifyPropertyChanged observableValueOwnerItem)
                {
                    observableValueOwnerItem.PropertyChanged += Item_PropertyChanged;
                }
            }
        }

        protected internal override void UnsubscribeFromEvents(TItem item)
        {
            if (_itemValueAccessor.TryGetValueOwnerItem(item, out var valueOwnerItem))
            {
                if (valueOwnerItem is INotifyPropertyChanged observableValueOwnerItem)
                {
                    observableValueOwnerItem.PropertyChanged -= Item_PropertyChanged;
                }
            }
        }

        protected internal override bool TryGetValue(TItem item, out TValue value)
        {
            return _itemValueAccessor.TryGetValue(item, out value);
        }

        protected internal override void SetValue(TItem item, TValue value, bool silent)
        {
            if (silent)
            {
                UnsubscribeFromEvents(item);
            }

            _itemValueAccessor.SetValue(item, value);

            if (silent)
            {
                SubscribeToEvents(item);
            }
        }

        private void Item_PropertyChanged([NotNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            if (e.PropertyName == _itemValueAccessor.PropertyName && TryGetItem(out var item) && TryGetValue(item, out var value))
            {
                RaiseValueChanged(value);
            }
        }
    }
}
