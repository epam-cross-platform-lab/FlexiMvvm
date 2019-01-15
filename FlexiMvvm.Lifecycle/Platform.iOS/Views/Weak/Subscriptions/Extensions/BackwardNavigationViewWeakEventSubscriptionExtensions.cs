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
using FlexiMvvm.ViewModels;
using FlexiMvvm.Weak.Subscriptions;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class BackwardNavigationViewWeakEventSubscriptionExtensions
    {
        [NotNull]
        public static IDisposable ResultSetWeakSubscribe(
            [NotNull] this IBackwardNavigationView<IViewModel> backwardNavigationView,
            [NotNull] EventHandler<ResultSetEventArgs> resultSetHandler)
        {
            if (backwardNavigationView == null)
                throw new ArgumentNullException(nameof(backwardNavigationView));
            if (resultSetHandler == null)
                throw new ArgumentNullException(nameof(resultSetHandler));

            return new WeakEventSubscription<IBackwardNavigationView<IViewModel>, ResultSetEventArgs>(
                backwardNavigationView,
                (eventSource, eventHandler) => eventSource.NotNull().ResultSet += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().ResultSet -= eventHandler,
                resultSetHandler);
        }
    }
}
