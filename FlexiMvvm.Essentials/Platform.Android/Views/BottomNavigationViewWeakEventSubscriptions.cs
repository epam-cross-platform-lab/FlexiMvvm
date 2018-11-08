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
using Android.Support.Design.Widget;
using FlexiMvvm.Weak.Subscriptions;
using JetBrains.Annotations;

namespace FlexiMvvm.Views
{
    public static class BottomNavigationViewWeakEventSubscriptions
    {
        [NotNull]
        public static IDisposable NavigationItemSelectedWeakSubscribe(
            this BottomNavigationView bottomNavigationView,
            EventHandler<BottomNavigationView.NavigationItemSelectedEventArgs> navigationItemSelectedHandler)
        {
            if (bottomNavigationView == null)
                throw new ArgumentNullException(nameof(bottomNavigationView));
            if (navigationItemSelectedHandler == null)
                throw new ArgumentNullException(nameof(navigationItemSelectedHandler));

            return new WeakEventSubscription<BottomNavigationView, BottomNavigationView.NavigationItemSelectedEventArgs>(
                bottomNavigationView,
                (eventSource, eventHandler) => eventSource.NotNull().NavigationItemSelected += eventHandler,
                (eventSource, eventHandler) => eventSource.NotNull().NavigationItemSelected -= eventHandler,
                navigationItemSelectedHandler);
        }
    }
}
