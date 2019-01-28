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

using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Target
{
    internal class TargetItemCustomValueBinding<TItem, TValue, TCustomValue> : TargetItemBinding<TItem, TCustomValue>, ITargetItemCommandListener<TItem>
        where TItem : class
    {
        [NotNull]
        private readonly TargetItemBinding<TItem, TValue> _targetItemBinding;
        private readonly TCustomValue _customValue;

        internal TargetItemCustomValueBinding(
            [NotNull] TargetItemBinding<TItem, TValue> targetItemBinding,
            [CanBeNull] TCustomValue customValue)
            : base(targetItemBinding.ItemReference, targetItemBinding.ItemValuePathAccessor)
        {
            _targetItemBinding = targetItemBinding;
            _customValue = customValue;
        }

        protected internal override BindingMode BindingMode { get; } = BindingMode.OneWayToSource;

        protected internal override void SubscribeToEvents(TItem item)
        {
            base.SubscribeToEvents(item);

            _targetItemBinding.SubscribeToEvents(item);
            _targetItemBinding.ValueChanged += CommandTriggerItemBinding_ValueChanged;
        }

        protected internal override void UnsubscribeFromEvents(TItem item)
        {
            base.UnsubscribeFromEvents(item);

            _targetItemBinding.UnsubscribeFromEvents(item);
            _targetItemBinding.ValueChanged -= CommandTriggerItemBinding_ValueChanged;
        }

        protected internal override bool TryGetValue(TItem item, out TCustomValue value)
        {
            value = _customValue;

            return true;
        }

        public void HandleCanExecuteCommandChanged(TItem item, bool canExecute)
        {
            if (_targetItemBinding is ITargetItemCommandListener<TItem> commandListener)
            {
                commandListener.HandleCanExecuteCommandChanged(item, canExecute);
            }
        }

        private void CommandTriggerItemBinding_ValueChanged([NotNull] object sender, [NotNull] ValueChangedEventArgs<TValue> e)
        {
            if (_targetItemBinding.ItemReference.TryGetItem(out var item) && TryGetValue(item, out var value))
            {
                RaiseValueChanged(value);
            }
        }
    }
}
