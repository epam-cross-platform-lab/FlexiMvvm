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
    internal class OperationHandlerBuilder<TResult> : IOperationHandlerBuilder<TResult>
    {
        [NotNull]
        private readonly Operation<TResult> _operation;
        [NotNull]
        private readonly OperationContext _context;

        internal OperationHandlerBuilder(
            [NotNull] OperationContext context,
            [NotNull] Operation<TResult> operation)
        {
            _context = context;
            _operation = operation;
        }

        public IOperationHandlerBuilder<TResult> OnStart(Action handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return OnStartAsync(cancellationToken =>
            {
                handler();

                return Task.CompletedTask;
            });
        }

        public IOperationHandlerBuilder<TResult> OnStartAsync(Func<CancellationToken, Task> handler)
        {
            _operation.StartHandler = handler ?? throw new ArgumentNullException(nameof(handler));

            return this;
        }

        public IOperationHandlerBuilder<TResult> OnSuccess(Action<TResult> handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return OnSuccessAsync((result, cancellationToken) =>
            {
                handler(result);

                return Task.CompletedTask;
            });
        }

        public IOperationHandlerBuilder<TResult> OnSuccessAsync(Func<TResult, CancellationToken, Task> handler)
        {
            _operation.SuccessHandler = handler ?? throw new ArgumentNullException(nameof(handler));

            return this;
        }

        public IOperationHandlerBuilder<TResult> OnCancel(Action handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return OnCancelAsync(cancellationToken =>
            {
                handler();

                return Task.CompletedTask;
            });
        }

        public IOperationHandlerBuilder<TResult> OnCancelAsync(Func<CancellationToken, Task> handler)
        {
            _operation.CancelHandler = handler ?? throw new ArgumentNullException(nameof(handler));

            return this;
        }

        public IOperationHandlerBuilder<TResult> OnError<TException>(Action<OperationError<TException>> handler)
            where TException : Exception
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return OnErrorAsync<TException>((error, cancellationToken) =>
            {
                handler(error);

                return Task.CompletedTask;
            });
        }

        public IOperationHandlerBuilder<TResult> OnErrorAsync<TException>(Func<OperationError<TException>, CancellationToken, Task> handler)
            where TException : Exception
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            _operation.ErrorsHandlers.Add(new OperationErrorHandler<TException>(handler));

            return this;
        }

        public IOperationHandlerBuilder<TResult> OnFinish(Action handler)
        {
            if (handler == null)
                throw new ArgumentNullException(nameof(handler));

            return OnFinishAsync(cancellationToken =>
            {
                handler();

                return Task.CompletedTask;
            });
        }

        public IOperationHandlerBuilder<TResult> OnFinishAsync(Func<CancellationToken, Task> handler)
        {
            _operation.FinishHandler = handler ?? throw new ArgumentNullException(nameof(handler));

            return this;
        }

        public Task ExecuteAsync(CancellationToken cancellationToken = default)
        {
            return _operation.ExecuteAsync(_context, cancellationToken);
        }
    }
}
