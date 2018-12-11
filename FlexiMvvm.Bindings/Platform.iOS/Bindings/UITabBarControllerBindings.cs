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
    public static class UITabBarControllerBindings
    {
        /// <summary>
        /// Binding on <see cref="UITabBarController.SelectedIndex"/> property.
        /// </summary>
        /// <param name="tabBarControllerReference">The item reference.</param>
        /// <returns>Binding on <see cref="UITabBarController.SelectedIndex"/> property.</returns>
        /// <exception cref="ArgumentNullException">tabBarControllerReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITabBarController, nint> SelectedIndexBinding(
            [NotNull] this IItemReference<UITabBarController> tabBarControllerReference)
        {
            if (tabBarControllerReference == null)
                throw new ArgumentNullException(nameof(tabBarControllerReference));

            return new TargetItemOneWayCustomBinding<UITabBarController, nint>(
                tabBarControllerReference,
                (tabBarController, selectedIndex) => tabBarController.NotNull().SelectedIndex = selectedIndex,
                () => "SelectedIndex");
        }
    }
}
