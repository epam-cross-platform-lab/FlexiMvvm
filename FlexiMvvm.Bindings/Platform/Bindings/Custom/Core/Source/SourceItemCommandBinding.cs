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
using System.Windows.Input;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core.Source
{
    internal class SourceItemCommandBinding<TItem, TCommandParameter> : SourceItemBinding<TItem, TCommandParameter>
        where TItem : class
    {
        [NotNull]
        private readonly ItemValueAccessor<TItem, ICommand> _itemValueAccessor;

        internal SourceItemCommandBinding(
            [NotNull] ItemReference<TItem> itemReference,
            [NotNull] ItemValueAccessor<TItem, ICommand> itemValueAccessor)
            : base(itemReference, itemValueAccessor.ToString)
        {
            _itemValueAccessor = itemValueAccessor;
        }

        internal event EventHandler CanExecuteChanged;

        protected internal override BindingMode BindingMode => BindingMode.OneWayToSource;

        protected internal override bool TryGetItem(out TItem item)
        {
            return base.TryGetItem(out item) && _itemValueAccessor.TryGetValueOwnerItem(item, out _);
        }

        protected internal override void SubscribeToEvents(TItem item)
        {
            base.SubscribeToEvents(item);

            if (TryGetCommand(item, out var command))
            {
                command.CanExecuteChanged += Command_CanExecuteChanged;
            }
        }

        protected internal override void UnsubscribeFromEvents(TItem item)
        {
            base.UnsubscribeFromEvents(item);

            if (TryGetCommand(item, out var command))
            {
                command.CanExecuteChanged -= Command_CanExecuteChanged;
            }
        }

        protected internal override void SetValue(TItem item, TCommandParameter value, bool silent)
        {
            if (TryGetCommand(item, out var command) && command.CanExecute(value))
            {
                command.Execute(value);
            }
        }

        internal bool CanExecute([NotNull] TItem item, [CanBeNull] TCommandParameter value)
        {
            return TryGetCommand(item, out var command) && command.CanExecute(value);
        }

        private bool TryGetCommand([NotNull] TItem item, out ICommand command)
        {
            return _itemValueAccessor.TryGetValue(item, out command);
        }

        protected virtual void OnCanExecuteCommandChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Command_CanExecuteChanged(object sender, EventArgs e)
        {
            OnCanExecuteCommandChanged();
        }
    }
}
