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
using JetBrains.Annotations;

namespace FlexiMvvm.Ioc
{
    internal class ItemProvider
    {
        [NotNull]
        private readonly Func<object> _factory;
        private readonly Reuse _reuse;
        [CanBeNull]
        private object _instance;

        internal ItemProvider([NotNull] Func<object> factory, Reuse reuse)
        {
            _factory = factory;
            _reuse = reuse;
        }

        [CanBeNull]
        internal object Get()
        {
            object instance;

            if (_reuse == Reuse.Singleton)
            {
                _instance = _instance ?? _factory();
                instance = _instance;
            }
            else
            {
                instance = _factory();
            }

            return instance;
        }
    }
}
