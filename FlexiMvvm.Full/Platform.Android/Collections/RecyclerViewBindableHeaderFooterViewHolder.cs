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

using Android.Views;
using FlexiMvvm.Bindings;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class RecyclerViewBindableHeaderFooterViewHolder<TItemsContext>
        : RecyclerViewObservableHeaderFooterViewHolder<TItemsContext>
        where TItemsContext : class
    {
        [CanBeNull]
        private BindingSet<TItemsContext> _itemsContextBindingSet;

        public RecyclerViewBindableHeaderFooterViewHolder([NotNull] View itemView)
            : base(itemView)
        {
        }

        public override void Bind(TItemsContext itemsContext)
        {
            base.Bind(itemsContext);

            if (_itemsContextBindingSet == null)
            {
                _itemsContextBindingSet = new BindingSet<TItemsContext>(itemsContext);
                Bind(_itemsContextBindingSet);
                _itemsContextBindingSet.Apply();
            }
        }

        public virtual void Bind([NotNull] BindingSet<TItemsContext> bindingSet)
        {
        }
    }
}
