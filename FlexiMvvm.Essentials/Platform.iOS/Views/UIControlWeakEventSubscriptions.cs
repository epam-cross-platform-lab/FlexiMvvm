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
using FlexiMvvm.Weak.Subscriptions;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class UIControlWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable TouchUpInsideWeakSubscribe(
            [NotNull] this UIControl control,
            [NotNull] EventHandler touchUpInsideHandler)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (touchUpInsideHandler == null)
                throw new ArgumentNullException(nameof(touchUpInsideHandler));

            return new WeakEventSubscription<UIControl>(
                control,
                (eventSource, eventHandler) => eventSource.NotNull().TouchUpInside += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().TouchUpInside -= eventHandler,
                touchUpInsideHandler);
        }

        [NotNull]
        public static IDisposable ValueChangedWeakSubscribe(
            [NotNull] this UIControl control,
            [NotNull] EventHandler valueChangedHandler)
        {
            if (control == null)
                throw new ArgumentNullException(nameof(control));
            if (valueChangedHandler == null)
                throw new ArgumentNullException(nameof(valueChangedHandler));

            return new WeakEventSubscription<UIControl>(
                control,
                (eventSource, eventHandler) => eventSource.NotNull().ValueChanged += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().ValueChanged -= eventHandler,
                valueChangedHandler);
        }
    }
}
