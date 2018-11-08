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
using System.Linq.Expressions;
using FlexiMvvm.Bindings.Custom.Core;
using FlexiMvvm.Bindings.Custom.Core.Source;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Builders
{
    internal class SourceItemBindingBuilder<TSourceItem, TTargetItem, TTargetItemValue> : ISourceItemBindingBuilder<TSourceItem, TTargetItemValue>
        where TSourceItem : class
        where TTargetItem : class
    {
        [NotNull]
        private readonly ItemReference<TSourceItem> _sourceItemReference;
        [NotNull]
        private readonly TargetItemBinding<TTargetItem, TTargetItemValue> _targetItemBinding;
        [NotNull]
        private readonly BindingSet<TSourceItem> _bindingSet;

        internal SourceItemBindingBuilder(
            [NotNull] ItemReference<TSourceItem> sourceItemReference,
            [NotNull] TargetItemBinding<TTargetItem, TTargetItemValue> targetItemBinding,
            [NotNull] BindingSet<TSourceItem> bindingSet)
        {
            _sourceItemReference = sourceItemReference;
            _targetItemBinding = targetItemBinding;
            _bindingSet = bindingSet;
        }

        public ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> To<TSourceItemValue>(
            Expression<Func<TSourceItem, TSourceItemValue>> sourceItemValue)
        {
            SourceItemBinding<TSourceItem, TSourceItemValue> sourceItemBinding;

            try
            {
                var sourceItemValueAccessor = new ItemValueAccessor<TSourceItem, TSourceItemValue>(sourceItemValue);
                sourceItemBinding = new SourceItemPropertyBinding<TSourceItem, TSourceItemValue>(
                    _sourceItemReference,
                    sourceItemValueAccessor);
            }
            catch (Exception ex)
            {
                sourceItemBinding = new SourceItemEmptyBinding<TSourceItem, TSourceItemValue>(
                    _sourceItemReference,
                    typeof(SourceItemPropertyBinding<TSourceItem, TSourceItemValue>),
                    sourceItemValue,
                    ex);
            }

            return new CompositeItemBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                _targetItemBinding,
                _bindingSet);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> To(
            Expression<Func<TSourceItem, System.Windows.Input.ICommand>> sourceItemValue)
        {
            var sourceItemValueAccessor = new ItemValueAccessor<TSourceItem, System.Windows.Input.ICommand>(sourceItemValue);
            var sourceItemBinding = new SourceItemCommandBinding<TSourceItem, object>(
                _sourceItemReference,
                sourceItemValueAccessor);

            return new CompositeItemCommandBindingBuilder<TSourceItem, object, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                _targetItemBinding,
                _bindingSet);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> To(
            Expression<Func<TSourceItem, FlexiMvvm.Commands.ICommand>> sourceItemValue)
        {
            var sourceItemValueAccessor = new ItemValueAccessor<TSourceItem, System.Windows.Input.ICommand>(sourceItemValue);
            var sourceItemBinding = new SourceItemCommandBinding<TSourceItem, object>(
                _sourceItemReference,
                sourceItemValueAccessor);

            return new CompositeItemCommandBindingBuilder<TSourceItem, object, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                _targetItemBinding,
                _bindingSet);
        }

        public ICompositeItemCommandBindingBuilder<TSourceItem> To<TSourceItemValue>(
            Expression<Func<TSourceItem, FlexiMvvm.Commands.ICommand<TSourceItemValue>>> sourceItemValue)
        {
            var sourceItemValueAccessor = new ItemValueAccessor<TSourceItem, System.Windows.Input.ICommand>(sourceItemValue);
            var sourceItemBinding = new SourceItemCommandBinding<TSourceItem, TSourceItemValue>(
                _sourceItemReference,
                sourceItemValueAccessor);

            return new CompositeItemCommandBindingBuilder<TSourceItem, TSourceItemValue, TTargetItem, TTargetItemValue>(
                sourceItemBinding,
                _targetItemBinding,
                _bindingSet);
        }
    }
}
