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
using Android.Views;
using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class SearchViewBindings
    {
        [NotNull]
        public static TargetItemBinding<SearchView, bool> CheckedChangeBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, bool, SearchView.CloseEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().Close += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().Close -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.Handled,
                () => "Close");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, bool> IconifiedBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, bool>(
                searchViewReference,
                (searchView, iconified) => searchView.NotNull().Iconified = iconified,
                () => "Iconified");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, string> QueryAndQueryTextChangeBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemTwoWayCustomBinding<SearchView, string, SearchView.QueryTextChangeEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().QueryTextChange += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().QueryTextChange -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => searchView.NotNull().Query,
                (searchView, query) => searchView.NotNull().SetQuery(query, true),
                () => "QueryAndQueryTextChange");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, bool> QueryRefinementEnabledBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, bool>(
                searchViewReference,
                (searchView, queryRefinementEnabled) => searchView.NotNull().QueryRefinementEnabled = queryRefinementEnabled,
                () => "QueryRefinementEnabled");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, string> QueryTextChangeBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, string, SearchView.QueryTextChangeEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().QueryTextChange += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().QueryTextChange -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.NewText,
                () => "QueryTextChange");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, bool> QueryTextFocusChangeBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, bool, View.FocusChangeEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().QueryTextFocusChange += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().QueryTextFocusChange -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.HasFocus,
                () => "QueryTextFocusChange");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, string> QueryTextSubmitBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, string, SearchView.QueryTextSubmitEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().QueryTextSubmit += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().QueryTextSubmit -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.Query,
                () => "QueryTextSubmit");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, object> SearchClickBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, object>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().SearchClick += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().SearchClick -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                searchView => null,
                () => "SearchClick");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, int> SetMaxWidthBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, int>(
                searchViewReference,
                (searchView, maxpixels) => searchView.NotNull().SetMaxWidth(maxpixels),
                () => "SetMaxWidth");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, string> SetQueryBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool submit = true)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, string>(
                searchViewReference,
                (searchView, query) => searchView.NotNull().SetQuery(query, submit),
                () => "SetQuery");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, string> SetQueryHintBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, string>(
                searchViewReference,
                (searchView, hint) => searchView.NotNull().SetQueryHint(hint),
                () => "SetQueryHint");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, bool> SubmitButtonEnabledBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayCustomBinding<SearchView, bool>(
                searchViewReference,
                (searchView, submitButtonEnabled) => searchView.NotNull().SubmitButtonEnabled = submitButtonEnabled,
                () => "SubmitButtonEnabled");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, int> SuggestionClickBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, int, SearchView.SuggestionClickEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().SuggestionClick += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().SuggestionClick -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.Position,
                () => "SuggestionClick");
        }

        [NotNull]
        public static TargetItemBinding<SearchView, int> SuggestionSelectBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (searchViewReference == null)
                throw new ArgumentNullException(nameof(searchViewReference));

            return new TargetItemOneWayToSourceCustomBinding<SearchView, int, SearchView.SuggestionSelectEventArgs>(
                searchViewReference,
                (searchView, eventHandler) => searchView.NotNull().SuggestionSelect += eventHandler,
                (searchView, eventHandler) => searchView.NotNull().SuggestionSelect -= eventHandler,
                (searchView, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        searchView.NotNull().Enabled = canExecuteCommand;
                    }
                },
                (searchView, eventArgs) => eventArgs.Position,
                () => "SuggestionSelect");
        }
    }
}
