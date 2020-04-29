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
    public static class UICollectionViewCellExtensions
    {
        public static TargetItemBinding<UICollectionViewCell, bool> SelectedBinding(
            this IItemReference<UICollectionViewCell> collectionViewCellReference)
        {
            if (collectionViewCellReference == null)
                throw new ArgumentNullException(nameof(collectionViewCellReference));

            return new TargetItemOneWayCustomBinding<UICollectionViewCell, bool>(
                collectionViewCellReference,
                (collectionViewCell, selected) => collectionViewCell.Selected = selected,
                () => nameof(UICollectionViewCell.Selected));
        }
    }
}
