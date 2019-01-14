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
using FlexiMvvm.Bindings.Custom;
using JetBrains.Annotations;
using UIKit;

namespace FlexiMvvm.Bindings
{
    public static class UIRefreshControlBindings
    {
        [NotNull]
        public static TargetItemBinding<UIRefreshControl, bool> BeginRefreshingBinding(
            [NotNull] this IItemReference<UIRefreshControl> refreshControlReference)
        {
            if (refreshControlReference == null)
                throw new ArgumentNullException(nameof(refreshControlReference));

            return new TargetItemOneWayCustomBinding<UIRefreshControl, bool>(
                refreshControlReference,
                (refreshControl, refreshing) =>
                {
                    if (refreshing && !refreshControl.NotNull().Refreshing)
                    {
                        refreshControl.BeginRefreshing();
                    }
                },
                () => "BeginRefreshing");
        }

        [NotNull]
        public static TargetItemBinding<UIRefreshControl, bool> EndRefreshingBinding(
            [NotNull] this IItemReference<UIRefreshControl> refreshControlReference)
        {
            if (refreshControlReference == null)
                throw new ArgumentNullException(nameof(refreshControlReference));

            return new TargetItemOneWayCustomBinding<UIRefreshControl, bool>(
                refreshControlReference,
                (refreshControl, refreshing) =>
                {
                    if (!refreshing && refreshControl.NotNull().Refreshing)
                    {
                        refreshControl.EndRefreshing();
                    }
                },
                () => "EndRefreshing");
        }
    }
}
