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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using JetBrains.Annotations;

namespace FlexiMvvm.Bindings.Custom.Core
{
    internal static class ItemValueExpressionParser
    {
        [NotNull]
        [ItemNotNull]
        internal static NestedValueAccessor[] Parse([CanBeNull] LambdaExpression itemValue)
        {
            var nestedValuesAccessors = new Stack<NestedValueAccessor>();

            if (itemValue != null)
            {
                var expression = itemValue.Body;

                while (true)
                {
                    if (expression is MemberExpression propertyExpression)
                    {
                        expression = ParseProperty(propertyExpression, nestedValuesAccessors);
                    }
                    else if (expression is MethodCallExpression indexerExpression)
                    {
                        expression = ParseIndexer(indexerExpression, nestedValuesAccessors);
                    }
                    else if (expression is ParameterExpression && nestedValuesAccessors.Count > 0)
                    {
                        break;
                    }
                    else
                    {
                        throw new ArgumentException($"\"{expression}\" is not supported.");
                    }
                }
            }

            return nestedValuesAccessors.ToArray();
        }

        [NotNull]
        private static Expression ParseProperty(
            [NotNull] MemberExpression propertyExpression,
            [NotNull] Stack<NestedValueAccessor> nestedValuesAccessors)
        {
            var property = (PropertyInfo)propertyExpression.Member;

            nestedValuesAccessors.Push(new NestedValueAccessor(property, null));

            return propertyExpression.Expression.NotNull();
        }

        [NotNull]
        private static Expression ParseIndexer(
            [NotNull] MethodCallExpression indexerExpression,
            [NotNull] Stack<NestedValueAccessor> nestedValuesAccessors)
        {
            var indexerOwner = indexerExpression.Method.ReflectedType.NotNull();
            var indexerName = indexerExpression.Method.Name.Substring("get_".Length);
            var indexerReturnType = indexerExpression.Method.ReturnType;
            var indexerParametersTypes = GetMethodParametersTypes(indexerExpression.Method);
            var indexer = indexerOwner.GetProperty(indexerName, indexerReturnType, indexerParametersTypes).NotNull();
            var indexerParameters = GetIndexerParameters(indexerExpression.Arguments);

            nestedValuesAccessors.Push(new NestedValueAccessor(indexer, indexerParameters));

            return indexerExpression.Object.NotNull();
        }

        [NotNull]
        private static Type[] GetMethodParametersTypes(
            [NotNull] MethodInfo method)
        {
            var parameters = method.GetParameters();
            var parametersTypes = new Type[parameters.Length];

            for (var i = 0; i < parameters.Length; i++)
            {
                parametersTypes[i] = parameters[i].NotNull().ParameterType;
            }

            return parametersTypes;
        }

        [NotNull]
        private static object[] GetIndexerParameters(
            [NotNull] ReadOnlyCollection<Expression> arguments)
        {
            var indexerParameters = new object[arguments.Count];

            for (var i = 0; i < arguments.Count; i++)
            {
                indexerParameters[i] = ((ConstantExpression)arguments[i].NotNull()).Value;
            }

            return indexerParameters;
        }
    }
}
