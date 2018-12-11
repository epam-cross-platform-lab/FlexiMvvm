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
    public static class UIActivityIndicatorViewBindings
    {
        /// <summary>
        /// Binding on <see cref="UIActivityIndicatorView.HidesWhenStopped"/> property.
        /// </summary>
        /// <param name="activityIndicatorViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIActivityIndicatorView.HidesWhenStopped"/> property.</returns>
        /// <exception cref="ArgumentNullException">activityIndicatorViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIActivityIndicatorView, bool> HidesWhenStoppedBinding(
            [NotNull] this IItemReference<UIActivityIndicatorView> activityIndicatorViewReference)
        {
            if (activityIndicatorViewReference == null)
                throw new ArgumentNullException(nameof(activityIndicatorViewReference));

            return new TargetItemOneWayCustomBinding<UIActivityIndicatorView, bool>(
                activityIndicatorViewReference,
                (activityIndicatorView, hidesWhenStopped) => activityIndicatorView.NotNull().HidesWhenStopped = hidesWhenStopped,
                () => "HidesWhenStopped");
        }

        /// <summary>
        /// Binding on <see cref="UIActivityIndicatorView.StartAnimating"/> method.
        /// </summary>
        /// <param name="activityIndicatorViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIActivityIndicatorView.StartAnimating"/> method.</returns>
        /// <exception cref="ArgumentNullException">activityIndicatorViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIActivityIndicatorView, bool> StartAnimatingBinding(
            [NotNull] this IItemReference<UIActivityIndicatorView> activityIndicatorViewReference)
        {
            if (activityIndicatorViewReference == null)
                throw new ArgumentNullException(nameof(activityIndicatorViewReference));

            return new TargetItemOneWayCustomBinding<UIActivityIndicatorView, bool>(
                activityIndicatorViewReference,
                (activityIndicatorView, animating) =>
                {
                    if (animating && !activityIndicatorView.NotNull().IsAnimating)
                    {
                        activityIndicatorView.StartAnimating();
                    }
                },
                () => "StartAnimating");
        }

        /// <summary>
        /// Binding on <see cref="UIActivityIndicatorView.StopAnimating"/> method.
        /// </summary>
        /// <param name="activityIndicatorViewReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIActivityIndicatorView.StopAnimating"/> method.</returns>
        /// <exception cref="ArgumentNullException">activityIndicatorViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIActivityIndicatorView, bool> StopAnimatingBinding(
            [NotNull] this IItemReference<UIActivityIndicatorView> activityIndicatorViewReference)
        {
            if (activityIndicatorViewReference == null)
                throw new ArgumentNullException(nameof(activityIndicatorViewReference));

            return new TargetItemOneWayCustomBinding<UIActivityIndicatorView, bool>(
                activityIndicatorViewReference,
                (activityIndicatorView, animating) =>
                {
                    if (!animating && activityIndicatorView.NotNull().IsAnimating)
                    {
                        activityIndicatorView.StopAnimating();
                    }
                },
                () => "StopAnimating");
        }
    }
}
