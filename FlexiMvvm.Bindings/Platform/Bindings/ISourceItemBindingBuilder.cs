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

using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings
{
    public interface ISourceItemBindingBuilder<TSourceItem, in TTargetItemValue>
        where TSourceItem : class
    {
        [NotNull]
        ICompositeItemBindingBuilder<TSourceItem, TTargetItemValue> To<TSourceItemValue>(
            [CanBeNull] Expression<Func<TSourceItem, TSourceItemValue>> sourceItemValue);

        [NotNull]
        ICompositeItemCommandBindingBuilder<TSourceItem> To(
            [CanBeNull] Expression<Func<TSourceItem, System.Windows.Input.ICommand>> sourceItemValue);

        [NotNull]
        ICompositeItemCommandBindingBuilder<TSourceItem> To(
            [CanBeNull] Expression<Func<TSourceItem, FlexiMvvm.Commands.ICommand>> sourceItemValue);

        [NotNull]
        ICompositeItemCommandBindingBuilder<TSourceItem> To<TSourceItemValue>(
            [CanBeNull] Expression<Func<TSourceItem, FlexiMvvm.Commands.ICommand<TSourceItemValue>>> sourceItemValue);
    }
}
