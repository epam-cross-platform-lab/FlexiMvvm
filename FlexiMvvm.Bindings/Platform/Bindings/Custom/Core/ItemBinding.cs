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
using System.Diagnostics;
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core
{
    public abstract class ItemBinding<TItem, TValue> : IDisposable
        where TItem : class
    {
        [CanBeNull]
        private DelegatingLogger _delegatingLogger;

        protected ItemBinding(
            [NotNull] IItemReference<TItem> itemReference,
            [NotNull] Func<string> itemValuePathAccessor)
        {
            ItemReference = itemReference ?? throw new ArgumentNullException(nameof(itemReference));
            ItemValuePathAccessor = itemValuePathAccessor ?? throw new ArgumentNullException(nameof(itemValuePathAccessor));
        }

        internal event EventHandler<ValueChangedEventArgs<TValue>> ValueChanged;

        [NotNull]
        private protected IItemReference<TItem> ItemReference { get; set; }

        [NotNull]
        internal Func<string> ItemValuePathAccessor { get; }

        [NotNull]
        private DelegatingLogger DelegatingLogger => _delegatingLogger ?? (_delegatingLogger = new DelegatingLogger());

        protected internal virtual BindingMode BindingMode { get; } = BindingMode.TwoWay;

        [ContractAnnotation("=> true, item: notnull; => false, item: null")]
        protected internal virtual bool TryGetItem(out TItem item)
        {
            item = ItemReference.GetItem();

            return item != null;
        }

        protected internal virtual void SubscribeToEvents([NotNull] TItem item)
        {
        }

        protected internal virtual void UnsubscribeFromEvents([NotNull] TItem item)
        {
        }

        protected internal virtual bool TryGetValue([NotNull] TItem item, [CanBeNull] out TValue value)
        {
            value = default;

            return false;
        }

        protected internal virtual void SetValue([NotNull] TItem item, [CanBeNull] TValue value, bool silent)
        {
        }

        public void Dispose()
        {
            ItemReference.Dispose();
        }

        protected void RaiseValueChanged([CanBeNull] TValue value)
        {
            var args = new ValueChangedEventArgs<TValue>(value);

            ValueChanged?.Invoke(this, args);
        }

        internal string GetName()
        {
            return $"{LogFormatter.FormatTypeName<TItem>()}.{ItemValuePathAccessor()}";
        }

        [Conditional("DEBUG")]
        internal void SetLogger([NotNull] ILogger logger)
        {
            DelegatingLogger.Logger = logger;
        }

        [Conditional("DEBUG")]
        private protected void Log([CanBeNull] string message)
        {
            DelegatingLogger.Log(message);
        }
    }
}
