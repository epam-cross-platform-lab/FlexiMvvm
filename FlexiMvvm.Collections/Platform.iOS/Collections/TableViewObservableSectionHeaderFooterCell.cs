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
    public class TableViewObservableSectionHeaderFooterCell : UITableViewHeaderFooterView
    {
        public TableViewObservableSectionHeaderFooterCell()
        {
            Initialize();
        }

        public TableViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public TableViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public TableViewObservableSectionHeaderFooterCell(NSString reuseIdentifier)
            : base(reuseIdentifier)
        {
            Initialize();
        }

        protected TableViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal TableViewObservableSectionHeaderFooterCell(IntPtr handle)
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

    public class TableViewObservableSectionHeaderFooterCell<TItemsContext> : TableViewObservableSectionHeaderFooterCell
    {
        public TableViewObservableSectionHeaderFooterCell()
        {
        }

        public TableViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public TableViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        public TableViewObservableSectionHeaderFooterCell(NSString reuseIdentifier)
            : base(reuseIdentifier)
        {
        }

        protected TableViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal TableViewObservableSectionHeaderFooterCell(IntPtr handle)
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

    public class TableViewObservableSectionHeaderFooterCell<TItemsContext, TGroup> : TableViewObservableSectionHeaderFooterCell<TItemsContext>
    {
        public TableViewObservableSectionHeaderFooterCell()
        {
        }

        public TableViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public TableViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        public TableViewObservableSectionHeaderFooterCell(NSString reuseIdentifier)
            : base(reuseIdentifier)
        {
        }

        protected TableViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal TableViewObservableSectionHeaderFooterCell(IntPtr handle)
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
