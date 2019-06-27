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
using System.Collections.Generic;
using System.Linq;
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    public static class RecyclerViewObservableGroupedAdapterExtensions
    {
        public static TargetItemBinding<RecyclerViewObservableGroupedAdapter, IEnumerable<IGrouping<object, object>>> GroupedItemsBinding(
            this IItemReference<RecyclerViewObservableGroupedAdapter> recyclerViewAdapterReference)
        {
            if (recyclerViewAdapterReference == null)
                throw new ArgumentNullException(nameof(recyclerViewAdapterReference));

            return new TargetItemOneWayCustomBinding<RecyclerViewObservableGroupedAdapter, IEnumerable<IGrouping<object, object>>>(
                recyclerViewAdapterReference,
                (recyclerViewAdapter, groupedItems) => recyclerViewAdapter.GroupedItems = groupedItems,
                () => $"{nameof(RecyclerViewObservableGroupedAdapter.GroupedItems)}");
        }
    }
}
