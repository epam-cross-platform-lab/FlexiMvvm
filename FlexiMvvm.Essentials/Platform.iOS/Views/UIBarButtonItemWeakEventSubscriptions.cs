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
using FlexiMvvm.Weak.Subscriptions;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Views
{
    public static class UIBarButtonItemWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable ClickedWeakSubscribe(
            [NotNull] this UIBarButtonItem buttonItem,
            [NotNull] EventHandler clickedHandler)
        {
            if (buttonItem == null)
                throw new ArgumentNullException(nameof(buttonItem));
            if (clickedHandler == null)
                throw new ArgumentNullException(nameof(clickedHandler));

            return new WeakEventSubscription<UIBarButtonItem>(
                buttonItem,
                (eventSource, eventHandler) => eventSource.NotNull().Clicked += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().Clicked -= eventHandler,
                clickedHandler);
        }
    }
}
