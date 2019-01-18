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
using FlexiMvvm.Weak.Delegates;
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions
{
    public abstract class WeakEventSubscription<TEventSource, TEventArgs> : IDisposable
        where TEventSource : class
    {
        [NotNull]
        private readonly WeakReference<TEventSource> _eventSourceWeakReference;
        [CanBeNull]
        private readonly WeakEventHandler<TEventArgs> _weakEventHandler;

        private protected WeakEventSubscription([NotNull] TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _eventSourceWeakReference = new WeakReference<TEventSource>(eventSource);
        }

        protected WeakEventSubscription([NotNull] TEventSource eventSource, [NotNull] EventHandler<TEventArgs> eventHandler)
            : this(eventSource)
        {
            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            _weakEventHandler = new WeakEventHandler<TEventArgs>(eventHandler);
        }

        protected void SubscribeToEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                SubscribeToEvent(eventSource);
            }
        }

        protected abstract void SubscribeToEvent([NotNull] TEventSource eventSource);

        protected void UnsubscribeFromEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                UnsubscribeFromEvent(eventSource);
            }
        }

        protected abstract void UnsubscribeFromEvent([NotNull] TEventSource eventSource);

        private protected virtual bool TryInvokeEventHandler([NotNull] object sender, [NotNull] TEventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (_weakEventHandler.NotNull().TryGetTarget(out var target))
            {
                _weakEventHandler.Invoke(target, sender, e);

                return true;
            }

            return false;
        }

        protected void OnSourceEvent([NotNull] object sender, [NotNull] TEventArgs e)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            if (!TryInvokeEventHandler(sender, e))
            {
                UnsubscribeFromEvent();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                UnsubscribeFromEvent();
            }
        }
    }

    public abstract class WeakEventSubscription<TEventSource> : WeakEventSubscription<TEventSource, EventArgs>
        where TEventSource : class
    {
        [NotNull]
        private readonly WeakEventHandler _weakEventHandler;

        protected WeakEventSubscription([NotNull] TEventSource eventSource, [NotNull] EventHandler eventHandler)
            : base(eventSource)
        {
            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            _weakEventHandler = new WeakEventHandler(eventHandler);
        }

        private protected override bool TryInvokeEventHandler(object sender, EventArgs e)
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
