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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UITextViewBindings
    {
        /// <summary>
        /// One way binding on <see cref="UITextView.AdjustsFontForContentSizeCategory"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.AdjustsFontForContentSizeCategory"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> AdjustsFontForContentSizeCategoryBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, adjustsFontForContentSizeCategory) => textView.NotNull().AdjustsFontForContentSizeCategory = adjustsFontForContentSizeCategory,
                () => "AdjustsFontForContentSizeCategory");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.AllowsEditingTextAttributes"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.AllowsEditingTextAttributes"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> AllowsEditingTextAttributesBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, allowsEditingTextAttributes) => textView.NotNull().AllowsEditingTextAttributes = allowsEditingTextAttributes,
                () => "AllowsEditingTextAttributes");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.AttributedText"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.AttributedText"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, NSAttributedString> AttributedTextBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, NSAttributedString>(
                textViewReference,
                (textView, attributedText) => textView.NotNull().AttributedText = attributedText,
                () => "AttributedText");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.Changed"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.Changed"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> ChangedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().Changed += eventHandler,
                (textView, eventHandler) => textView.NotNull().Changed -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "Changed");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.ClearsOnInsertion"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.ClearsOnInsertion"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> ClearsOnInsertionBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, clearsOnInsertion) => textView.NotNull().ClearsOnInsertion = clearsOnInsertion,
                () => "ClearsOnInsertion");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.DecelerationEnded"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.DecelerationEnded"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> DecelerationEndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().DecelerationEnded += eventHandler,
                (textView, eventHandler) => textView.NotNull().DecelerationEnded -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "DecelerationEnded");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.DecelerationStarted"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.DecelerationStarted"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> DecelerationStartedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().DecelerationStarted += eventHandler,
                (textView, eventHandler) => textView.NotNull().DecelerationStarted -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "DecelerationStarted");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.DidZoom"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.DidZoom"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> DidZoomBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().DidZoom += eventHandler,
                (textView, eventHandler) => textView.NotNull().DidZoom -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "DidZoom");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.DraggingEnded"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.DraggingEnded"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> DraggingEndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, bool, DraggingEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().DraggingEnded += eventHandler,
                (textView, eventHandler) => textView.NotNull().DraggingEnded -= eventHandler,
                (textView, canExecuteCommand) => { },
                (textView, args) => args.Decelerate,
                () => "DraggingEnded");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.DraggingStarted"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.DraggingStarted"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> DraggingStartedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().DraggingStarted += eventHandler,
                (textView, eventHandler) => textView.NotNull().DraggingStarted -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "DraggingStarted");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.Ended"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.Ended"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> EndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().Ended += eventHandler,
                (textView, eventHandler) => textView.NotNull().Ended -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "Ended");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.Editable"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.Editable"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> EditableBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, editable) => textView.NotNull().Editable = editable,
                () => "Editable");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.EnablesReturnKeyAutomatically"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.EnablesReturnKeyAutomatically"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> EnablesReturnKeyAutomaticallyBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, enablesReturnKeyAutomatically) => textView.NotNull().EnablesReturnKeyAutomatically = enablesReturnKeyAutomatically,
                () => "EnablesReturnKeyAutomatically");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.InsertText"/> method.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.InsertText"/> method.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, string> InsertTextBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().InsertText(text),
                () => "InsertText");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.ScrollAnimationEnded"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.ScrollAnimationEnded"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> ScrollAnimationEndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().ScrollAnimationEnded += eventHandler,
                (textView, eventHandler) => textView.NotNull().ScrollAnimationEnded -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "ScrollAnimationEnded");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.Scrolled"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.Scrolled"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> ScrolledBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().Scrolled += eventHandler,
                (textView, eventHandler) => textView.NotNull().Scrolled -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "Scrolled");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.ScrolledToTop"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.ScrolledToTop"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> ScrolledToTopBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().ScrolledToTop += eventHandler,
                (textView, eventHandler) => textView.NotNull().ScrolledToTop -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "ScrolledToTop");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.SecureTextEntry"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.SecureTextEntry"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> SecureTextEntryBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, secureTextEntry) => textView.NotNull().SecureTextEntry = secureTextEntry,
                () => "SecureTextEntry");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.Selectable"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.Selectable"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, bool> SelectableBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, bool>(
                textViewReference,
                (textView, selectable) => textView.NotNull().Selectable = selectable,
                () => "Selectable");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.SelectionChanged"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.SelectionChanged"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, UITextRange> SelectionChangedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, UITextRange>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().SelectionChanged += eventHandler,
                (textView, eventHandler) => textView.NotNull().SelectionChanged -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => textView.SelectedTextRange,
                () => "SelectionChanged");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.Started"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.Started"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> StartedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().Started += eventHandler,
                (textView, eventHandler) => textView.NotNull().Started -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => null,
                () => "Started");
        }

        /// <summary>
        /// One way binding on <see cref="UITextView.Text"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UITextView.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, string> TextBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayCustomBinding<UITextView, string>(
                textViewReference,
                (textView, text) => textView.NotNull().Text = text,
                () => "Text");
        }

        /// <summary>
        /// Two way binding on <see cref="UITextView.Changed"/> event and <see cref="UITextView.Text"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Two way binding on <see cref="UITextView.Changed"/> event and <see cref="UITextView.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, string> TextAndChangedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemTwoWayCustomBinding<UITextView, string>(
                textViewReference,
                (textView, eventHandler) => textView.Changed += eventHandler,
                (textView, eventHandler) => textView.Changed -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => textView.Text,
                (textView, text) => textView.NotNull().Text = text,
                () => "TextAndChanged");
        }

        /// <summary>
        /// Two way binding on <see cref="UITextView.Ended"/> event and <see cref="UITextView.Text"/> property.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>Two way binding on <see cref="UITextView.Ended"/> event and <see cref="UITextView.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, string> TextAndEndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemTwoWayCustomBinding<UITextView, string>(
                textViewReference,
                (textView, eventHandler) => textView.Ended += eventHandler,
                (textView, eventHandler) => textView.Ended -= eventHandler,
                (textView, canExecuteCommand) => { },
                textView => textView.Text,
                (textView, text) => textView.NotNull().Text = text,
                () => "TextAndEnded");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.WillEndDragging"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.WillEndDragging"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> WillEndDraggingBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object, WillEndDraggingEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().WillEndDragging += eventHandler,
                (textView, eventHandler) => textView.NotNull().WillEndDragging -= eventHandler,
                (textView, canExecuteCommand) => { },
                (textView, args) => null,
                () => "WillEndDragging");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.ZoomingEnded"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.ZoomingEnded"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, nfloat> ZoomingEndedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, nfloat, ZoomingEndedEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().ZoomingEnded += eventHandler,
                (textView, eventHandler) => textView.NotNull().ZoomingEnded -= eventHandler,
                (textView, canExecuteCommand) => { },
                (textView, args) => args.AtScale,
                () => "ZoomingEnded");
        }

        /// <summary>
        /// One way to source binding on <see cref="UITextView.ZoomingStarted"/> event.
        /// </summary>
        /// <param name="textViewReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UITextView.ZoomingStarted"/> event.</returns>
        /// <exception cref="ArgumentNullException">textViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UITextView, object> ZoomingStartedBinding(
            [NotNull] this IItemReference<UITextView> textViewReference)
        {
            if (textViewReference == null)
                throw new ArgumentNullException(nameof(textViewReference));

            return new TargetItemOneWayToSourceCustomBinding<UITextView, object, UIScrollViewZoomingEventArgs>(
                textViewReference,
                (textView, eventHandler) => textView.NotNull().ZoomingStarted += eventHandler,
                (textView, eventHandler) => textView.NotNull().ZoomingStarted -= eventHandler,
                (textView, canExecuteCommand) => { },
                (textView, args) => null,
                () => "ZoomingStarted");
        }
    }
}
