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
using System.Diagnostics.CodeAnalysis;
using CoreGraphics;
using FlexiMvvm.Formatters;
using FlexiMvvm.Views;
using Foundation;
using UIKit;

namespace FlexiMvvm.Collections
{
    public class CollectionViewObservableItemCell : UICollectionViewCell
    {
        public CollectionViewObservableItemCell()
        {
        }

        public CollectionViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public CollectionViewObservableItemCell(CGRect frame)
            : base(frame)
        {
        }

        protected CollectionViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewObservableItemCell(IntPtr handle)
            : base(handle)
        {
        }

        internal static string ReuseIdentifier { get; } = nameof(CollectionViewObservableItemCell);

        protected ICellsSharedReadOnlyData? CellsSharedData { get; private set; }

        public virtual UIView View { get; set; }

        internal void Initialize(ICellsSharedReadOnlyData cellsSharedData)
        {
            CellsSharedData = cellsSharedData;

            LoadView();

            if (View != null && View.Superview == null)
            {
                ContentView.AddSubview(View);

                View.TranslatesAutoresizingMaskIntoConstraints = false;

                View.LeadingAnchor.ConstraintEqualTo(ContentView.LeadingAnchor).SetActive(true);
                View.TopAnchor.ConstraintEqualTo(ContentView.TopAnchor).SetActive(true);
                View.TrailingAnchor.ConstraintEqualTo(ContentView.TrailingAnchor).SetActive(true);
                View.BottomAnchor.ConstraintEqualTo(ContentView.BottomAnchor).SetActive(true);
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

        internal virtual void Bind(object? itemsContext, object? item)
        {
        }
    }

    public class CollectionViewObservableItemCell<TItemsContext, TItem> : CollectionViewObservableItemCell
    {
        public CollectionViewObservableItemCell()
        {
        }

        public CollectionViewObservableItemCell(NSCoder coder)
            : base(coder)
        {
        }

        public CollectionViewObservableItemCell(CGRect frame)
            : base(frame)
        {
        }

        protected CollectionViewObservableItemCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewObservableItemCell(IntPtr handle)
            : base(handle)
        {
        }

        [AllowNull]
        public TItemsContext ItemsContext { get; private set; }

        [AllowNull]
        public TItem Item { get; private set; }

        internal override void Bind(object? itemsContext, object? item)
        {
            base.Bind(itemsContext, item);

            try
            {
                ItemsContext = (TItemsContext)itemsContext;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(
                    $"Unable to cast the items context to the target type '{TypeFormatter.FormatName<TItemsContext>()}' " +
                    $"due to the items context is 'null' but the target type is not nullable.",
                    ex);
            }
            catch (InvalidCastException ex)
            {
                if (itemsContext != null)
                {
                    throw new InvalidCastException(
                        $"Unable to cast the items context of type '{TypeFormatter.FormatName(itemsContext.GetType())}' " +
                        $"to the target type '{TypeFormatter.FormatName<TItemsContext>()}'.",
                        ex);
                }

                throw;
            }

            try
            {
                Item = (TItem)item;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(
                    $"Unable to cast the item to the target type '{TypeFormatter.FormatName<TItem>()}' " +
                    $"due to the item is 'null' but the target type is not nullable.",
                    ex);
            }
            catch (InvalidCastException ex)
            {
                if (item != null)
                {
                    throw new InvalidCastException(
                        $"Unable to cast the item of type '{TypeFormatter.FormatName(item.GetType())}' " +
                        $"to the target type '{TypeFormatter.FormatName<TItem>()}'.",
                        ex);
                }

                throw;
            }

            Bind(ItemsContext);
            Bind(Item);
        }

        public virtual void Bind([AllowNull] TItemsContext itemsContext)
        {
        }

        public virtual void Bind([AllowNull] TItem item)
        {
        }
    }
}
