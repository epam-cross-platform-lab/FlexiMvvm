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
using CoreGraphics;
using FlexiMvvm.Bindings;
using Foundation;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class UICollectionViewBindableItemCell<TItemsContext, TItem> : UICollectionViewObservableItemCell<TItemsContext, TItem>
        where TItemsContext : class
        where TItem : class
    {
        [CanBeNull]
        private BindingSet<TItemsContext> _itemsContextBindingSet;
        [CanBeNull]
        private BindingSet<TItem> _itemBindingSet;

        public UICollectionViewBindableItemCell()
        {
        }

        public UICollectionViewBindableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public UICollectionViewBindableItemCell(CGRect frame)
            : base(frame)
        {
        }

        protected UICollectionViewBindableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal UICollectionViewBindableItemCell(IntPtr handle)
            : base(handle)
        {
        }

        public override void Bind(TItemsContext itemsContext)
        {
            base.Bind(itemsContext);

            if (_itemsContextBindingSet == null)
            {
                _itemsContextBindingSet = new BindingSet<TItemsContext>(itemsContext);
                Bind(_itemsContextBindingSet);
                _itemsContextBindingSet.Apply();
            }
        }

        public virtual void Bind([NotNull] BindingSet<TItemsContext> bindingSet)
        {
        }

        public override void Bind(TItem item)
        {
            base.Bind(item);

            if (_itemBindingSet == null)
            {
                _itemBindingSet = new BindingSet<TItem>(item);
                Bind(_itemBindingSet);
                _itemBindingSet.Apply();
            }
            else
            {
                _itemBindingSet.SetSourceItem(item);
            }
        }

        public virtual void Bind([NotNull] BindingSet<TItem> bindingSet)
        {
        }
    }
}
