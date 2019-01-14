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
using System.Collections.Specialized;
using FlexiMvvm.Weak.Delegates;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions
{
    public class NotifyCollectionChangedWeakEventSubscription : WeakEventSubscriptionBase<INotifyCollectionChanged, NotifyCollectionChangedEventArgs>
    {
        [NotNull]
        private readonly Action<INotifyCollectionChanged, NotifyCollectionChangedEventHandler> _subscribeToEvent;
        [NotNull]
        private readonly Action<INotifyCollectionChanged, NotifyCollectionChangedEventHandler> _unsubscribeFromEvent;
        [NotNull]
        private readonly WeakEventHandler<NotifyCollectionChangedEventArgs> _weakEventHandler;

        public NotifyCollectionChangedWeakEventSubscription(
            [NotNull] INotifyCollectionChanged eventSource,
            [NotNull] Action<INotifyCollectionChanged, NotifyCollectionChangedEventHandler> subscribeToEvent,
            [NotNull] Action<INotifyCollectionChanged, NotifyCollectionChangedEventHandler> unsubscribeFromEvent,
            [NotNull] EventHandler<NotifyCollectionChangedEventArgs> eventHandler)
            : base(eventSource)
        {
            if (subscribeToEvent == null)
                throw new ArgumentNullException(nameof(subscribeToEvent));
            if (unsubscribeFromEvent == null)
                throw new ArgumentNullException(nameof(unsubscribeFromEvent));
            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            _subscribeToEvent = subscribeToEvent;
            _unsubscribeFromEvent = unsubscribeFromEvent;
            _weakEventHandler = new WeakEventHandler<NotifyCollectionChangedEventArgs>(eventHandler);

            SubscribeToEvent();
        }

        protected override void SubscribeToEvent(INotifyCollectionChanged eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _subscribeToEvent(eventSource, OnSourceEvent);
        }

        protected override void UnsubscribeFromEvent(INotifyCollectionChanged eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _unsubscribeFromEvent(eventSource, OnSourceEvent);
        }

        protected override bool TryInvokeEventHandler(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (_weakEventHandler.TryGetTarget(out var target))
            {
                _weakEventHandler.Invoke(target, sender, e);

                return true;
            }

            return false;
        }
    }
}
