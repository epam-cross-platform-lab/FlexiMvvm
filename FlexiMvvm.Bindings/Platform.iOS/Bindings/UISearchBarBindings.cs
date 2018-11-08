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
