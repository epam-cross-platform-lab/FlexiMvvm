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
    public static class UIButtonExtensions
    {
        public static TargetItemBinding<UIButton, bool> ReverseTitleShadowWhenHighlightedBinding(
            this IItemReference<UIButton> buttonReference)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, bool>(
                buttonReference,
                (button, reverseTitleShadowWhenHighlighted) => button.ReverseTitleShadowWhenHighlighted = reverseTitleShadowWhenHighlighted,
                () => $"{nameof(UIButton.ReverseTitleShadowWhenHighlighted)}");
        }

        public static TargetItemBinding<UIButton, UIImage> SetImageBinding(
            this IItemReference<UIButton> buttonReference,
            UIControlState forState = UIControlState.Normal)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, UIImage>(
                buttonReference,
                (button, image) => button.SetImage(image, forState),
                () => $"{nameof(UIButton.SetImage)}");
        }

        public static TargetItemBinding<UIButton, string> SetTitleBinding(
            this IItemReference<UIButton> buttonReference,
            UIControlState forState = UIControlState.Normal)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, string>(
                buttonReference,
                (button, title) => button.SetTitle(title, forState),
                () => $"{nameof(UIButton.SetTitle)}");
        }

        public static TargetItemBinding<UIButton, bool> ShowsTouchWhenHighlightedBinding(
            this IItemReference<UIButton> buttonReference)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, bool>(
                buttonReference,
                (button, showsTouchWhenHighlighted) => button.ShowsTouchWhenHighlighted = showsTouchWhenHighlighted,
                () => $"{nameof(UIButton.ShowsTouchWhenHighlighted)}");
        }
    }
}
