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
    public class TableViewObservableItemCell : UITableViewCell
    {
        public TableViewObservableItemCell()
        {
            Initialize();
        }

        public TableViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
            Initialize();
        }

        public TableViewObservableItemCell(CGRect frame)
            : base(frame)
        {
            Initialize();
        }

        public TableViewObservableItemCell(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        public TableViewObservableItemCell(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
            Initialize();
        }

        protected TableViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
            Initialize();
        }

        protected internal TableViewObservableItemCell(IntPtr handle)
            : base(handle)
        {
            Initialize();
        }

        public virtual UIView View { get; set; }

        private void Initialize()
        {
            LoadView();

            if (View != null && View.Superview == null)
            {
                ContentView.AddSubview(View);
                View.TranslatesAutoresizingMaskIntoConstraints = false;
                NSLayoutConstraint.ActivateConstraints(new[]
                {
                    View.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor),
                    View.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor),
                    View.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor),
                    View.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor)
                });
            }

            ViewDidLoad();
        }

        public virtual void LoadView()
        {
            View = new UIView();
        }

        public virtual void ViewDidLoad()
        {
        }

        internal virtual void Bind([CanBeNull] object itemsContext, [CanBeNull] object item)
        {
        }
    }

    public class TableViewObservableItemCell<TItemsContext, TItem> : TableViewObservableItemCell
    {
        public TableViewObservableItemCell()
        {
        }

        public TableViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public TableViewObservableItemCell(CGRect frame)
            : base(frame)
        {
        }

        public TableViewObservableItemCell(UITableViewCellStyle style, string reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        public TableViewObservableItemCell(UITableViewCellStyle style, NSString reuseIdentifier)
            : base(style, reuseIdentifier)
        {
        }

        protected TableViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal TableViewObservableItemCell(IntPtr handle)
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
