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

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using FlexiMvvm.Exceptions;
using FlexiMvvm.Formatters;

namespace FlexiMvvm
{
    public static class ObjectExtensions
    {
        [DebuggerStepThrough]
        [return: NotNull]
        public static T NotNull<T>(
            [AllowNull] this T value,
            [CallerMemberName] string? memberName = null,
            [CallerFilePath] string? filePath = null,
            [CallerLineNumber] int lineNumber = 0)
        {
            if (value != null)
            {
                return value;
            }

            throw new AssertionException($"Value of type '{TypeFormatter.FormatName<T>()}' is null at {memberName}, {filePath}:{lineNumber}");
        }
    }
}
