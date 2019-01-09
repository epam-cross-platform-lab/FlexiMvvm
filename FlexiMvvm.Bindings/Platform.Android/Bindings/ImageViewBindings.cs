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
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ImageViewBindings
    {
        /// <summary>
        /// One way binding on <see cref="ImageView.BaselineAlignBottom"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.BaselineAlignBottom"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, bool> BaselineAlignBottomBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, bool>(
                imageViewReference,
                (imageView, baselineAlignBottom) => imageView.NotNull().BaselineAlignBottom = baselineAlignBottom,
                () => "BaselineAlignBottom");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.CropToPadding"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.CropToPadding"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, bool> CropToPaddingBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, bool>(
                imageViewReference,
                (imageView, cropToPadding) => imageView.NotNull().CropToPadding = cropToPadding,
                () => "CropToPadding");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.ImageAlpha"/> property.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.ImageAlpha"/> property.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> ImageAlphaBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, imageAlpha) => imageView.NotNull().ImageAlpha = imageAlpha,
                () => "ImageAlpha");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetAdjustViewBounds(bool)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetAdjustViewBounds(bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, bool> SetAdjustViewBoundsBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, bool>(
                imageViewReference,
                (imageView, adjustViewBounds) => imageView.NotNull().SetAdjustViewBounds(adjustViewBounds),
                () => "SetAdjustViewBounds");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetBaseline(int)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetBaseline(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> SetBaselineBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, baseline) => imageView.NotNull().SetBaseline(baseline),
                () => "SetBaseline");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetImageBitmap(Bitmap)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetImageBitmap(Bitmap)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, Bitmap> SetImageBitmapBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, Bitmap>(
                imageViewReference,
                (imageView, bitmap) => imageView.NotNull().SetImageBitmap(bitmap),
                () => "SetImageBitmap");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetImageDrawable(Drawable)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetImageDrawable(Drawable)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, Drawable> SetImageDrawableBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, Drawable>(
                imageViewReference,
                (imageView, drawable) => imageView.NotNull().SetImageDrawable(drawable),
                () => "SetImageDrawable");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetImageLevel(int)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetImageLevel(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> SetImageLevelBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, level) => imageView.NotNull().SetImageLevel(level),
                () => "SetImageLevel");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetImageResource(int)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetImageResource(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resId) => imageView.NotNull().SetImageResource(resId),
                () => "SetImageResource");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetMaxHeight(int)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetMaxHeight(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> SetMaxHeightBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, maxHeight) => imageView.NotNull().SetMaxHeight(maxHeight),
                () => "SetMaxHeight");
        }

        /// <summary>
        /// One way binding on <see cref="ImageView.SetMaxWidth(int)"/> method.
        /// </summary>
        /// <param name="imageViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageView.SetMaxWidth(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageView, int> SetMaxWidthBinding(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, maxWidth) => imageView.NotNull().SetMaxWidth(maxWidth),
                () => "SetMaxWidth");
        }
    }
}
