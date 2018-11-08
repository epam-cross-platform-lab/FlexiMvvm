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
    public static class UITextFieldWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable EditingChangedWeakSubscribe(
            [NotNull] this UITextField textField,
            [NotNull] EventHandler editingChangedHandler)
        {
            if (textField == null)
                throw new ArgumentNullException(nameof(textField));
            if (editingChangedHandler == null)
                throw new ArgumentNullException(nameof(editingChangedHandler));

            return new WeakEventSubscription<UITextField>(
                textField,
                (eventSource, eventHandler) => eventSource.NotNull().EditingChanged += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().EditingChanged -= eventHandler,
                editingChangedHandler);
        }

        [NotNull]
        public static IDisposable EndedWeakSubscribe(
            [NotNull] this UITextField textField,
            [NotNull] EventHandler endedHandler)
        {
            if (textField == null)
                throw new ArgumentNullException(nameof(textField));
            if (endedHandler == null)
                throw new ArgumentNullException(nameof(endedHandler));

            return new WeakEventSubscription<UITextField>(
                textField,
                (eventSource, eventHandler) => eventSource.NotNull().Ended += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().Ended -= eventHandler,
                endedHandler);
        }

        [NotNull]
        public static IDisposable StartedWeakSubscribe(
            [NotNull] this UITextField textField,
            [NotNull] EventHandler startedHandler)
        {
            if (textField == null)
                throw new ArgumentNullException(nameof(textField));
            if (startedHandler == null)
                throw new ArgumentNullException(nameof(startedHandler));

            return new WeakEventSubscription<UITextField>(
                textField,
                (eventSource, eventHandler) => eventSource.NotNull().Started += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().Started -= eventHandler,
                startedHandler);
        }
    }
}
