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
using CoreGraphics;
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UICollectionViewObservableSectionHeaderFooterCell
        : UICollectionReusableView
    {
        public UICollectionViewObservableSectionHeaderFooterCell()
        {
            Initialize();
        }

        public UICollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public UICollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        protected UICollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal UICollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
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

        internal virtual void Bind([CanBeNull] object itemsContext, [CanBeNull] object group)
        {
        }
    }

    public class UICollectionViewObservableSectionHeaderFooterCell<TItemsContext>
        : UICollectionViewObservableSectionHeaderFooterCell
    {
        public UICollectionViewObservableSectionHeaderFooterCell()
        {
        }

        public UICollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public UICollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        protected UICollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal UICollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
            : base(handle)
        {
        }

        [CanBeNull]
        public TItemsContext ItemsContext { get; private set; }

        internal override void Bind(object itemsContext, object group)
        {
            base.Bind(itemsContext, group);

            ItemsContext = (TItemsContext)itemsContext;

            Bind(ItemsContext);
        }

        public virtual void Bind([CanBeNull] TItemsContext itemsContext)
        {
        }
    }

    public class UICollectionViewObservableSectionHeaderFooterCell<TItemsContext, TGroup>
        : UICollectionViewObservableSectionHeaderFooterCell<TItemsContext>
    {
        public UICollectionViewObservableSectionHeaderFooterCell()
        {
        }

        public UICollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public UICollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        protected UICollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal UICollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
            : base(handle)
        {
        }

        [CanBeNull]
        public TGroup Group { get; private set; }

        internal override void Bind(object itemsContext, object group)
        {
            base.Bind(itemsContext, group);

            Group = (TGroup)group;

            Bind(Group);
        }

        public virtual void Bind([CanBeNull] TGroup group)
        {
        }
    }
}
