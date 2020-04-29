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
using FlexiMvvm.Bindings.Custom;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIProgressViewExtensions
    {
        public static TargetItemBinding<UIProgressView, float> ProgressBinding(
            this IItemReference<UIProgressView> progressViewReference)
        {
            if (progressViewReference == null)
                throw new ArgumentNullException(nameof(progressViewReference));

            return new TargetItemOneWayCustomBinding<UIProgressView, float>(
                progressViewReference,
                (progressView, progress) => progressView.Progress = progress,
                () => $"{nameof(UIProgressView.Progress)}");
        }

        public static TargetItemBinding<UIProgressView, float> SetProgressBinding(
            this IItemReference<UIProgressView> progressViewReference,
            bool animated = true)
        {
            if (progressViewReference == null)
                throw new ArgumentNullException(nameof(progressViewReference));

            return new TargetItemOneWayCustomBinding<UIProgressView, float>(
                progressViewReference,
                (progressView, progress) => progressView.SetProgress(progress, animated),
                () => $"{nameof(UIProgressView.SetProgress)}");
        }
    }
}
