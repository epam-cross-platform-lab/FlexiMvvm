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
    public static class UISearchBarBindings
    {
        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.BookmarkButtonClicked"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.BookmarkButtonClicked"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> BookmarkButtonClickedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().BookmarkButtonClicked += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().BookmarkButtonClicked -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "BookmarkButtonClicked");
        }

        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.CancelButtonClicked"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.CancelButtonClicked"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> CancelButtonClickedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().CancelButtonClicked += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().CancelButtonClicked -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "CancelButtonClicked");
        }

        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.ListButtonClicked"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.ListButtonClicked"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> ListButtonClickedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().ListButtonClicked += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().ListButtonClicked -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "ListButtonClicked");
        }

        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.OnEditingStarted"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.OnEditingStarted"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> OnEditingStartedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().OnEditingStarted += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().OnEditingStarted -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "OnEditingStarted");
        }

        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.OnEditingStopped"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.OnEditingStopped"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> OnEditingStoppedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().OnEditingStopped += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().OnEditingStopped -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "OnEditingStopped");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.Placeholder"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.Placeholder"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, string> PlaceholderBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, placeholder) => searchBar.NotNull().Placeholder = placeholder,
                () => "Placeholder");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.Prompt"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.Prompt"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, string> PromptBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, prompt) => searchBar.NotNull().Prompt = prompt,
                () => "Prompt");
        }

        /// <summary>
        /// One way to source binding on <see cref="UISearchBar.SearchButtonClicked"/> event.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way to source binding on <see cref="UISearchBar.SearchButtonClicked"/> event.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, object> SearchButtonClickedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().SearchButtonClicked += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().SearchButtonClicked -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => "SearchButtonClicked");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.SearchResultsButtonSelected"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.SearchResultsButtonSelected"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> SearchResultsButtonSelectedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, searchResultsButtonSelected) => searchBar.NotNull().SearchResultsButtonSelected = searchResultsButtonSelected,
                () => "SearchResultsButtonSelected");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.SecureTextEntry"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.SecureTextEntry"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> SecureTextEntryBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, secureTextEntry) => searchBar.NotNull().SecureTextEntry = secureTextEntry,
                () => "SecureTextEntry");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.SetShowsCancelButton"/> method.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <param name="animated">Second parameter for <see cref="UISearchBar.SetShowsCancelButton"/> method.</param>
        /// <returns>One way binding on <see cref="UISearchBar.SetShowsCancelButton"/> method.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> SetShowsCancelButtonBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference,
            bool animated = true)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsCancelButton) => searchBar.NotNull().SetShowsCancelButton(showsCancelButton, animated),
                () => "SetShowsCancelButton");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.ShowsBookmarkButton"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.ShowsBookmarkButton"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> ShowsBookmarkButtonBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsBookmarkButton) => searchBar.NotNull().ShowsBookmarkButton = showsBookmarkButton,
                () => "ShowsBookmarkButton");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.ShowsCancelButton"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.ShowsCancelButton"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> ShowsCancelButtonBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsCancelButton) => searchBar.NotNull().ShowsCancelButton = showsCancelButton,
                () => "ShowsCancelButton");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.ShowsScopeBar"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.ShowsScopeBar"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> ShowsScopeBarBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsScopeBar) => searchBar.NotNull().ShowsScopeBar = showsScopeBar,
                () => "ShowsScopeBar");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.ShowsSearchResultsButton"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.ShowsSearchResultsButton"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> ShowsSearchResultsButtonBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsSearchResultsButton) => searchBar.NotNull().ShowsSearchResultsButton = showsSearchResultsButton,
                () => "ShowsSearchResultsButton");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.Text"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, string> TextBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, text) => searchBar.NotNull().Text = text,
                () => "Text");
        }

        /// <summary>
        /// Two way binding on <see cref="UISearchBar.TextChanged"/> event and <see cref="UISearchBar.Text"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>Two way binding on <see cref="UISearchBar.TextChanged"/> event and <see cref="UISearchBar.Text"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, string> TextAndTextChangedBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemTwoWayCustomBinding<UISearchBar, string, UISearchBarTextChangedEventArgs>(
                searchBarReference,
                (searchBar, eventHandler) => searchBar.NotNull().TextChanged += eventHandler,
                (searchBar, eventHandler) => searchBar.NotNull().TextChanged -= eventHandler,
                (searchBar, canExecuteCommand) => { },
                (searchBar, eventArgs) => eventArgs?.SearchText ?? searchBar.NotNull().Text,
                (searchBar, text) => searchBar.NotNull().Text = text,
                () => "TextAndTextChanged");
        }

        /// <summary>
        /// One way binding on <see cref="UISearchBar.Translucent"/> property.
        /// </summary>
        /// <param name="searchBarReference">The item reference.</param>
        /// <returns>One way binding on <see cref="UISearchBar.Translucent"/> property.</returns>
        /// <exception cref="ArgumentNullException">searchBarReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UISearchBar, bool> TranslucentBinding(
            [NotNull] this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, translucent) => searchBar.NotNull().Translucent = translucent,
                () => "Translucent");
        }
    }
}
