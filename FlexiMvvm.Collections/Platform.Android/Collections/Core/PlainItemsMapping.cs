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
    internal class PlainItemsMapping : ItemsMappingBase
    {
        internal override void Reload(RecyclerViewObservableAdapterBase adapter)
        {
            ItemsMap.Clear();
            ItemsMap.Add(ItemMap.CreateForHeader());

            var sectionsCount = adapter.GetSectionsCount();

            for (var section = 0; section < sectionsCount; section++)
            {
                ItemsMap.Add(ItemMap.CreateForSectionHeader(null));

                var sectionItemsCount = adapter.GetSectionItemsCount(section);

                for (var row = 0; row < sectionItemsCount; row++)
                {
                    ItemsMap.Add(ItemMap.CreateForItem(adapter.GetItem(section, row)));
                }

                ItemsMap.Add(ItemMap.CreateForSectionFooter(null));
            }

            ItemsMap.Add(ItemMap.CreateForFooter());

            adapter.NotifyDataSetChanged();
        }
    }
}
