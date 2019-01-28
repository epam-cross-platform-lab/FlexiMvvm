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

namespace FlexiMvvm.ValueConverters.Core
{
    internal static class ValueConverterProvider
    {
        [CanBeNull]
        private static Dictionary<Type, IValueConverter> _valueConverters;

        [NotNull]
        private static Dictionary<Type, IValueConverter> ValueConverters => _valueConverters ?? (_valueConverters = new Dictionary<Type, IValueConverter>());

        [NotNull]
        internal static TValueConverter Get<TValueConverter>()
            where TValueConverter : IValueConverter, new()
        {
            return (TValueConverter)ValueConverters.GetOrAdd(typeof(TValueConverter), _ => new TValueConverter()).NotNull();
        }
    }
}
