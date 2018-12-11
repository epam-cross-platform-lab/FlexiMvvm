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
    public static class UIButtonBindings
    {
        /// <summary>
        /// Binding on <see cref="UIButton.SetTitle"/> method.
        /// </summary>
        /// <param name="buttonReference">The item reference.</param>
        /// <param name="forState">Second parameter for <see cref="UIButton.SetTitle"/> method.</param>
        /// <returns>Binding on <see cref="UIButton.SetTitle"/> method.</returns>
        /// <exception cref="ArgumentNullException">buttonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIButton, string> SetTitleBinding(
            [NotNull] this IItemReference<UIButton> buttonReference,
            UIControlState forState = UIControlState.Normal)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, string>(
                buttonReference,
                (button, title) => button.NotNull().SetTitle(title, forState),
                () => "SetTitle");
        }

        /// <summary>
        /// Binding on <see cref="UIButton.ReverseTitleShadowWhenHighlighted"/> property.
        /// </summary>
        /// <param name="buttonReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIButton.ReverseTitleShadowWhenHighlighted"/> property.</returns>
        /// <exception cref="ArgumentNullException">buttonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIButton, bool> ReverseTitleShadowWhenHighlightedBinding(
            [NotNull] this IItemReference<UIButton> buttonReference)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, bool>(
                buttonReference,
                (button, reverseTitleShadowWhenHighlighted) => button.NotNull().ReverseTitleShadowWhenHighlighted = reverseTitleShadowWhenHighlighted,
                () => "ReverseTitleShadowWhenHighlighted");
        }

        /// <summary>
        /// Binding on <see cref="UIButton.ShowsTouchWhenHighlighted"/> property.
        /// </summary>
        /// <param name="buttonReference">The item reference.</param>
        /// <returns>Binding on <see cref="UIButton.ShowsTouchWhenHighlighted"/> property.</returns>
        /// <exception cref="ArgumentNullException">buttonReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UIButton, bool> ShowsTouchWhenHighlightedBinding(
            [NotNull] this IItemReference<UIButton> buttonReference)
        {
            if (buttonReference == null)
                throw new ArgumentNullException(nameof(buttonReference));

            return new TargetItemOneWayCustomBinding<UIButton, bool>(
                buttonReference,
                (button, showsTouchWhenHighlighted) => button.NotNull().ShowsTouchWhenHighlighted = showsTouchWhenHighlighted,
                () => "ShowsTouchWhenHighlighted");
        }
    }
}
