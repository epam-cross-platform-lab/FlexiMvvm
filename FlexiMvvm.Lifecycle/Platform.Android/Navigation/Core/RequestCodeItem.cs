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

namespace FlexiMvvm.Navigation.Core
{
    internal class RequestCodeItem
    {
        internal const int DefaultValue = 9;
        internal const int MaxValue = 20;

        internal RequestCodeItem(int value, [NotNull] Type targetViewType, [NotNull] IHandleViewModelResultProxy handleViewModelResultProxy)
        {
            Value = value;
            TargetViewType = targetViewType;
            HandleViewModelResultProxy = handleViewModelResultProxy;
        }

        internal int Value { get; }

        [NotNull]
        internal Type TargetViewType { get; }

        [NotNull]
        internal IHandleViewModelResultProxy HandleViewModelResultProxy { get; }
    }
}
