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
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using Java.Lang;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class SwitchBindings
    {
        /// <summary>
        /// One way binding on <see cref="Switch.SetSwitchTextAppearance"/> method.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <param name="context">The context.</param>
        /// <returns>One way binding on <see cref="Switch.SetSwitchTextAppearance"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> SetSwitchTextAppearanceBinding(
            [NotNull] this IItemReference<Switch> switchReference,
            [NotNull] Context context)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, resId) => @switch.NotNull().SetSwitchTextAppearance(context, resId),
                () => "SetSwitchTextAppearance");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SetSwitchTypeface(Typeface, TypefaceStyle)"/> method.
        /// </summary>
        /// <param name="switchReference">The switch reference.</param>
        /// <param name="typefaceStyle">The typeface style.</param>
        /// <returns>One way binding on <see cref="Switch.SetSwitchTypeface(Typeface, TypefaceStyle)"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, Typeface> SetSwitchTextAppearanceBinding(
            [NotNull] this IItemReference<Switch> switchReference,
            TypefaceStyle typefaceStyle = TypefaceStyle.Normal)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, Typeface>(
                switchReference,
                (@switch, typeface) => @switch.NotNull().SetSwitchTypeface(typeface, typefaceStyle),
                () => "SetSwitchTypeface");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SetThumbResource(int)"/> method.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <param name="typefaceStyle">The typeface style.</param>
        /// <returns>One way binding on <see cref="Switch.SetThumbResource(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> SetThumbResourceBinding(
            [NotNull] this IItemReference<Switch> switchReference,
            TypefaceStyle typefaceStyle = TypefaceStyle.Normal)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, resId) => @switch.NotNull().SetThumbResource(resId),
                () => "SetThumbResource");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SetTrackResource(int)"/> method.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <param name="typefaceStyle">The typeface style.</param>
        /// <returns>One way binding on <see cref="Switch.SetTrackResource(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> SetTrackResourceBinding(
            [NotNull] this IItemReference<Switch> switchReference,
            TypefaceStyle typefaceStyle = TypefaceStyle.Normal)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, resId) => @switch.NotNull().SetTrackResource(resId),
                () => "SetTrackResource");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.ShowText"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.ShowText"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, bool> ShowTextBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, bool>(
                switchReference,
                (@switch, showText) => @switch.NotNull().ShowText = showText,
                () => "ShowText");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SplitTrack"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.SplitTrack"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, bool> SplitTrackBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, bool>(
                switchReference,
                (@switch, splitTrack) => @switch.NotNull().SplitTrack = splitTrack,
                () => "SplitTrack");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SwitchMinWidth"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.SwitchMinWidth"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> SwitchMinWidthBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, switchMinWidth) => @switch.NotNull().SwitchMinWidth = switchMinWidth,
                () => "SwitchMinWidth");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.SwitchPadding"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.SwitchPadding"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> SwitchPaddingBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, switchPadding) => @switch.NotNull().SwitchPadding = switchPadding,
                () => "SwitchPadding");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.TextOff"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.TextOff"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, string> TextOffBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, string>(
                switchReference,
                (@switch, textOff) => @switch.NotNull().TextOff = textOff,
                () => "TextOff");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.TextOffFormatted"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.TextOffFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, ICharSequence> TextOffFormattedBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, ICharSequence>(
                switchReference,
                (@switch, textOffFormatted) => @switch.NotNull().TextOffFormatted = textOffFormatted,
                () => "TextOffFormatted");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.TextOn"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.TextOn"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, string> TextOnBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, string>(
                switchReference,
                (@switch, textOn) => @switch.NotNull().TextOn = textOn,
                () => "TextOn");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.TextOnFormatted"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.TextOnFormatted"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, ICharSequence> TextOnFormattedBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, ICharSequence>(
                switchReference,
                (@switch, textOnFormatted) => @switch.NotNull().TextOnFormatted = textOnFormatted,
                () => "TextOnFormatted");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.ThumbDrawable"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.ThumbDrawable"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, Drawable> ThumbDrawableBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, Drawable>(
                switchReference,
                (@switch, thumbDrawable) => @switch.NotNull().ThumbDrawable = thumbDrawable,
                () => "ThumbDrawable");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.ThumbTextPadding"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.ThumbTextPadding"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, int> ThumbTextPaddingBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, int>(
                switchReference,
                (@switch, thumbTextPadding) => @switch.NotNull().ThumbTextPadding = thumbTextPadding,
                () => "ThumbTextPadding");
        }

        /// <summary>
        /// One way binding on <see cref="Switch.TrackDrawable"/> property.
        /// </summary>
        /// <param name="switchReference">The item reference.</param>
        /// <returns>One way binding on <see cref="Switch.TrackDrawable"/> property.</returns>
        /// <exception cref="ArgumentNullException">switchReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<Switch, Drawable> TrackDrawableBinding(
            [NotNull] this IItemReference<Switch> switchReference)
        {
            if (switchReference == null)
                throw new ArgumentNullException(nameof(switchReference));

            return new TargetItemOneWayCustomBinding<Switch, Drawable>(
                switchReference,
                (@switch, trackDrawable) => @switch.NotNull().TrackDrawable = trackDrawable,
                () => "TrackDrawable");
        }
    }
}
