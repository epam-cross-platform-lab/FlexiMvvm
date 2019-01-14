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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public static class OperationBuilderExtensions
    {
        [NotNull]
        public static IOperationHandlerBuilder<Void> WithExpression(
            [NotNull] this IOperationBuilder operationBuilder,
            [NotNull] Action expression)
        {
            if (operationBuilder == null)
                throw new ArgumentNullException(nameof(operationBuilder));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return operationBuilder.WithExpression(() =>
            {
                expression();

                return default(Void);
            });
        }

        [NotNull]
        public static IOperationHandlerBuilder<Void> WithExpressionAsync(
            [NotNull] this IOperationBuilder operationBuilder,
            [NotNull] Func<CancellationToken, Task> expression)
        {
            if (operationBuilder == null)
                throw new ArgumentNullException(nameof(operationBuilder));
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return operationBuilder.WithExpressionAsync(async cancellationToken =>
            {
                await expression(cancellationToken).NotNull();

                return default(Void);
            });
        }
    }
}
