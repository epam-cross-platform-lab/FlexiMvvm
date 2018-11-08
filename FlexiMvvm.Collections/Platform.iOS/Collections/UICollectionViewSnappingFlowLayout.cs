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
