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
using FlexiMvvm.Bindings.Custom.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom
{
    public class TargetItemOneWayToSourceCustomBinding<TItem, TValue, TEventArgs>
        : TargetItemBinding<TItem, TValue>, ITargetItemCommandListener<TItem>
        where TItem : class
    {
        [NotNull]
        private readonly Action<TItem, EventHandler<TEventArgs>> _subscribeToEvent;
        [NotNull]
        private readonly Action<TItem, EventHandler<TEventArgs>> _unsubscribeFromEvent;
        [NotNull]
        private readonly Action<TItem, bool> _handleCanExecuteCommandChanged;
        [NotNull]
        private readonly Func<TItem, TEventArgs, TValue> _getValue;
        [CanBeNull]
        private readonly Func<TItem, TEventArgs, bool> _raiseValueChanged;

        public TargetItemOneWayToSourceCustomBinding(
            [NotNull] IItemReference<TItem> itemReference,
            [NotNull] Action<TItem, EventHandler<TEventArgs>> subscribeToEvent,
            [NotNull] Action<TItem, EventHandler<TEventArgs>> unsubscribeFromEvent,
            [NotNull] Action<TItem, bool> handleCanExecuteCommandChanged,
            [NotNull] Func<TItem, TEventArgs, TValue> getValue,
            [NotNull] Func<string> itemValuePathAccessor)
            : base(
                itemReference,
                itemValuePathAccessor)
        {
            _subscribeToEvent = subscribeToEvent ?? throw new ArgumentNullException(nameof(subscribeToEvent));
            _unsubscribeFromEvent = unsubscribeFromEvent ?? throw new ArgumentNullException(nameof(unsubscribeFromEvent));
            _handleCanExecuteCommandChanged = handleCanExecuteCommandChanged ?? throw new ArgumentNullException(nameof(handleCanExecuteCommandChanged));
            _getValue = getValue ?? throw new ArgumentNullException(nameof(getValue));
        }

        public TargetItemOneWayToSourceCustomBinding(
            [NotNull] IItemReference<TItem> itemReference,
            [NotNull] Action<TItem, EventHandler<TEventArgs>> subscribeToEvent,
            [NotNull] Action<TItem, EventHandler<TEventArgs>> unsubscribeFromEvent,
            [NotNull] Action<TItem, bool> handleCanExecuteCommandChanged,
            [NotNull] Func<TItem, TEventArgs, TValue> getValue,
            [NotNull] Func<TItem, TEventArgs, bool> raiseValueChanged,
            [NotNull] Func<string> itemValuePathAccessor)
            : this(
                itemReference,
                subscribeToEvent,
                unsubscribeFromEvent,
                handleCanExecuteCommandChanged,
                getValue,
                itemValuePathAccessor)
        {
            _raiseValueChanged = raiseValueChanged ?? throw new ArgumentNullException(nameof(raiseValueChanged));
        }

        protected internal override BindingMode BindingMode => BindingMode.OneWayToSource;

        protected internal override void SubscribeToEvents(TItem item)
        {
            _subscribeToEvent(item, Item_ValueChanged);
        }

        protected internal override void UnsubscribeFromEvents(TItem item)
        {
            _unsubscribeFromEvent(item, Item_ValueChanged);
        }

        protected internal override bool TryGetValue(TItem item, out TValue value)
        {
            value = _getValue(item, default);

            return true;
        }

        private bool TryGetValue([NotNull] TItem item, [NotNull] TEventArgs eventArgs, [CanBeNull] out TValue value)
        {
            value = _getValue(item, eventArgs);

            return true;
        }

        public void HandleCanExecuteCommandChanged(TItem item, bool canExecute)
        {
            _handleCanExecuteCommandChanged(item, canExecute);
        }

        private void Item_ValueChanged([NotNull] object sender, [NotNull] TEventArgs e)
        {
            var item = (TItem)sender;

            if (_raiseValueChanged == null || _raiseValueChanged(item, e))
            {
                if (TryGetValue(item, e, out var value))
                {
                    RaiseValueChanged(value);
                }
            }
        }
    }

    public class TargetItemOneWayToSourceCustomBinding<TItem, TValue> : TargetItemOneWayToSourceCustomBinding<TItem, TValue, EventArgs>
        where TItem : class
    {
        public TargetItemOneWayToSourceCustomBinding(
            [NotNull] IItemReference<TItem> itemReference,
            [NotNull] Action<TItem, EventHandler> subscribeToEvent,
            [NotNull] Action<TItem, EventHandler> unsubscribeFromEvent,
            [NotNull] Action<TItem, bool> handleCanExecuteCommandChanged,
            [NotNull] Func<TItem, TValue> getValue,
            [NotNull] Func<string> itemValuePathAccessor)
            : base(
                itemReference,
                subscribeToEvent != null ? (item, eventHandler) => subscribeToEvent(item, eventHandler.NotNull().ToNonGeneric()) : (Action<TItem, EventHandler<EventArgs>>)null,
                unsubscribeFromEvent != null ? (item, eventHandler) => unsubscribeFromEvent(item, eventHandler.NotNull().ToNonGeneric()) : (Action<TItem, EventHandler<EventArgs>>)null,
                handleCanExecuteCommandChanged,
                getValue != null ? (item, eventArgs) => getValue(item) : (Func<TItem, EventArgs, TValue>)null,
                itemValuePathAccessor)
        {
        }
    }
}
