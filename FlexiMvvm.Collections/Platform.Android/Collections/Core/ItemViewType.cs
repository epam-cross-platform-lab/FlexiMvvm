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
    public class ItemViewType
    {
        public const int Header = 1;
        public const int SectionHeader = 2;
        public const int Item = 3;
        public const int SectionFooter = 4;
        public const int Footer = 5;
        private const int MaxViewType = 1024;

        private ItemViewType(int itemType, int itemViewType = 0)
        {
            ItemType = itemType;
            ViewType = itemViewType;
        }

        public int ViewType
        {
            get => Combined % MaxViewType;
            set => Combined = Combine(ItemType, value);
        }

        public int ItemType { get; }

        public bool IsHeader => ItemType == Header;

        public bool IsSectionHeader => ItemType == SectionHeader;

        public bool IsItem => ItemType == Item;

        public bool IsSectionFooter => ItemType == SectionFooter;

        public bool IsFooter => ItemType == Footer;

        internal int Combined { get; private set; }

        public static explicit operator ItemViewType(int combined)
        {
            var itemType = combined / MaxViewType;
            var itemViewType = combined % MaxViewType;

            return new ItemViewType(itemType, itemViewType);
        }

        internal static ItemViewType CreateForHeader(int itemViewType = 0) => new ItemViewType(Header, itemViewType);

        internal static ItemViewType CreateForSectionHeader(int itemViewType = 0) => new ItemViewType(SectionHeader, itemViewType);

        internal static ItemViewType CreateForItem(int itemViewType = 0) => new ItemViewType(Item, itemViewType);

        internal static ItemViewType CreateForSectionFooter(int itemViewType = 0) => new ItemViewType(SectionFooter, itemViewType);

        internal static ItemViewType CreateForFooter(int itemViewType = 0) => new ItemViewType(Footer, itemViewType);

        private int Combine(int itemType, int itemViewType) => (itemType * MaxViewType) + itemViewType;
    }
}
