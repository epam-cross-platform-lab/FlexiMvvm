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
    public class CollectionViewObservableSectionHeaderFooterCell : UICollectionReusableView
    {
        public CollectionViewObservableSectionHeaderFooterCell()
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        protected CollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
            : base(handle)
        {
        }

        internal static string ReuseIdentifier { get; } = nameof(CollectionViewObservableSectionHeaderFooterCell);

        protected ICellsSharedReadOnlyData? CellsSharedData { get; private set; }

        public virtual UIView View { get; set; }

        internal void Initialize(ICellsSharedReadOnlyData cellsSharedData)
        {
            CellsSharedData = cellsSharedData;

            LoadView();

            if (View != null && View.Superview == null)
            {
                AddSubview(View);

                View.TranslatesAutoresizingMaskIntoConstraints = false;

                View.LeadingAnchor.ConstraintEqualTo(LeadingAnchor).SetActive(true);
                View.TopAnchor.ConstraintEqualTo(TopAnchor).SetActive(true);
                View.TrailingAnchor.ConstraintEqualTo(TrailingAnchor).SetActive(true);
                View.BottomAnchor.ConstraintEqualTo(BottomAnchor).SetActive(true);
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

        internal virtual void Bind(object? itemsContext, object? group)
        {
        }
    }

    public class CollectionViewObservableSectionHeaderFooterCell<TItemsContext> : CollectionViewObservableSectionHeaderFooterCell
    {
        public CollectionViewObservableSectionHeaderFooterCell()
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        protected CollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
            : base(handle)
        {
        }

        [AllowNull]
        public TItemsContext ItemsContext { get; private set; }

        internal override void Bind(object? itemsContext, object? group)
        {
            base.Bind(itemsContext, group);

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

            Bind(ItemsContext);
        }

        public virtual void Bind([AllowNull] TItemsContext itemsContext)
        {
        }
    }

    public class CollectionViewObservableSectionHeaderFooterCell<TItemsContext, TGroup> : CollectionViewObservableSectionHeaderFooterCell<TItemsContext>
    {
        public CollectionViewObservableSectionHeaderFooterCell()
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(NSCoder coder)
            : base(coder)
        {
        }

        public CollectionViewObservableSectionHeaderFooterCell(CGRect frame)
            : base(frame)
        {
        }

        protected CollectionViewObservableSectionHeaderFooterCell(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewObservableSectionHeaderFooterCell(IntPtr handle)
            : base(handle)
        {
        }

        [AllowNull]
        public TGroup Group { get; private set; }

        internal override void Bind(object? itemsContext, object? group)
        {
            base.Bind(itemsContext, group);

            try
            {
                Group = (TGroup)group;
            }
            catch (NullReferenceException ex)
            {
                throw new NullReferenceException(
                    $"Unable to cast the group to the target type '{TypeFormatter.FormatName<TGroup>()}' " +
                    $"due to the group is 'null' but the target type is not nullable.",
                    ex);
            }
            catch (InvalidCastException ex)
            {
                if (group != null)
                {
                    throw new InvalidCastException(
                        $"Unable to cast the group of type '{TypeFormatter.FormatName(group.GetType())}' " +
                        $"to the target type '{TypeFormatter.FormatName<TGroup>()}'.",
                        ex);
                }

                throw;
            }

            Bind(Group);
        }

        public virtual void Bind([AllowNull] TGroup group)
        {
        }
    }
}
