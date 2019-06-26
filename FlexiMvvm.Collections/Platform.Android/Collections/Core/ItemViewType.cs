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

namespace FlexiMvvm.Collections.Core
{
    public static class ItemViewType
    {
        private const int MaxViewType = 1024;

        public static bool IsHeader(int itemViewType)
        {
            return GetItemKind(itemViewType) == ItemKind.Header;
        }

        public static bool IsSectionHeader(int itemViewType)
        {
            return GetItemKind(itemViewType) == ItemKind.SectionHeader;
        }

        public static bool IsItem(int itemViewType)
        {
            return GetItemKind(itemViewType) == ItemKind.Item;
        }

        public static bool IsSectionFooter(int itemViewType)
        {
            return GetItemKind(itemViewType) == ItemKind.SectionFooter;
        }

        public static bool IsFooter(int itemViewType)
        {
            return GetItemKind(itemViewType) == ItemKind.Footer;
        }

        internal static int GetAdjustedViewType(ItemKind itemKind, int userViewType)
        {
            return ((int)itemKind * MaxViewType) + userViewType;
        }

        internal static int GetUserViewType(int adjustedViewType)
        {
            return adjustedViewType % MaxViewType;
        }

        internal static ItemKind GetItemKind(int adjustedViewType)
        {
            return (ItemKind)(adjustedViewType / MaxViewType);
        }
    }
}
