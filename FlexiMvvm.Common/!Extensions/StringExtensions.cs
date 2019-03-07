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

namespace FlexiMvvm
{
    public static class StringExtensions
    {
        public static string SelfOrEmpty(this string? value)
        {
            return value ?? string.Empty;
        }

        public static string SelfOrDefaultIfNullOrEmpty(this string? value, string defaultValue)
        {
            if (defaultValue == null)
                throw new ArgumentNullException(nameof(defaultValue));

            return string.IsNullOrEmpty(value) ? defaultValue : value;
        }

        public static string SelfOrDefaultIfNullOrWhiteSpace(this string? value, string defaultValue)
        {
            if (defaultValue == null)
                throw new ArgumentNullException(nameof(defaultValue));

            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }
    }
}
