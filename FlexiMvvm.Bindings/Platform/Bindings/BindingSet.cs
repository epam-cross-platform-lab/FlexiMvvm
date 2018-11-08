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

using System;
using FlexiMvvm.Bindings.Builders;
using FlexiMvvm.Bindings.Custom.Core.Composite;
using FlexiMvvm.Collections;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public partial class BindingSet<TSourceItem> : IDisposable
        where TSourceItem : class
    {
        [NotNull]
        [ItemNotNull]
        private readonly DisposableCollection<ICompositeItemBinding<TSourceItem>> _bindings = new DisposableCollection<ICompositeItemBinding<TSourceItem>>();
        [NotNull]
        [ItemNotNull]
        private readonly DisposableCollection<ICompositeItemBinding<TSourceItem>> _appliedBindings = new DisposableCollection<ICompositeItemBinding<TSourceItem>>();
        [NotNull]
        private ItemReference<TSourceItem> _sourceItemReference;

        public BindingSet([CanBeNull] TSourceItem sourceItem)
        {
            _sourceItemReference = new ItemReference<TSourceItem>(sourceItem, ItemReferenceType.Weak);
        }

        public void SetSourceItem([CanBeNull] TSourceItem sourceItem)
        {
            _sourceItemReference = new ItemReference<TSourceItem>(sourceItem, ItemReferenceType.Weak);

            foreach (var binding in _appliedBindings)
            {
                binding.SetSourceItemReference(_sourceItemReference);
            }
        }

        [NotNull]
        public ITargetItemBindingBuilder<TSourceItem, TTargetItem> Bind<TTargetItem>(
            [CanBeNull] TTargetItem targetItem,
            ItemReferenceType referenceType = ItemReferenceType.Weak)
            where TTargetItem : class
        {
            var targetItemReference = new ItemReference<TTargetItem>(targetItem, referenceType);

            return new TargetItemBindingBuilder<TSourceItem, TTargetItem>(_sourceItemReference, targetItemReference, this);
        }

        [NotNull]
        public IDisposable Apply()
        {
            while (_bindings.Count > 0)
            {
                var binding = _bindings[0];

                if (binding.Apply())
                {
                    _appliedBindings.Add(binding);
                }

                _bindings.Remove(binding);
            }

            return this;
        }

        public void Dispose()
        {
            _bindings.Dispose();
            _appliedBindings.Dispose();
        }

        internal void Add([NotNull] ICompositeItemBinding<TSourceItem> compositeItemBinding)
        {
            if (_appliedBindings.Count == 0)
            {
                _bindings.Add(compositeItemBinding);
            }
        }

        internal void Remove([NotNull] ICompositeItemBinding<TSourceItem> compositeItemBinding)
        {
            if (_appliedBindings.Count == 0)
            {
                _bindings.Remove(compositeItemBinding);
            }
        }
    }
}
