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
    public interface IOperationBuilder
    {
        [NotNull]
        IOperationBuilder WithNotification([CanBeNull] OperationNotification notification);

        [NotNull]
        IOperationBuilder WithCondition([CanBeNull] OperationCondition condition);

        [NotNull]
        IOperationHandlerBuilder<Void> WithExpression([NotNull] Action expression);

        [NotNull]
        IOperationHandlerBuilder<TResult> WithExpression<TResult>([NotNull] Func<TResult> expression);

        [NotNull]
        IOperationHandlerBuilder<Void> WithExpressionAsync([NotNull] Func<CancellationToken, Task> expression);

        [NotNull]
        IOperationHandlerBuilder<TResult> WithExpressionAsync<TResult>([NotNull] Func<CancellationToken, Task<TResult>> expression);
    }
}
