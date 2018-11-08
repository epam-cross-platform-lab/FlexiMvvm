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

using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Target
{
    internal class TargetItemPropertyBinding<TItem, TValue> : TargetItemBinding<TItem, TValue>
        where TItem : class
    {
        [NotNull]
        private readonly ItemValueAccessor<TItem, TValue> _itemValueAccessor;

        internal TargetItemPropertyBinding(
            [NotNull] ItemReference<TItem> itemReference,
            [NotNull] ItemValueAccessor<TItem, TValue> itemValueAccessor)
            : base(itemReference, itemValueAccessor.ToString)
        {
            _itemValueAccessor = itemValueAccessor;
        }

        protected internal override BindingMode BindingMode => _itemValueAccessor.CanSetValue ? BindingMode.TwoWay : BindingMode.OneWayToSource;

        protected internal override bool TryGetValue(TItem item, out TValue value)
        {
            return _itemValueAccessor.TryGetValue(item, out value);
        }

        protected internal override void SetValue(TItem item, TValue value, bool silent)
        {
            _itemValueAccessor.SetValue(item, value);
        }
    }
}
