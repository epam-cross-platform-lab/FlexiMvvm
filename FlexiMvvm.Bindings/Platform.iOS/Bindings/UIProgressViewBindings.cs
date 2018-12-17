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
    public static class UIProgressViewBindings
    {
        /// <summary>
        /// One way binding on <see cref="UIProgressView.Progress"/> property.
        /// </summary>
        /// <param name="progressViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UIProgressView.Progress"/> property.</returns>
        /// <exception cref="ArgumentNullException">progressViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIProgressView, float> ProgressBinding(
            [NotNull] this IItemReference<UIProgressView> progressViewReference)
        {
            if (progressViewReference == null)
                throw new ArgumentNullException(nameof(progressViewReference));

            return new TargetItemOneWayCustomBinding<UIProgressView, float>(
                progressViewReference,
                (progressView, progress) => progressView.NotNull().Progress = progress,
                () => "Progress");
        }

        /// <summary>
        /// One way binding on <see cref="UIProgressView.SetProgress"/> method.
        /// </summary>
        /// <param name="progressViewReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UIProgressView.SetProgress"/> method.</param>
        /// <returns>One way binding on <see cref="UIProgressView.SetProgress"/> method.</returns>
        /// <exception cref="ArgumentNullException">progressViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIProgressView, float> SetProgressBinding(
            [NotNull] this IItemReference<UIProgressView> progressViewReference,
            bool animated = true)
        {
            if (progressViewReference == null)
                throw new ArgumentNullException(nameof(progressViewReference));

            return new TargetItemOneWayCustomBinding<UIProgressView, float>(
                progressViewReference,
                (progressView, progress) => progressView.NotNull().SetProgress(progress, animated),
                () => "SetProgress");
        }
    }
}
