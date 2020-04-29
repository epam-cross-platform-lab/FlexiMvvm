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
using Android.Support.V4.Widget;
using FlexiMvvm.Bindings.Custom;

namespace FlexiMvvm.Bindings
{
    public static class SupportSwipeRefreshLayoutExtensions
    {
        public static TargetItemBinding<SwipeRefreshLayout, object> RefreshBinding(
            this IItemReference<SwipeRefreshLayout> swipeRefreshLayoutReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (swipeRefreshLayoutReference == null)
                throw new ArgumentNullException(nameof(swipeRefreshLayoutReference));

            return new TargetItemOneWayToSourceCustomBinding<SwipeRefreshLayout, object>(
                swipeRefreshLayoutReference,
                (swipeRefreshLayout, handler) => swipeRefreshLayout.Refresh += handler,
                (swipeRefreshLayout, handler) => swipeRefreshLayout.Refresh -= handler,
                (swipeRefreshLayout, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        swipeRefreshLayout.Enabled = canExecuteCommand;
                    }
                },
                swipeRefreshLayout => null,
                () => $"{nameof(SwipeRefreshLayout.Refresh)}");
        }

        public static TargetItemBinding<SwipeRefreshLayout, bool> RefreshingBinding(
            this IItemReference<SwipeRefreshLayout> swipeRefreshLayoutReference)
        {
            if (swipeRefreshLayoutReference == null)
                throw new ArgumentNullException(nameof(swipeRefreshLayoutReference));

            return new TargetItemOneWayCustomBinding<SwipeRefreshLayout, bool>(
                swipeRefreshLayoutReference,
                (swipeRefreshLayout, refreshing) => swipeRefreshLayout.Refreshing = refreshing,
                () => $"{nameof(SwipeRefreshLayout.Refreshing)}");
        }
    }
}
