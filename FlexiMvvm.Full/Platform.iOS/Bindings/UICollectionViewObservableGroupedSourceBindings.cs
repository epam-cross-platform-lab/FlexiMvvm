﻿// =========================================================================
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
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public static class UICollectionViewObservableGroupedSourceBindings
    {
        [NotNull]
        public static TargetItemBinding<UICollectionViewObservableGroupedSource, IEnumerable<IGrouping<object, object>>> GroupedItemsBinding(
            [NotNull] this IItemReference<UICollectionViewObservableGroupedSource> collectionViewSourceReference)
        {
            if (collectionViewSourceReference == null)
                throw new ArgumentNullException(nameof(collectionViewSourceReference));

            return new TargetItemOneWayCustomBinding<UICollectionViewObservableGroupedSource, IEnumerable<IGrouping<object, object>>>(
                collectionViewSourceReference,
                (collectionViewSource, groupedItems) => collectionViewSource.NotNull().GroupedItems = groupedItems,
                () => "GroupedItems");
        }
    }
}
