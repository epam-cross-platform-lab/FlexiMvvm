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
using FlexiMvvm.Bindings.Custom;
using FlexiMvvm.Collections;

namespace FlexiMvvm.Bindings
{
    /// <summary>
    /// Provides a set of static methods for creating bindings on <see cref="IItemsSource{T}"/> members.
    /// </summary>
    public static class ItemsSourceExtensions
    {
        /// <summary>
        /// One way binding on <see cref="IItemsSource{T}.Items"/> property. Collection of items is passed as a value.
        /// </summary>
        /// <typeparam name="T">The type of the collection item.</typeparam>
        /// <param name="itemsSourceReference">The items source reference.</param>
        /// <returns>The binding instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="itemsSourceReference"/> is <c>null</c>.</exception>
        public static TargetItemBinding<IItemsSource<T>, IEnumerable<T>> ItemsBinding<T>(
            this IItemReference<IItemsSource<T>> itemsSourceReference)
        {
            if (itemsSourceReference == null)
                throw new ArgumentNullException(nameof(itemsSourceReference));

            return new TargetItemOneWayCustomBinding<IItemsSource<T>, IEnumerable<T>>(
                itemsSourceReference,
                (itemsSource, items) => itemsSource.Items = items,
                () => $"{nameof(IItemsSource<T>.Items)}");
        }
    }
}
