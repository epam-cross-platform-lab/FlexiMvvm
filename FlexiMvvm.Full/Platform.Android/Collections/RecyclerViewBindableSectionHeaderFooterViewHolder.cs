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
using FlexiMvvm.Bindings;
using JetBrains.Annotations;

namespace FlexiMvvm.Collections
{
    public class RecyclerViewBindableSectionHeaderFooterViewHolder<TItemsContext>
        : RecyclerViewObservableSectionHeaderFooterViewHolder<TItemsContext>
        where TItemsContext : class
    {
        [CanBeNull]
        private BindingSet<TItemsContext> _itemsContextBindingSet;

        public RecyclerViewBindableSectionHeaderFooterViewHolder([NotNull] View itemView)
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

    public class RecyclerViewBindableSectionHeaderFooterViewHolder<TItemsContext, TGroup>
        : RecyclerViewObservableSectionHeaderFooterViewHolder<TItemsContext, TGroup>
        where TItemsContext : class
        where TGroup : class
    {
        [CanBeNull]
        private BindingSet<TItemsContext> _itemsContextBindingSet;
        [CanBeNull]
        private BindingSet<TGroup> _groupBindingSet;

        public RecyclerViewBindableSectionHeaderFooterViewHolder([NotNull] View itemView)
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

        public override void Bind(TGroup group)
        {
            base.Bind(group);

            if (_groupBindingSet == null)
            {
                _groupBindingSet = new BindingSet<TGroup>(group);
                Bind(_groupBindingSet);
                _groupBindingSet.Apply();
            }
            else
            {
                _groupBindingSet.SetSourceItem(group);
            }
        }

        public virtual void Bind([NotNull] BindingSet<TGroup> bindingSet)
        {
        }
    }
}
