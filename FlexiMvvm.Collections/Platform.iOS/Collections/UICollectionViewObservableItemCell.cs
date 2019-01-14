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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UICollectionViewObservableItemCell : UICollectionViewCell
    {
        public UICollectionViewObservableItemCell()
        {
            Initialize();
        }

        public UICollectionViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public UICollectionViewObservableItemCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        protected UICollectionViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal UICollectionViewObservableItemCell(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        private void Initialize()
        {
            LoadView();
            ViewDidLoad();
        }

        public virtual void LoadView()
        {
        }

        public virtual void ViewDidLoad()
        {
        }

        internal virtual void Bind([CanBeNull] object itemsContext, [CanBeNull] object item)
        {
        }
    }

    public class UICollectionViewObservableItemCell<TItemsContext, TItem> : UICollectionViewObservableItemCell
    {
        public UICollectionViewObservableItemCell()
        {
        }

        public UICollectionViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public UICollectionViewObservableItemCell(CGRect frame)
            : base(frame)
        {
        }

        protected UICollectionViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal UICollectionViewObservableItemCell(IntPtr handle)
            : base(handle)
        {
        }

        [CanBeNull]
        public TItemsContext ItemsContext { get; private set; }

        [CanBeNull]
        public TItem Item { get; private set; }

        internal override void Bind(object itemsContext, object item)
        {
            base.Bind(itemsContext, item);

            ItemsContext = (TItemsContext)itemsContext;
            Item = (TItem)item;

            Bind(ItemsContext);
            Bind(Item);
        }

        public virtual void Bind([CanBeNull] TItemsContext itemsContext)
        {
        }

        public virtual void Bind([CanBeNull] TItem item)
        {
        }
    }
}
