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
    internal class OperationErrorHandler<TException> : IOperationErrorHandler
        where TException : Exception
    {
        [NotNull]
        private readonly Func<OperationContext, OperationError<TException>, CancellationToken, Task> _handler;

        internal OperationErrorHandler([NotNull] Func<OperationError<TException>, CancellationToken, Task> handler)
            : this((context, error, cancellationToken) => handler(error, cancellationToken))
        {
        }

        internal OperationErrorHandler([NotNull] Func<OperationContext, OperationError<TException>, CancellationToken, Task> handler)
        {
            _handler = handler;
        }

        public bool CanHandle(Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            return ex is TException;
        }

        public async Task<IOperationErrorResult> HandleAsync(OperationContext context, Exception ex, CancellationToken cancellationToken)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (ex == null)
                throw new ArgumentNullException(nameof(ex));

            var error = new OperationError<TException>((TException)ex);
            await _handler(context, error, cancellationToken).NotNull();

            return error;
        }
    }
}
