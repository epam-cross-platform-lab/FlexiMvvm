﻿// =========================================================================
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
