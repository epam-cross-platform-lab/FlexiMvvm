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
    internal class OperationBuilder : IOperationBuilder
    {
        [NotNull]
        private readonly OperationContext _context;
        [CanBeNull]
        private OperationNotification _notification;
        [CanBeNull]
        private OperationCondition _condition;

        internal OperationBuilder([NotNull] OperationContext context)
        {
            _context = context;
        }

        public IOperationBuilder WithNotification(OperationNotification notification)
        {
            _notification = notification;

            return this;
        }

        public IOperationBuilder WithCondition(OperationCondition condition)
        {
            _condition = condition;

            return this;
        }

        public IOperationHandlerBuilder<Void> WithExpression(Action expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return WithExpression(() =>
            {
                expression();

                return default(Void);
            });
        }

        public IOperationHandlerBuilder<TResult> WithExpression<TResult>(Func<TResult> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return WithExpressionAsync(async cancellationToken =>
            {
                await Task.Yield();

                return expression();
            });
        }

        public IOperationHandlerBuilder<Void> WithExpressionAsync(Func<CancellationToken, Task> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            return WithExpressionAsync(async cancellationToken =>
            {
                await expression(cancellationToken).NotNull();

                return default(Void);
            });
        }

        public IOperationHandlerBuilder<TResult> WithExpressionAsync<TResult>(Func<CancellationToken, Task<TResult>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var operation = new Operation<TResult>(expression, _notification, _condition);

            return new OperationHandlerBuilder<TResult>(_context, operation);
        }
    }
}
