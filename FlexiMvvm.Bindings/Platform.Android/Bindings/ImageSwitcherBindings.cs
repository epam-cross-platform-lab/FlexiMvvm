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
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class ImageSwitcherBindings
    {
        /// <summary>
        /// One way binding on <see cref="ImageSwitcher.SetImageDrawable(Drawable)"/> method.
        /// </summary>
        /// <param name="imageSwitcherReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageSwitcher.SetImageDrawable(Drawable)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageSwitcherReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageSwitcher, Drawable> SetImageDrawableBinding(
            [NotNull] this IItemReference<ImageSwitcher> imageSwitcherReference)
        {
            if (imageSwitcherReference == null)
                throw new ArgumentNullException(nameof(imageSwitcherReference));

            return new TargetItemOneWayCustomBinding<ImageSwitcher, Drawable>(
                imageSwitcherReference,
                (@switch, drawable) => @switch.NotNull().SetImageDrawable(drawable),
                () => "SetImageDrawable");
        }

        /// <summary>
        /// One way binding on <see cref="ImageSwitcher.SetImageResource(int)"/> method.
        /// </summary>
        /// <param name="imageSwitcherReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageSwitcher.SetImageResource(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageSwitcherReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageSwitcher, int> SetImageResourceBinding(
            [NotNull] this IItemReference<ImageSwitcher> imageSwitcherReference)
        {
            if (imageSwitcherReference == null)
                throw new ArgumentNullException(nameof(imageSwitcherReference));

            return new TargetItemOneWayCustomBinding<ImageSwitcher, int>(
                imageSwitcherReference,
                (@switch, resId) => @switch.NotNull().SetImageResource(resId),
                () => "SetImageResource");
        }

        /// <summary>
        /// One way binding on <see cref="ImageSwitcher.SetImageURI(Android.Net.Uri)"/> method.
        /// </summary>
        /// <param name="imageSwitcherReference">The item reference.</param>
        /// <returns>One way binding on <see cref="ImageSwitcher.SetImageURI(Android.Net.Uri)"/> method.</returns>
        /// <exception cref="ArgumentNullException">imageSwitcherReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<ImageSwitcher, Android.Net.Uri> SetImageURIBinding(
            [NotNull] this IItemReference<ImageSwitcher> imageSwitcherReference)
        {
            if (imageSwitcherReference == null)
                throw new ArgumentNullException(nameof(imageSwitcherReference));

            return new TargetItemOneWayCustomBinding<ImageSwitcher, Android.Net.Uri>(
                imageSwitcherReference,
                (@switch, uri) => @switch.NotNull().SetImageURI(uri),
                () => "SetImageURI");
        }
    }
}
