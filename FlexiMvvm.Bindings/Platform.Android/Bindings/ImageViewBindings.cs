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

        [NotNull]
        public static TargetItemBinding<ImageView, TValue> SetColorFilterBinding<TValue>(
            [NotNull] this IItemReference<ImageView> imageViewReference)
        {
            if (imageViewReference == null)
                throw new ArgumentNullException(nameof(imageViewReference));

            return new TargetItemOneWayCustomBinding<ImageView, TValue>(
                imageViewReference,
                (imageView, value) =>
                {
                    switch (value)
                    {
                        case Color color:
                            imageView.NotNull().SetColorFilter(color);
                            break;
                        case ColorFilter colorFilter:
                            imageView.NotNull().SetColorFilter(colorFilter);
                            break;
                        default:
                            throw new NotSupportedException($"{nameof(SetColorFilterBinding)} doesn't support type {typeof(TValue)}");
                    }
                },
                () => "SetColorFilter");
        }

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
        /// Binding that sets an image drawable for <see cref="ImageView"/>.
        /// </summary>
        /// <param name="imageViewReference">The image view reference.</param>
        /// <returns>Binding</returns>
        /// <exception cref="ArgumentNullException">imageViewReference</exception>
        /// <example>
        /// This sample shows how to call the <see cref="SetImageDrawableBinding"/> method.
        /// <code>
        /// .For(v => v.SetImageDrawableBinding())
        /// </code>
        /// </example>
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
