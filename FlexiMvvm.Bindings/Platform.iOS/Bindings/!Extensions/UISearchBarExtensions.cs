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
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UISearchBarExtensions
    {
        public static TargetItemBinding<UISearchBar, object> BookmarkButtonClickedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.BookmarkButtonClicked += handler,
                (searchBar, handler) => searchBar.BookmarkButtonClicked -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.BookmarkButtonClicked)}");
        }

        public static TargetItemBinding<UISearchBar, object> CancelButtonClickedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.CancelButtonClicked += handler,
                (searchBar, handler) => searchBar.CancelButtonClicked -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.CancelButtonClicked)}");
        }

        public static TargetItemBinding<UISearchBar, object> ListButtonClickedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.ListButtonClicked += handler,
                (searchBar, handler) => searchBar.ListButtonClicked -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.ListButtonClicked)}");
        }

        public static TargetItemBinding<UISearchBar, object> OnEditingStartedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.OnEditingStarted += handler,
                (searchBar, handler) => searchBar.OnEditingStarted -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.OnEditingStarted)}");
        }

        public static TargetItemBinding<UISearchBar, object> OnEditingStoppedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.OnEditingStopped += handler,
                (searchBar, handler) => searchBar.OnEditingStopped -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.OnEditingStopped)}");
        }

        public static TargetItemBinding<UISearchBar, string> PlaceholderBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, placeholder) => searchBar.Placeholder = placeholder,
                () => $"{nameof(UISearchBar.Placeholder)}");
        }

        public static TargetItemBinding<UISearchBar, string> PromptBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, prompt) => searchBar.Prompt = prompt,
                () => $"{nameof(UISearchBar.Prompt)}");
        }

        public static TargetItemBinding<UISearchBar, object> SearchButtonClickedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, object>(
                searchBarReference,
                (searchBar, handler) => searchBar.SearchButtonClicked += handler,
                (searchBar, handler) => searchBar.SearchButtonClicked -= handler,
                (searchBar, canExecuteCommand) => { },
                searchBar => null,
                () => $"{nameof(UISearchBar.SearchButtonClicked)}");
        }

        public static TargetItemBinding<UISearchBar, bool> SearchResultsButtonSelectedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, searchResultsButtonSelected) => searchBar.SearchResultsButtonSelected = searchResultsButtonSelected,
                () => $"{nameof(UISearchBar.SearchResultsButtonSelected)}");
        }

        public static TargetItemBinding<UISearchBar, bool> SecureTextEntryBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, secureTextEntry) => searchBar.SecureTextEntry = secureTextEntry,
                () => $"{nameof(UISearchBar.SecureTextEntry)}");
        }

        public static TargetItemBinding<UISearchBar, bool> SetShowsCancelButtonBinding(
            this IItemReference<UISearchBar> searchBarReference,
            bool animated = true)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsCancelButton) => searchBar.SetShowsCancelButton(showsCancelButton, animated),
                () => $"{nameof(UISearchBar.SetShowsCancelButton)}");
        }

        public static TargetItemBinding<UISearchBar, bool> ShowsBookmarkButtonBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsBookmarkButton) => searchBar.ShowsBookmarkButton = showsBookmarkButton,
                () => $"{nameof(UISearchBar.ShowsBookmarkButton)}");
        }

        public static TargetItemBinding<UISearchBar, bool> ShowsCancelButtonBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsCancelButton) => searchBar.ShowsCancelButton = showsCancelButton,
                () => $"{nameof(UISearchBar.ShowsCancelButton)}");
        }

        public static TargetItemBinding<UISearchBar, bool> ShowsScopeBarBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsScopeBar) => searchBar.ShowsScopeBar = showsScopeBar,
                () => $"{nameof(UISearchBar.ShowsScopeBar)}");
        }

        public static TargetItemBinding<UISearchBar, bool> ShowsSearchResultsButtonBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, showsSearchResultsButton) => searchBar.ShowsSearchResultsButton = showsSearchResultsButton,
                () => $"{nameof(UISearchBar.ShowsSearchResultsButton)}");
        }

        public static TargetItemBinding<UISearchBar, string> TextAndTextChangedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemTwoWayCustomBinding<UISearchBar, string, UISearchBarTextChangedEventArgs>(
                searchBarReference,
                (searchBar, handler) => searchBar.TextChanged += handler,
                (searchBar, handler) => searchBar.TextChanged -= handler,
                (searchBar, canExecuteCommand) => { },
                (searchBar, args) => args != null ? args.SearchText : searchBar.Text,
                (searchBar, text) => searchBar.Text = text,
                () => $"{nameof(UISearchBar.Text)}And{nameof(UISearchBar.TextChanged)}");
        }

        public static TargetItemBinding<UISearchBar, string> TextBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, string>(
                searchBarReference,
                (searchBar, text) => searchBar.Text = text,
                () => $"{nameof(UISearchBar.Text)}");
        }

        public static TargetItemBinding<UISearchBar, string> TextChangedBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayToSourceCustomBinding<UISearchBar, string, UISearchBarTextChangedEventArgs>(
                searchBarReference,
                (searchBar, handler) => searchBar.TextChanged += handler,
                (searchBar, handler) => searchBar.TextChanged -= handler,
                (searchBar, canExecuteCommand) => { },
                (searchBar, args) => args.SearchText,
                () => $"{nameof(UISearchBar.TextChanged)}");
        }

        public static TargetItemBinding<UISearchBar, bool> TranslucentBinding(
            this IItemReference<UISearchBar> searchBarReference)
        {
            if (searchBarReference == null)
                throw new ArgumentNullException(nameof(searchBarReference));

            return new TargetItemOneWayCustomBinding<UISearchBar, bool>(
                searchBarReference,
                (searchBar, translucent) => searchBar.Translucent = translucent,
                () => $"{nameof(UISearchBar.Translucent)}");
        }
    }
}
