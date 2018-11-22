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
using Android.Support.V7.Widget;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class AppCompatAutoCompleteTextViewBindings
    {
        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, object> DismissBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            return new TargetItemOneWayToSourceCustomBinding<AppCompatAutoCompleteTextView, object>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().Dismiss += eventHandler,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().Dismiss -= eventHandler,
                (appCompatAutoCompleteTextView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        appCompatAutoCompleteTextView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                appCompatAutoCompleteTextView => null,
                () => "Dismiss");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> DropDownAnchorBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, dropDownAnchor) => appCompatAutoCompleteTextView.NotNull().DropDownAnchor = dropDownAnchor,
                () => "DropDownAnchor");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> DropDownHeightBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, dropDownHeight) => appCompatAutoCompleteTextView.NotNull().DropDownHeight = dropDownHeight,
                () => "DropDownHeight");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> DropDownHorizontalOffsetBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, dropDownHorizontalOffset) => appCompatAutoCompleteTextView.NotNull().DropDownHorizontalOffset = dropDownHorizontalOffset,
                () => "DropDownHorizontalOffset");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> DropDownVerticalOffsetBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, dropDownVerticalOffset) => appCompatAutoCompleteTextView.NotNull().DropDownVerticalOffset = dropDownVerticalOffset,
                () => "DropDownVerticalOffset");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> DropDownWidthBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, dropDownWidth) => appCompatAutoCompleteTextView.NotNull().DropDownWidth = dropDownWidth,
                () => "DropDownWidth");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> ItemClickBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayToSourceCustomBinding<AppCompatAutoCompleteTextView, int, AdapterView.ItemClickEventArgs>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().ItemClick += eventHandler,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().ItemClick -= eventHandler,
                (appCompatAutoCompleteTextView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        appCompatAutoCompleteTextView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (appCompatAutoCompleteTextView, args) => args.Position,
                () => "ItemClick");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> ItemSelectedBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayToSourceCustomBinding<AppCompatAutoCompleteTextView, int, AdapterView.ItemSelectedEventArgs>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().ItemSelected += eventHandler,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().ItemSelected -= eventHandler,
                (appCompatAutoCompleteTextView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        appCompatAutoCompleteTextView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (appCompatAutoCompleteTextView, args) => args.Position,
                () => "ItemSelected");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, object> NothingSelectedBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayToSourceCustomBinding<AppCompatAutoCompleteTextView, object, AdapterView.NothingSelectedEventArgs>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().NothingSelected += eventHandler,
                (appCompatAutoCompleteTextView, eventHandler) => appCompatAutoCompleteTextView.NotNull().NothingSelected -= eventHandler,
                (appCompatAutoCompleteTextView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        appCompatAutoCompleteTextView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (appCompatAutoCompleteTextView, args) => null,
                () => "NothingSelected");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> ListSelectionBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, listSelection) => appCompatAutoCompleteTextView.NotNull().ListSelection = listSelection,
                () => "ListSelection");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, string> SetCompletionHintBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, string>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, hint) => appCompatAutoCompleteTextView.NotNull().SetCompletionHint(hint),
                () => "SetCompletionHint");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> SetDropDownBackgroundResourceBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, id) => appCompatAutoCompleteTextView.NotNull().SetDropDownBackgroundResource(id),
                () => "SetDropDownBackgroundResource");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, string> SetTextBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool filter = true)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, string>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, text) => appCompatAutoCompleteTextView.NotNull().SetText(text, true),
                () => "SetText");
        }

        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, int> ThresholdBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, int>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, threshold) => appCompatAutoCompleteTextView.NotNull().Threshold = threshold,
                () => "Threshold");
        }
    }
}
