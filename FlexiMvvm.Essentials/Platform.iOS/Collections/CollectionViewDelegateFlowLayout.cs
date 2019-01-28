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
    public class CollectionViewDelegateFlowLayout : UICollectionViewDelegateFlowLayout
    {
        public CollectionViewDelegateFlowLayout()
        {
        }

        protected CollectionViewDelegateFlowLayout(NSObjectFlag t)
            : base(t)
        {
        }

        protected internal CollectionViewDelegateFlowLayout(IntPtr handle)
            : base(handle)
        {
        }

        public override UIEdgeInsets GetInsetForSection(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            nint section)
        {
            return ((UICollectionViewFlowLayout)layout).SectionInset;
        }

        public override nfloat GetMinimumInteritemSpacingForSection(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            nint section)
        {
            return ((UICollectionViewFlowLayout)layout).MinimumInteritemSpacing;
        }

        public override nfloat GetMinimumLineSpacingForSection(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            nint section)
        {
            return ((UICollectionViewFlowLayout)layout).MinimumLineSpacing;
        }

        public override CGSize GetReferenceSizeForFooter(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            nint section)
        {
            return ((UICollectionViewFlowLayout)layout).FooterReferenceSize;
        }

        public override CGSize GetReferenceSizeForHeader(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            nint section)
        {
            return ((UICollectionViewFlowLayout)layout).HeaderReferenceSize;
        }

        public override CGSize GetSizeForItem(
            [NotNull] UICollectionView collectionView,
            [NotNull] UICollectionViewLayout layout,
            [NotNull] NSIndexPath indexPath)
        {
            return ((UICollectionViewFlowLayout)layout).ItemSize;
        }

        public override void ItemSelected(
            [NotNull] UICollectionView collectionView,
            [NotNull] NSIndexPath indexPath)
        {
            if (collectionView.DataSource is IUICollectionViewDelegate collectionViewDelegate)
            {
                collectionViewDelegate.ItemSelected(collectionView, indexPath);
            }
        }

        public override void ItemDeselected(
            [NotNull] UICollectionView collectionView,
            [NotNull] NSIndexPath indexPath)
        {
            if (collectionView.DataSource is IUICollectionViewDelegate collectionViewDelegate)
            {
                collectionViewDelegate.ItemDeselected(collectionView, indexPath);
            }
        }
    }
}
