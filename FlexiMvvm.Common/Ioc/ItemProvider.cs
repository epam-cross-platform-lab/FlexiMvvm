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
using JetBrains.Annotations;

namespace FlexiMvvm.Ioc
{
    internal class ItemProvider
    {
        [NotNull]
        private readonly Func<object> _factory;
        private readonly Reuse _reuse;
        [CanBeNull]
        private Lazy<object> _lazyItem;

        internal ItemProvider([NotNull] Func<object> factory, Reuse reuse)
        {
            _factory = factory;
            _reuse = reuse;
        }

        [NotNull]
        private Lazy<object> LazyItem => _lazyItem ?? (_lazyItem = new Lazy<object>(() => _factory()));

        [CanBeNull]
        internal object Get()
        {
            return _reuse == Reuse.Singleton ? LazyItem.Value : _factory();
        }
    }
}
