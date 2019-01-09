﻿// =========================================================================
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
using System.Windows.Input;
using Android.Support.V7.Widget;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class AppCompatAutoCompleteTextViewBindings
    {
        /// <summary>
        /// One way to source binding on <see cref="AppCompatAutoCompleteTextView.Dismiss"/> event.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AppCompatAutoCompleteTextView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>One way to source binding on <see cref="AppCompatAutoCompleteTextView.Dismiss"/> event.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, object> DismissBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownAnchor"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownAnchor"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownHeight"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownHeight"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownHorizontalOffset"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownHorizontalOffset"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownVerticalOffset"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownVerticalOffset"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownWidth"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.DropDownWidth"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way to source binding on <see cref="AppCompatAutoCompleteTextView.ItemClick"/> event.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AppCompatAutoCompleteTextView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>One way to source binding on <see cref="AppCompatAutoCompleteTextView.ItemClick"/> event.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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
                (appCompatAutoCompleteTextView, eventArgs) => eventArgs.NotNull().Position,
                () => "ItemClick");
        }

        /// <summary>
        /// One way to source binding on <see cref="AppCompatAutoCompleteTextView.ItemSelected"/> event.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AppCompatAutoCompleteTextView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>One way to source binding on <see cref="AppCompatAutoCompleteTextView.ItemSelected"/> event.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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
                (appCompatAutoCompleteTextView, eventArgs) => eventArgs.NotNull().Position,
                () => "ItemSelected");
        }

        /// <summary>
        /// One way to source binding on <see cref="AppCompatAutoCompleteTextView.NothingSelected"/> event.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <param name="trackCanExecuteCommandChanged">If set to <c>true</c> then <see cref="AppCompatAutoCompleteTextView.Enabled"/> value will be updated based on <see cref="ICommand.CanExecute(object)"/> result.</param>
        /// <returns>One way to source binding on <see cref="AppCompatAutoCompleteTextView.NothingSelected"/> event.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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
                (appCompatAutoCompleteTextView, eventArgs) => null,
                () => "NothingSelected");
        }

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.ListSelection"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.ListSelection"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.SetCompletionHint(string)"/> method.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.SetCompletionHint(string)"/> method.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.SetDropDownBackgroundResource(int)"/> method.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.SetDropDownBackgroundResource(int)"/> method.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.SetText(string, bool)"/> method.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <param name="filter">The second parameter of <see cref="AppCompatAutoCompleteTextView.SetText(string, bool)"/> method.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.SetText(string, bool)"/> method.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<AppCompatAutoCompleteTextView, string> SetTextBinding(
            [NotNull] this IItemReference<AppCompatAutoCompleteTextView> appCompatAutoCompleteTextViewReference,
            bool filter = true)
        {
            if (appCompatAutoCompleteTextViewReference == null)
                throw new ArgumentNullException(nameof(appCompatAutoCompleteTextViewReference));

            return new TargetItemOneWayCustomBinding<AppCompatAutoCompleteTextView, string>(
                appCompatAutoCompleteTextViewReference,
                (appCompatAutoCompleteTextView, text) => appCompatAutoCompleteTextView.NotNull().SetText(text, filter),
                () => "SetText");
        }

        /// <summary>
        /// One way binding on <see cref="AppCompatAutoCompleteTextView.Threshold"/> property.
        /// </summary>
        /// <param name="appCompatAutoCompleteTextViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="AppCompatAutoCompleteTextView.Threshold"/> property.</returns>
        /// <exception cref="ArgumentNullException">appCompatAutoCompleteTextViewReference is null.</exception>
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
