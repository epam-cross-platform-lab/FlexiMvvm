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

namespace FlexiMvvm.Weak.Subscriptions
{
    public sealed class EventHandlerWeakEventSubscription<TEventSource, TEventArgs> : WeakEventSubscription<TEventSource, TEventArgs>
        where TEventSource : class
    {
        private readonly Action<TEventSource, EventHandler<TEventArgs>> _subscribeToEvent;
        private readonly Action<TEventSource, EventHandler<TEventArgs>> _unsubscribeFromEvent;

        public EventHandlerWeakEventSubscription(
            TEventSource eventSource,
            Action<TEventSource, EventHandler<TEventArgs>> subscribeToEvent,
            Action<TEventSource, EventHandler<TEventArgs>> unsubscribeFromEvent,
            EventHandler<TEventArgs> eventHandler)
            : base(eventSource, eventHandler)
        {
            if (subscribeToEvent == null)
                throw new ArgumentNullException(nameof(subscribeToEvent));
            if (unsubscribeFromEvent == null)
                throw new ArgumentNullException(nameof(unsubscribeFromEvent));

            _subscribeToEvent = subscribeToEvent;
            _unsubscribeFromEvent = unsubscribeFromEvent;

            SubscribeToEvent();
        }

        protected override void SubscribeToEvent(TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _subscribeToEvent(eventSource, OnSourceEvent);
        }

        protected override void UnsubscribeFromEvent(TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _unsubscribeFromEvent(eventSource, OnSourceEvent);
        }
    }

    public sealed class EventHandlerWeakEventSubscription<TEventSource> : WeakEventSubscription<TEventSource>
        where TEventSource : class
    {
        private readonly Action<TEventSource, EventHandler> _subscribeToEvent;
        private readonly Action<TEventSource, EventHandler> _unsubscribeFromEvent;

        public EventHandlerWeakEventSubscription(
            TEventSource eventSource,
            Action<TEventSource, EventHandler> subscribeToEvent,
            Action<TEventSource, EventHandler> unsubscribeFromEvent,
            EventHandler eventHandler)
            : base(eventSource, eventHandler)
        {
            if (subscribeToEvent == null)
                throw new ArgumentNullException(nameof(subscribeToEvent));
            if (unsubscribeFromEvent == null)
                throw new ArgumentNullException(nameof(unsubscribeFromEvent));

            _subscribeToEvent = subscribeToEvent;
            _unsubscribeFromEvent = unsubscribeFromEvent;

            SubscribeToEvent();
        }

        protected override void SubscribeToEvent(TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _subscribeToEvent(eventSource, OnSourceEvent);
        }

        protected override void UnsubscribeFromEvent(TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _unsubscribeFromEvent(eventSource, OnSourceEvent);
        }
    }
}
