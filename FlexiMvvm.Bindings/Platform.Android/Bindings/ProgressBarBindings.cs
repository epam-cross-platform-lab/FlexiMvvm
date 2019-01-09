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
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ProgressBarBindings
    {
        /// <summary>
        /// One way binding on <see cref="ProgressBar.IncrementProgressBy(int)"/> method.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.IncrementProgressBy(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, int> IncrementProgressByBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, int>(
                progressBarReference,
                (progressBar, diff) => progressBar.NotNull().IncrementProgressBy(diff),
                () => "IncrementProgressBy");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.IncrementSecondaryProgressBy(int)"/> method.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.IncrementSecondaryProgressBy(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, int> IncrementSecondaryProgressByBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, int>(
                progressBarReference,
                (progressBar, diff) => progressBar.NotNull().IncrementSecondaryProgressBy(diff),
                () => "IncrementSecondaryProgressBy");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.Indeterminate"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.Indeterminate"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, bool> IndeterminateBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, bool>(
                progressBarReference,
                (progressBar, indeterminate) => progressBar.NotNull().Indeterminate = indeterminate,
                () => "Indeterminate");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.IndeterminateDrawable"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.IndeterminateDrawable"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, Drawable> IndeterminateDrawableBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, Drawable>(
                progressBarReference,
                (progressBar, indeterminateDrawable) => progressBar.NotNull().IndeterminateDrawable = indeterminateDrawable,
                () => "IndeterminateDrawable");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.Max"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.Max"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, int> MaxBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, int>(
                progressBarReference,
                (progressBar, max) => progressBar.NotNull().Max = max,
                () => "Max");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.Progress"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.Progress"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, int> ProgressBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, int>(
                progressBarReference,
                (progressBar, progress) => progressBar.NotNull().Progress = progress,
                () => "Progress");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.ProgressDrawable"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.ProgressDrawable"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, Drawable> ProgressDrawableBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, Drawable>(
                progressBarReference,
                (progressBar, progressDrawable) => progressBar.NotNull().ProgressDrawable = progressDrawable,
                () => "ProgressDrawable");
        }

        /// <summary>
        /// One way binding on <see cref="ProgressBar.SecondaryProgress"/> property.
        /// </summary>
        /// <param name="progressBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ProgressBar.SecondaryProgress"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ProgressBar, int> SecondaryProgressBinding(
            [NotNull] this IItemReference<ProgressBar> progressBarReference)
        {
            if (progressBarReference == null)
                throw new ArgumentNullException(nameof(progressBarReference));

            return new TargetItemOneWayCustomBinding<ProgressBar, int>(
                progressBarReference,
                (progressBar, secondaryProgress) => progressBar.NotNull().SecondaryProgress = secondaryProgress,
                () => "SecondaryProgress");
        }
    }
}
