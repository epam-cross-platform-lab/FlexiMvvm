﻿// =========================================================================
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
using Android.Views;
using FlexiMvvm.Weak.Subscriptions;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class ViewWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable ClickWeakSubscribe(
            [NotNull] this View view,
            [NotNull] EventHandler clickHandler)
        {
            if (view == null)
                throw new ArgumentNullException(nameof(view));
            if (clickHandler == null)
                throw new ArgumentNullException(nameof(clickHandler));

            return new WeakEventSubscription<View>(
                view,
                (eventSource, eventHandler) => eventSource.NotNull().Click += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().Click -= eventHandler,
                clickHandler);
        }
    }
}
