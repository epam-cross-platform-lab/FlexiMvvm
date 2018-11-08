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

using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Target
{
    internal class TargetItemCommandBinding<TCommandTriggerItem, TCommandTriggerItemValue, TCommandParameterItem, TCommandPatameterItemValue>
        : TargetItemBinding<TCommandTriggerItem, TCommandPatameterItemValue>, ITargetItemCommandListener<TCommandTriggerItem>
        where TCommandTriggerItem : class
        where TCommandParameterItem : class
    {
        [NotNull]
        private readonly TargetItemBinding<TCommandTriggerItem, TCommandTriggerItemValue> _commandTriggerItemBinding;
        [NotNull]
        private readonly TargetItemBinding<TCommandParameterItem, TCommandPatameterItemValue> _commandParameterItemBinding;

        internal TargetItemCommandBinding(
            [NotNull] TargetItemBinding<TCommandTriggerItem, TCommandTriggerItemValue> commandTriggerItemBinding,
            [NotNull] TargetItemBinding<TCommandParameterItem, TCommandPatameterItemValue> commandParameterItemBinding)
            : base(commandTriggerItemBinding.GetItemReference(), commandTriggerItemBinding.ItemValuePathAccessor)
        {
            _commandTriggerItemBinding = commandTriggerItemBinding;
            _commandParameterItemBinding = commandParameterItemBinding;
        }

        protected internal override BindingMode BindingMode { get; } = BindingMode.OneWayToSource;

        protected internal override void SubscribeToEvents(TCommandTriggerItem item)
        {
            base.SubscribeToEvents(item);

            _commandTriggerItemBinding.SubscribeToEvents(item);
            _commandTriggerItemBinding.ValueChanged += CommandTriggerItemBinding_ValueChanged;
        }

        protected internal override void UnsubscribeFromEvents(TCommandTriggerItem item)
        {
            base.UnsubscribeFromEvents(item);

            _commandTriggerItemBinding.UnsubscribeFromEvents(item);
            _commandTriggerItemBinding.ValueChanged -= CommandTriggerItemBinding_ValueChanged;
        }

        protected internal override bool TryGetValue(TCommandTriggerItem item, out TCommandPatameterItemValue value)
        {
            value = default;

            return _commandParameterItemBinding.TryGetItem(out var parameterItem) && _commandParameterItemBinding.TryGetValue(parameterItem, out value);
        }

        public void HandleCanExecuteCommandChanged(TCommandTriggerItem item, bool canExecute)
        {
            if (_commandTriggerItemBinding is ITargetItemCommandListener<TCommandTriggerItem> commandListener)
            {
                commandListener.HandleCanExecuteCommandChanged(item, canExecute);
            }
        }

        private void CommandTriggerItemBinding_ValueChanged([NotNull] object sender, [NotNull] ValueChangedEventArgs<TCommandTriggerItemValue> e)
        {
            var item = (TCommandTriggerItem)sender;

            if (TryGetValue(item, out var value))
            {
                RaiseValueChanged(value);
            }
        }
    }
}
