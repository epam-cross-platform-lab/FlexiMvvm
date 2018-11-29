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
