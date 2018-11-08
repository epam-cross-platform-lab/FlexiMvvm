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
    public class UITableViewObservableItemCell : UITableViewCell
    {
        public UITableViewObservableItemCell()
        {
            Initialize();
        }

        public UITableViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public UITableViewObservableItemCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public UITableViewObservableItemCell(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        public UITableViewObservableItemCell(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        protected UITableViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal UITableViewObservableItemCell(IntPtr handle)
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

    public class UITableViewObservableItemCell<TItemsContext, TItem> : UITableViewObservableItemCell
    {
        public UITableViewObservableItemCell()
        {
        }

        public UITableViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public UITableViewObservableItemCell(CGRect frame)
            : base(frame)
        {
        }

        public UITableViewObservableItemCell(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        public UITableViewObservableItemCell(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        protected UITableViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal UITableViewObservableItemCell(IntPtr handle)
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
