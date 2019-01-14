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
using UIKit;

namespace FlexiMvvm.Collections
{
    public class UICollectionViewSnappingFlowLayout : UICollectionViewFlowLayout
    {
        public override CGPoint TargetContentOffset(CGPoint proposedContentOffset, CGPoint scrollingVelocity)
        {
            if (CollectionView == null)
            {
                return base.TargetContentOffset(proposedContentOffset, scrollingVelocity);
            }

            var offsetAdjustment = nfloat.MaxValue;
            var horizontalOffset = proposedContentOffset.X + CollectionView.ContentInset.Left + SectionInset.Left;

            var targetRect = new CGRect(proposedContentOffset.X, 0, CollectionView.Bounds.Size.Width, CollectionView.Bounds.Size.Height);
            var layoutAttributesArray = LayoutAttributesForElementsInRect(targetRect);

            if (layoutAttributesArray != null)
            {
                foreach (var layoutAttributes in layoutAttributesArray)
                {
                    var itemOffset = layoutAttributes.Frame.X;

                    if (Math.Abs(itemOffset - horizontalOffset) < Math.Abs(offsetAdjustment))
                    {
                        offsetAdjustment = itemOffset - horizontalOffset;
                    }
                }
            }

            return new CGPoint(proposedContentOffset.X + offsetAdjustment, proposedContentOffset.Y);
        }
    }
}
