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
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIImageViewBindings
    {
        [NotNull]
        public static TargetItemBinding<UIImageView, bool> AdjustsImageSizeForAccessibilityContentSizeCategoryBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, bool>(
                imageViewReference,
                (imageView, adjustsImageSizeForAccessibilityContentSizeCategory) => imageView.NotNull().AdjustsImageSizeForAccessibilityContentSizeCategory = adjustsImageSizeForAccessibilityContentSizeCategory,
                () => "AdjustsImageSizeForAccessibilityContentSizeCategory");
        }

        [NotNull]
        public static TargetItemBinding<UIImageView, double> AnimationDurationBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, double>(
                imageViewReference,
                (imageView, animationDuration) => imageView.NotNull().AnimationDuration = animationDuration,
                () => "AnimationDuration");
        }

        [NotNull]
        public static TargetItemBinding<UIImageView, nint> AnimationRepeatCountBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, nint>(
                imageViewReference,
                (imageView, animationRepeatCount) => imageView.NotNull().AnimationRepeatCount = animationRepeatCount,
                () => "AnimationRepeatCount");
        }

        [NotNull]
        public static TargetItemBinding<UIImageView, bool> HighlightedBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, bool>(
                imageViewReference,
                (imageView, highlighted) => imageView.NotNull().Highlighted = highlighted,
                () => "Highlighted");
        }

        [NotNull]
        public static TargetItemBinding<UIImageView, bool> StartAnimatingBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, bool>(
                imageViewReference,
                (imageView, animating) =>
                {
                    if (animating && !imageView.NotNull().IsAnimating)
                    {
                        imageView.StartAnimating();
                    }
                },
                () => "StartAnimating");
        }

        [NotNull]
        public static TargetItemBinding<UIImageView, bool> StopAnimatingBinding(
            [NotNull] this IItemReference<UIImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<UIImageView, bool>(
                imageViewReference,
                (imageView, animating) =>
                {
                    if (!animating && imageView.NotNull().IsAnimating)
                    {
                        imageView.StopAnimating();
                    }
                },
                () => "StopAnimating");
        }
    }
}
