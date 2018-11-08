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

namespace FlexiMvvm.Views
{
    public static class KeyboardHandlerWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable KeyboardWillShowWeakSubscribe(
            [NotNull] this KeyboardHandler keyboardHandler,
            [NotNull] EventHandler<KeyboardSizeChangedEventArgs> keyboardWillShowHandler)
        {
            if (keyboardHandler == null)
                throw new ArgumentNullException(nameof(keyboardHandler));
            if (keyboardWillShowHandler == null)
                throw new ArgumentNullException(nameof(keyboardWillShowHandler));

            return new WeakEventSubscription<KeyboardHandler, KeyboardSizeChangedEventArgs>(
                keyboardHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardWillShow += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardWillShow -= eventHandler,
                keyboardWillShowHandler);
        }

        [NotNull]
        public static IDisposable KeyboardDidShowWeakSubscribe(
            [NotNull] this KeyboardHandler keyboardHandler,
            [NotNull] EventHandler<KeyboardSizeChangedEventArgs> keyboardDidShowHandler)
        {
            if (keyboardHandler == null)
                throw new ArgumentNullException(nameof(keyboardHandler));
            if (keyboardDidShowHandler == null)
                throw new ArgumentNullException(nameof(keyboardDidShowHandler));

            return new WeakEventSubscription<KeyboardHandler, KeyboardSizeChangedEventArgs>(
                keyboardHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardDidShow += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardDidShow -= eventHandler,
                keyboardDidShowHandler);
        }

        [NotNull]
        public static IDisposable KeyboardWillHideWeakSubscribe(
            [NotNull] this KeyboardHandler keyboardHandler,
            [NotNull] EventHandler<KeyboardSizeChangedEventArgs> keyboardWillHideHandler)
        {
            if (keyboardHandler == null)
                throw new ArgumentNullException(nameof(keyboardHandler));
            if (keyboardWillHideHandler == null)
                throw new ArgumentNullException(nameof(keyboardWillHideHandler));

            return new WeakEventSubscription<KeyboardHandler, KeyboardSizeChangedEventArgs>(
                keyboardHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardWillHide += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardWillHide -= eventHandler,
                keyboardWillHideHandler);
        }

        [NotNull]
        public static IDisposable KeyboardDidHideWeakSubscribe(
            [NotNull] this KeyboardHandler keyboardHandler,
            [NotNull] EventHandler<KeyboardSizeChangedEventArgs> keyboardDidHideHandler)
        {
            if (keyboardHandler == null)
                throw new ArgumentNullException(nameof(keyboardHandler));
            if (keyboardDidHideHandler == null)
                throw new ArgumentNullException(nameof(keyboardDidHideHandler));

            return new WeakEventSubscription<KeyboardHandler, KeyboardSizeChangedEventArgs>(
                keyboardHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardDidHide += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().KeyboardDidHide -= eventHandler,
                keyboardDidHideHandler);
        }
    }
}
