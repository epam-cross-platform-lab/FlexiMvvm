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
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIViewControllerBindings
    {
        [NotNull]
        public static TargetItemBinding<UIViewController, string> TitleBinding(
            [NotNull] this IItemReference<UIViewController> viewControllerReference)
        {
            if (viewControllerReference == null)
                throw new ArgumentNullException(nameof(viewControllerReference));

            return new TargetItemOneWayCustomBinding<UIViewController, string>(
                viewControllerReference,
                (viewController, title) => viewController.NotNull().Title = title,
                () => "Title");
        }
    }
}
