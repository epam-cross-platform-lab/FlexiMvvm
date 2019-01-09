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
using Foundation;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UICollectionViewBindings
    {
        /// <summary>
        /// One way binding on <see cref="UICollectionView.ScrollToItem"/> method.
        /// </summary>
        /// <param name="collectionViewReference">The item reference.</param>
        /// <param name="scrollPosition">Second parameter for <see cref="UICollectionView.ScrollToItem"/> method.</param>
        /// <param name="animated">Third parameter for <see cref="UICollectionView.ScrollToItem"/> method.</param>
        /// <returns>One way binding on <see cref="UICollectionView.ScrollToItem"/> method.</returns>
        /// <exception cref="ArgumentNullException">collectionViewReference is null.</exception>
        [NotNull]
        public static TargetItemBinding<UICollectionView, NSIndexPath> ScrollToItemBinding(
            [NotNull] this IItemReference<UICollectionView> collectionViewReference,
            UICollectionViewScrollPosition scrollPosition,
            bool animated = true)
        {
            if (collectionViewReference == null)
                throw new ArgumentNullException(nameof(collectionViewReference));

            return new TargetItemOneWayCustomBinding<UICollectionView, NSIndexPath>(
                collectionViewReference,
                (collectionView, indexPath) => collectionView.NotNull().ScrollToItem(indexPath, scrollPosition, animated),
                () => "ScrollToItem");
        }
    }
}
