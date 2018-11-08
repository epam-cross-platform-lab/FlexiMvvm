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

using Android.Widget;
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class SearchViewExtensions
    {
        [NotNull]
        public static TargetItemBinding<SearchView, string> QueryAndQueryTextChangeBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference,
            bool trackCanExecuteCommandChanged = false)
        {
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
        public static TargetItemBinding<SearchView, string> SetQueryHintBinding(
            [NotNull] this IItemReference<SearchView> searchViewReference)
        {
            return new TargetItemOneWayCustomBinding<SearchView, string>(
                searchViewReference,
                (searchView, hint) => searchView.NotNull().SetQueryHint(hint),
                () => "SetQueryHint");
        }
    }
}
