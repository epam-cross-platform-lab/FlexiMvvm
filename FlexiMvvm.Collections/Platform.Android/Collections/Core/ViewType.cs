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
    internal static class ViewType
    {
        private const int MaxViewType = 1000;

        internal static int GetTarget(ItemType itemType, int requestedItemViewType)
        {
            return ((int)itemType * MaxViewType) + requestedItemViewType;
        }

        internal static int GetRequested(int targetItemViewType)
        {
            return targetItemViewType % MaxViewType;
        }

        internal static ItemType ToItemType(int targetItemViewType)
        {
            return (ItemType)(targetItemViewType / MaxViewType);
        }
    }
}
