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
    public static class IosViewWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable ResultSetWeakSubscribe(
            [NotNull] this IIosView<IViewModel> iosView,
            [NotNull] EventHandler<ViewModelResultSetEventArgs> resultSetHandler)
        {
            if (iosView == null)
                throw new ArgumentNullException(nameof(iosView));
            if (resultSetHandler == null)
                throw new ArgumentNullException(nameof(resultSetHandler));

            return new WeakEventSubscription<IIosView<IViewModel>, ViewModelResultSetEventArgs>(
                iosView,
                (eventSource, eventHandler) => eventSource.NotNull().ResultSet += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().ResultSet -= eventHandler,
                resultSetHandler);
        }
    }
}
