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
using Foundation;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UILabelExtensions
    {
        public static TargetItemBinding<UILabel, bool> AdjustsFontForContentSizeCategoryBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, adjustFontForContentSizeCategory) => label.AdjustsFontForContentSizeCategory = adjustFontForContentSizeCategory,
                () => $"{nameof(UILabel.AdjustsFontForContentSizeCategory)}");
        }

        public static TargetItemBinding<UILabel, bool> AdjustsFontSizeToFitWidthBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, adjustFontSizeToFitWidth) => label.AdjustsFontSizeToFitWidth = adjustFontSizeToFitWidth,
                () => $"{nameof(UILabel.AdjustsFontSizeToFitWidth)}");
        }

        public static TargetItemBinding<UILabel, bool> AdjustsLetterSpacingToFitWidthBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, adjustsLetterSpacingToFitWidth) => label.AdjustsLetterSpacingToFitWidth = adjustsLetterSpacingToFitWidth,
                () => $"{nameof(UILabel.AdjustsLetterSpacingToFitWidth)}");
        }

        public static TargetItemBinding<UILabel, bool> AllowsDefaultTighteningForTruncationBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, allowDefaultTighteningForTruncation) => label.AllowsDefaultTighteningForTruncation = allowDefaultTighteningForTruncation,
                () => $"{nameof(UILabel.AllowsDefaultTighteningForTruncation)}");
        }

        public static TargetItemBinding<UILabel, NSAttributedString> AttributedTextBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, NSAttributedString>(
                labelReference,
                (label, attributedText) => label.AttributedText = attributedText,
                () => $"{nameof(UILabel.AttributedText)}");
        }

        public static TargetItemBinding<UILabel, bool> EnabledBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, enabled) => label.Enabled = enabled,
                () => $"{nameof(UILabel.Enabled)}");
        }

        public static TargetItemBinding<UILabel, bool> HighlightedBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, bool>(
                labelReference,
                (label, highlighted) => label.Highlighted = highlighted,
                () => $"{nameof(UILabel.Highlighted)}");
        }

        public static TargetItemBinding<UILabel, nint> LinesBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, nint>(
                labelReference,
                (label, lines) => label.Lines = lines,
                () => $"{nameof(UILabel.Lines)}");
        }

        public static TargetItemBinding<UILabel, nfloat> MinimumFontSizeBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, nfloat>(
                labelReference,
                (label, minimumFontSize) => label.MinimumFontSize = minimumFontSize,
                () => $"{nameof(UILabel.MinimumFontSize)}");
        }

        public static TargetItemBinding<UILabel, nfloat> MinimumScaleFactorBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, nfloat>(
                labelReference,
                (label, minimumScaleFactor) => label.MinimumScaleFactor = minimumScaleFactor,
                () => $"{nameof(UILabel.MinimumScaleFactor)}");
        }

        public static TargetItemBinding<UILabel, nfloat> PreferredMaxLayoutWidthBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, nfloat>(
                labelReference,
                (label, preferredMaxLayoutWidth) => label.PreferredMaxLayoutWidth = preferredMaxLayoutWidth,
                () => $"{nameof(UILabel.PreferredMaxLayoutWidth)}");
        }

        public static TargetItemBinding<UILabel, string> TextBinding(
            this IItemReference<UILabel> labelReference)
        {
            if (labelReference == null)
                throw new ArgumentNullException(nameof(labelReference));

            return new TargetItemOneWayCustomBinding<UILabel, string>(
                labelReference,
                (label, text) => label.Text = text,
                () => $"{nameof(UILabel.Text)}");
        }
    }
}
