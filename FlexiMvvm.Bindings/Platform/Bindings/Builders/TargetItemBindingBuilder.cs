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
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Builders
{
    internal class TargetItemBindingBuilder<TSourceItem, TTargetItem> : ITargetItemBindingBuilder<TSourceItem, TTargetItem>
        where TSourceItem : class
        where TTargetItem : class
    {
        [NotNull]
        private readonly ItemReference<TSourceItem> _sourceItemReference;
        [NotNull]
        private readonly ItemReference<TTargetItem> _targetItemReference;
        [NotNull]
        private readonly BindingSet<TSourceItem> _bindingSet;

        internal TargetItemBindingBuilder(
            [NotNull] ItemReference<TSourceItem> sourceItemReference,
            [NotNull] ItemReference<TTargetItem> targetItemReference,
            [NotNull] BindingSet<TSourceItem> bindingSet)
        {
            _sourceItemReference = sourceItemReference;
            _targetItemReference = targetItemReference;
            _bindingSet = bindingSet;
        }

        public ISourceItemBindingBuilder<TSourceItem, TTargetItemValue> For<TBaseTargetItem, TTargetItemValue>(
            Func<IItemReference<TTargetItem>, TargetItemBinding<TBaseTargetItem, TTargetItemValue>> targetItemBindingSelector)
            where TBaseTargetItem : class
        {
            if (targetItemBindingSelector == null)
                throw new ArgumentNullException(nameof(targetItemBindingSelector));

            var targetItemBinding = targetItemBindingSelector(_targetItemReference).NotNull();

            return new SourceItemBindingBuilder<TSourceItem, TBaseTargetItem, TTargetItemValue>(
                _sourceItemReference,
                targetItemBinding,
                _bindingSet);
        }
    }
}
