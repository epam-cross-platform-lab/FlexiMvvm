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
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace FlexiMvvm.Diagnostics
{
    public static class LogFormatter
    {
        public static string FormatTypeName<T>()
        {
            return FormatTypeName(typeof(T));
        }

       public static string FormatTypeName<T>(WeakReference<T> weakReference)
            where T : class
        {
            if (weakReference == null)
                throw new ArgumentNullException(nameof(weakReference));

            if (weakReference.TryGetTarget(out var target))
            {
                return FormatTypeName(target);
            }

            return FormatTypeName<T>();
        }

        public static string FormatTypeName(object? value)
        {
            return value == null ? "null" : FormatTypeName(value.GetType());
        }

        public static string FormatTypeName(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var name = GetNameWithoutGenericArity(type);

            if (type.IsGenericType)
            {
                name += $"<{string.Join(", ", type.GetGenericArguments().Select(FormatTypeName))}>";
            }

            return name;
        }

        public static string FormatException(Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            if (ex.InnerException != null)
            {
                return $"{FormatExceptionMessage(ex)} ---> {FormatExceptionMessage(ex.InnerException)}";
            }

            return FormatExceptionMessage(ex);
        }

        public static string FormatExpression(LambdaExpression? expression)
        {
            return expression == null
                ? "[expression is null]"
                : Regex.Replace(expression.ToString(), "^.+=>.+\\.", string.Empty);
        }

        private static string GetNameWithoutGenericArity(Type type)
        {
            var name = type.Name;
            var index = name.IndexOf('`');

            return index == -1 ? name : name.Substring(0, index);
        }

        private static string FormatExceptionMessage(Exception ex)
        {
            return $"{ex.GetType().NotNull().FullName}: {ex.Message}";
        }
    }
}
