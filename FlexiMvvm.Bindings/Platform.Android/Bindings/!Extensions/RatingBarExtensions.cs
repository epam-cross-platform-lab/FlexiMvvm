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
using System.Windows.Input;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="RatingBar"/> members.
    /// </summary>
    public static class RatingBarExtensions
    {
        /// <summary>
        /// One way binding on <see cref="RatingBar.IsIndicator"/> property. Is indicator flag is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, bool> IsIndicatorBinding(
            this IItemReference<RatingBar> ratingBarReference)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemOneWayCustomBinding<RatingBar, bool>(
                ratingBarReference,
                (ratingBar, isIndicator) => ratingBar.IsIndicator = isIndicator,
                () => $"{nameof(RatingBar.IsIndicator)}");
        }

        /// <summary>
        /// One way binding on <see cref="RatingBar.NumStars"/> property. Number of stars is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, int> NumStarsBinding(
            this IItemReference<RatingBar> ratingBarReference)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemOneWayCustomBinding<RatingBar, int>(
                ratingBarReference,
                (ratingBar, numStars) => ratingBar.NumStars = numStars,
                () => $"{nameof(RatingBar.NumStars)}");
        }

        /// <summary>
        /// Two way binding on <see cref="RatingBar.Rating"/> property and <see cref="RatingBar.RatingBarChange"/> event. Rating is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="RatingBar.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, float> RatingAndRatingBarChangeBinding(
            this IItemReference<RatingBar> ratingBarReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemTwoWayCustomBinding<RatingBar, float, RatingBar.RatingBarChangeEventArgs>(
                ratingBarReference,
                (ratingBar, handler) => ratingBar.RatingBarChange += handler,
                (ratingBar, handler) => ratingBar.RatingBarChange -= handler,
                (ratingBar, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        ratingBar.Enabled = canExecuteCommand;
                    }
                },
                (ratingBar, args) => args?.Rating ?? ratingBar.Rating,
                (ratingBar, rating) => ratingBar.Rating = rating,
                () => $"{nameof(RatingBar.Rating)}And{nameof(RatingBar.RatingBarChange)}");
        }

        /// <summary>
        /// One way to source binding on <see cref="RatingBar.RatingBarChange"/> event. Rating is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="RatingBar.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, float> RatingBarChangeBinding(
            this IItemReference<RatingBar> ratingBarReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemOneWayToSourceCustomBinding<RatingBar, float, RatingBar.RatingBarChangeEventArgs>(
                ratingBarReference,
                (ratingBar, handler) => ratingBar.RatingBarChange += handler,
                (ratingBar, handler) => ratingBar.RatingBarChange -= handler,
                (ratingBar, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        ratingBar.Enabled = canExecuteCommand;
                    }
                },
                (ratingBar, args) => args.Rating,
                () => $"{nameof(RatingBar.RatingBarChange)}");
        }

        /// <summary>
        /// One way binding on <see cref="RatingBar.Rating"/> property. Rating is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, float> RatingBinding(
            this IItemReference<RatingBar> ratingBarReference)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemOneWayCustomBinding<RatingBar, float>(
                ratingBarReference,
                (ratingBar, rating) => ratingBar.Rating = rating,
                () => $"{nameof(RatingBar.Rating)}");
        }

        /// <summary>
        /// One way binding on <see cref="RatingBar.StepSize"/> property. Step size is passed as a value.
        /// </summary>
        /// <param name="ratingBarReference">The rating bar reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="ratingBarReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<RatingBar, float> StepSizeBinding(
            this IItemReference<RatingBar> ratingBarReference)
        {
            if (ratingBarReference == null)
                throw new ArgumentNullException(nameof(ratingBarReference));

            return new TargetItemOneWayCustomBinding<RatingBar, float>(
                ratingBarReference,
                (ratingBar, stepSize) => ratingBar.StepSize = stepSize,
                () => $"{nameof(RatingBar.StepSize)}");
        }
    }
}
