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
using System.Collections.Generic;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public class OperationContext
    {
        [CanBeNull]
        private IDictionary<string, object> _customData;

        public OperationContext([NotNull] object owner, [NotNull] OperationSharedContext sharedContext)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Shared = sharedContext ?? throw new ArgumentNullException(nameof(sharedContext));
        }

        [NotNull]
        public object Owner { get; }

        [NotNull]
        public OperationSharedContext Shared { get; }

        [NotNull]
        public IDictionary<string, object> CustomData => _customData ?? (_customData = new Dictionary<string, object>());

        public int AttemptCount { get; internal set; }
    }
}
