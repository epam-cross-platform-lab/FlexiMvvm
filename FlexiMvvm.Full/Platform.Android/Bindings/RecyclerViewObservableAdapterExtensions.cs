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
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class RecyclerViewObservableAdapterExtensions
    {
        [NotNull]
        public static TargetItemBinding<RecyclerViewObservableAdapterBase, object> ItemClickedBinding(
            [NotNull] this IItemReference<RecyclerViewObservableAdapterBase> recyclerViewAdapterReference)
        {
            if (recyclerViewAdapterReference == null)
                throw new ArgumentNullException(nameof(recyclerViewAdapterReference));

            return new TargetItemOneWayToSourceCustomBinding<RecyclerViewObservableAdapterBase, object, SelectionChangedEventArgs>(
                recyclerViewAdapterReference,
                (recyclerViewAdapter, eventHandler) => recyclerViewAdapter.NotNull().ItemClicked += eventHandler,
                (recyclerViewAdapter, eventHandler) => recyclerViewAdapter.NotNull().ItemClicked -= eventHandler,
                (recyclerViewAdapter, canExecuteCommand) => { },
                (recyclerViewAdapter, eventArgs) => eventArgs?.Item,
                () => "ItemClicked");
        }
    }
}
