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

namespace FlexiMvvm.Navigation
{
    /// <summary>
    /// Provides strategies for forward and backward navigation.
    /// </summary>
    public static class NavigationStrategy
    {
        /// <summary>
        /// Gets the forward navigation strategy.
        /// </summary>
        [Obsolete("NavigationStrategy.Forward will be removed soon. Use ViewControllerNavigationStrategy.Forward property instead.", true)]
        public static ForwardNavigationStrategy Forward { get; } = new ForwardNavigationStrategy();

        /// <summary>
        /// Gets the backward navigation strategy.
        /// </summary>
        [Obsolete("NavigationStrategy.Backward will be removed soon. Use ViewControllerNavigationStrategy.Backward property instead.", true)]
        public static BackwardNavigationStrategy Backward { get; } = new BackwardNavigationStrategy();
    }
}
