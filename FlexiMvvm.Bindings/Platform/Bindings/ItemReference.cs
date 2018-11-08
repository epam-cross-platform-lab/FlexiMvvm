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
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    internal class ItemReference<TItem> : IItemReference<TItem>
        where TItem : class
    {
        [CanBeNull]
        private readonly WeakReference _itemWeakReference;
        private readonly ItemReferenceType _referenceType;
        [CanBeNull]
        private TItem _itemStrongReference;

        internal ItemReference([CanBeNull] TItem item, ItemReferenceType referenceType)
        {
            if (referenceType == ItemReferenceType.Weak)
            {
                _itemWeakReference = new WeakReference(item);
            }
            else
            {
                _itemStrongReference = item;
            }

            _referenceType = referenceType;
        }

        [CanBeNull]
        public TItem GetItem()
        {
            if (_referenceType == ItemReferenceType.Weak)
            {
                return (TItem)_itemWeakReference.NotNull().Target;
            }

            return _itemStrongReference;
        }

        public void Dispose()
        {
            _itemStrongReference = null;
        }
    }
}
