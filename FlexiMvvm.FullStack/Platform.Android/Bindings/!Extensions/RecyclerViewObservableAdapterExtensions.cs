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
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    public static class RecyclerViewObservableAdapterExtensions
    {
        [Obsolete("Use ItemSelectedBinding and ItemDeselectedBinding methods instead.")]
        public static TargetItemBinding<RecyclerViewObservableAdapter, object> ItemClickedBinding(
            this IItemReference<RecyclerViewObservableAdapter> recyclerViewAdapterReference)
        {
            if (recyclerViewAdapterReference == null)
                throw new ArgumentNullException(nameof(recyclerViewAdapterReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerViewObservableAdapter, object, SelectionChangedEventArgs>(
                recyclerViewAdapterReference,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemClicked += handler,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemClicked -= handler,
                (recyclerViewAdapter, canExecuteCommand) => { },
                (recyclerViewAdapter, args) => args.Item,
                () => $"{nameof(RecyclerViewObservableAdapter.ItemClicked)}");
        }

        public static TargetItemBinding<RecyclerViewObservableAdapter, object> ItemSelectedBinding(
            this IItemReference<RecyclerViewObservableAdapter> recyclerViewAdapterReference)
        {
            if (recyclerViewAdapterReference == null)
                throw new ArgumentNullException(nameof(recyclerViewAdapterReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerViewObservableAdapter, object, SelectionChangedEventArgs>(
                recyclerViewAdapterReference,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemSelected += handler,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemSelected -= handler,
                (recyclerViewAdapter, canExecuteCommand) => { },
                (recyclerViewAdapter, args) => args.Item,
                () => $"{nameof(RecyclerViewObservableAdapter.ItemSelected)}");
        }

        public static TargetItemBinding<RecyclerViewObservableAdapter, object> ItemDeselectedBinding(
            this IItemReference<RecyclerViewObservableAdapter> recyclerViewAdapterReference)
        {
            if (recyclerViewAdapterReference == null)
                throw new ArgumentNullException(nameof(recyclerViewAdapterReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerViewObservableAdapter, object, SelectionChangedEventArgs>(
                recyclerViewAdapterReference,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemDeselected += handler,
                (recyclerViewAdapter, handler) => recyclerViewAdapter.ItemDeselected -= handler,
                (recyclerViewAdapter, canExecuteCommand) => { },
                (recyclerViewAdapter, args) => args.Item,
                () => $"{nameof(RecyclerViewObservableAdapter.ItemDeselected)}");
        }
    }
}
