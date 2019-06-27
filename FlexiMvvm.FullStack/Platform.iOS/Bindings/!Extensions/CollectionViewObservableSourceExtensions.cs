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
    public static class CollectionViewObservableSourceExtensions
    {
        public static TargetItemBinding<CollectionViewObservableSource, object> ItemDeselectedBinding(
            this IItemReference<CollectionViewObservableSource> collectionViewSourceReference)
        {
            if (collectionViewSourceReference == null)
                throw new ArgumentNullException(nameof(collectionViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<CollectionViewObservableSource, object, SelectionChangedEventArgs>(
                collectionViewSourceReference,
                (collectionViewSource, handler) => collectionViewSource.ItemDeselectedCalled += handler,
                (collectionViewSource, handler) => collectionViewSource.ItemDeselectedCalled -= handler,
                (collectionViewSource, canExecuteCommand) => { },
                (collectionViewSource, args) => args?.Item,
                () => $"{nameof(CollectionViewObservableSource.ItemDeselected)}");
        }

        public static TargetItemBinding<CollectionViewObservableSource, object> ItemSelectedBinding(
            this IItemReference<CollectionViewObservableSource> collectionViewSourceReference)
        {
            if (collectionViewSourceReference == null)
                throw new ArgumentNullException(nameof(collectionViewSourceReference));

            return new TargetItemOneWayToSourceCustomBinding<CollectionViewObservableSource, object, SelectionChangedEventArgs>(
                collectionViewSourceReference,
                (collectionViewSource, handler) => collectionViewSource.ItemSelectedCalled += handler,
                (collectionViewSource, handler) => collectionViewSource.ItemSelectedCalled -= handler,
                (collectionViewSource, canExecuteCommand) => { },
                (collectionViewSource, args) => args?.Item,
                () => $"{nameof(CollectionViewObservableSource.ItemSelected)}");
        }
    }
}
