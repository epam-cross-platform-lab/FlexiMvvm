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

namespace FlexiMvvm.Weak.Subscriptions
{
    public abstract class WeakEventSubscription<TEventSource, TEventArgs> : IDisposable
        where TEventSource : class
    {
        private readonly WeakReference<TEventSource> _eventSourceWeakReference;
        private readonly WeakEventHandler<TEventArgs> _weakEventHandler;

        protected WeakEventSubscription(TEventSource eventSource, EventHandler<TEventArgs> eventHandler)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));
            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            _eventSourceWeakReference = new WeakReference<TEventSource>(eventSource);
            _weakEventHandler = new WeakEventHandler<TEventArgs>(eventHandler);
        }

        protected void SubscribeToEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                SubscribeToEvent(eventSource);
            }
        }

        protected abstract void SubscribeToEvent(TEventSource eventSource);

        protected void UnsubscribeFromEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                UnsubscribeFromEvent(eventSource);
            }
        }

        protected abstract void UnsubscribeFromEvent(TEventSource eventSource);

        private bool TryInvokeEventHandler(object sender, TEventArgs args)
        {
            if (_weakEventHandler.TryGetTarget(out var target))
            {
                _weakEventHandler.Invoke(target, sender, args);

                return true;
            }

            return false;
        }

        protected void OnSourceEvent(object sender, TEventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (!TryInvokeEventHandler(sender, args))
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

    public abstract class WeakEventSubscription<TEventSource> : IDisposable
        where TEventSource : class
    {
        private readonly WeakReference<TEventSource> _eventSourceWeakReference;
        private readonly WeakEventHandler _weakEventHandler;

        protected WeakEventSubscription(TEventSource eventSource, EventHandler eventHandler)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));
            if (eventHandler == null)
                throw new ArgumentNullException(nameof(eventHandler));

            _eventSourceWeakReference = new WeakReference<TEventSource>(eventSource);
            _weakEventHandler = new WeakEventHandler(eventHandler);
        }

        protected void SubscribeToEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                SubscribeToEvent(eventSource);
            }
        }

        protected abstract void SubscribeToEvent(TEventSource eventSource);

        protected void UnsubscribeFromEvent()
        {
            if (_eventSourceWeakReference.TryGetTarget(out var eventSource))
            {
                UnsubscribeFromEvent(eventSource);
            }
        }

        protected abstract void UnsubscribeFromEvent(TEventSource eventSource);

        private bool TryInvokeEventHandler(object sender, EventArgs args)
        {
            if (_weakEventHandler.TryGetTarget(out var target))
            {
                _weakEventHandler.Invoke(target, sender, args);

                return true;
            }

            return false;
        }

        protected void OnSourceEvent(object sender, EventArgs args)
        {
            if (sender == null)
                throw new ArgumentNullException(nameof(sender));
            if (args == null)
                throw new ArgumentNullException(nameof(args));

            if (!TryInvokeEventHandler(sender, args))
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
}
