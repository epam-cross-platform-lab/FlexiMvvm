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
        /// <summary>
        /// Binding on <see cref="UIImageView.AdjustsImageSizeForAccessibilityContentSizeCategory"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.AdjustsImageSizeForAccessibilityContentSizeCategory"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="UIImageView.AnimationDuration"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.AnimationDuration"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="UIImageView.AnimationRepeatCount"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.AnimationRepeatCount"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="UIImageView.Highlighted"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.Highlighted"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="UIImageView.StartAnimating"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.StartAnimating"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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

        /// <summary>
        /// Binding on <see cref="UIImageView.StopAnimating"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIImageView.StopAnimating"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
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
