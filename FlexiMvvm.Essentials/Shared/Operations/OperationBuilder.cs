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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    internal class OperationBuilder : IOperationBuilder
    {
        [NotNull]
        private readonly OperationContext _context;
        [CanBeNull]
        private OperationNotificationBase _notification;
        [CanBeNull]
        private OperationConditionBase _condition;

        internal OperationBuilder([NotNull] OperationContext context)
        {
            _context = context;
        }

        public IOperationBuilder WithNotification(OperationNotificationBase notification)
        {
            _notification = notification;

            return this;
        }

        public IOperationBuilder WithCondition(OperationConditionBase condition)
        {
            _condition = condition;

            return this;
        }

        public IOperationResultBuilder<TResult> WithExpression<TResult>(Func<TResult> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return WithExpressionAsync(cancellationToken => Task.FromResult(expression()));
        }

        public IOperationResultBuilder<TResult> WithExpressionAsync<TResult>(Func<CancellationToken, Task<TResult>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var operation = new Operation<TResult>(expression, _notification, _condition);

            return new OperationResultBuilder<TResult>(_context, operation);
        }
    }
}
