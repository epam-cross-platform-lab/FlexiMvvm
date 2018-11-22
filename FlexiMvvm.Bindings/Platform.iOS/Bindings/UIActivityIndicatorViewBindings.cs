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
