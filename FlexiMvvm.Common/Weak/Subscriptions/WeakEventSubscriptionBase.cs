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
using JetBrains.Annotations;

namespace FlexiMvvm.Weak.Subscriptions
{
    public abstract class WeakEventSubscriptionBase<TEventSource, TEventArgs> : IDisposable
        where TEventSource : class
    {
        [NotNull]
        private readonly WeakReference<TEventSource> _eventSourceWeakReference;

        protected WeakEventSubscriptionBase([NotNull] TEventSource eventSource)
        {
            if (eventSource == null)
                throw new ArgumentNullException(nameof(eventSource));

            _eventSourceWeakReference = new WeakReference<TEventSource>(eventSource);
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

        protected abstract bool TryInvokeEventHandler([NotNull] object sender, [NotNull] TEventArgs e);

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
}
