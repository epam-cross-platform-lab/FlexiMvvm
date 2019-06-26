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

using JetBrains.Annotations;

namespace FlexiMvvm.Collections.Core
{
    internal class ItemMap
    {
        private ItemMap(ItemViewType iteViewType, [CanBeNull] object group, [CanBeNull] object item)
        {
            Type = iteViewType;
            Group = group;
            Item = item;
        }

        internal ItemViewType Type { get; }

        [CanBeNull]
        internal object Group { get; }

        [CanBeNull]
        internal object Item { get; }

        [NotNull]
        internal static ItemMap CreateForHeader()
        {
            return new ItemMap(ItemViewType.CreateForHeader(), null, null);
        }

        [NotNull]
        internal static ItemMap CreateForSectionHeader([CanBeNull] object group)
        {
            return new ItemMap(ItemViewType.CreateForSectionHeader(), group, null);
        }

        [NotNull]
        internal static ItemMap CreateForItem([CanBeNull] object item)
        {
            return new ItemMap(ItemViewType.CreateForItem(), null, item);
        }

        [NotNull]
        internal static ItemMap CreateForSectionFooter([CanBeNull] object group)
        {
            return new ItemMap(ItemViewType.CreateForSectionFooter(), group, null);
        }

        [NotNull]
        internal static ItemMap CreateForFooter()
        {
            return new ItemMap(ItemViewType.CreateForFooter(), null, null);
        }
    }
}
