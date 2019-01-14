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

using Android.Views;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class RecyclerViewObservableItemViewHolder<TItemsContext, TItem> : RecyclerViewObservableViewHolder
    {
        public RecyclerViewObservableItemViewHolder([NotNull] View itemView)
            : base(itemView)
        {
        }

        [CanBeNull]
        public TItemsContext ItemsContext { get; private set; }

        [CanBeNull]
        public TItem Item { get; private set; }

        internal override void Bind(object itemsContext, object value)
        {
            base.Bind(itemsContext, value);

            ItemsContext = (TItemsContext)itemsContext;
            Item = (TItem)value;

            Bind(ItemsContext);
            Bind(Item);
        }

        public virtual void Bind([CanBeNull] TItemsContext itemsContext)
        {
        }

        public virtual void Bind([CanBeNull] TItem item)
        {
        }
    }
}
