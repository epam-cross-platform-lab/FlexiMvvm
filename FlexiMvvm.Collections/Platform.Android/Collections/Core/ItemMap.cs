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
        private ItemMap(ItemType type, [CanBeNull] object group, [CanBeNull] object item)
        {
            Type = type;
            Group = group;
            Item = item;
        }

        internal ItemType Type { get; }

        [CanBeNull]
        internal object Group { get; }

        [CanBeNull]
        internal object Item { get; }

        [NotNull]
        internal static ItemMap CreateForHeader()
        {
            return new ItemMap(ItemType.Header, null, null);
        }

        [NotNull]
        internal static ItemMap CreateForSectionHeader([CanBeNull] object group)
        {
            return new ItemMap(ItemType.SectionHeader, group, null);
        }

        [NotNull]
        internal static ItemMap CreateForItem([CanBeNull] object item)
        {
            return new ItemMap(ItemType.Item, null, item);
        }

        [NotNull]
        internal static ItemMap CreateForSectionFooter([CanBeNull] object group)
        {
            return new ItemMap(ItemType.SectionFooter, group, null);
        }

        [NotNull]
        internal static ItemMap CreateForFooter()
        {
            return new ItemMap(ItemType.Footer, null, null);
        }
    }
}
