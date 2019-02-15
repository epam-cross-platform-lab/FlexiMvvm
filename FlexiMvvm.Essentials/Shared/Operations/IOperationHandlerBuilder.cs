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
    public interface IOperationHandlerBuilder<out TResult>
    {
        [NotNull]
        IOperationHandlerBuilder<TResult> OnStart([NotNull] Action handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnStartAsync([NotNull] Func<CancellationToken, Task> handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnSuccess([NotNull] Action handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnSuccess([NotNull] Action<TResult> handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnSuccessAsync([NotNull] Func<CancellationToken, Task> handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnSuccessAsync([NotNull] Func<TResult, CancellationToken, Task> handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnCancel([NotNull] Action handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnCancelAsync([NotNull] Func<CancellationToken, Task> handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnError<TException>([NotNull] Action<OperationError<TException>> handler)
            where TException : Exception;

        [NotNull]
        IOperationHandlerBuilder<TResult> OnErrorAsync<TException>([NotNull] Func<OperationError<TException>, CancellationToken, Task> handler)
            where TException : Exception;

        [NotNull]
        IOperationHandlerBuilder<TResult> OnFinish([NotNull] Action handler);

        [NotNull]
        IOperationHandlerBuilder<TResult> OnFinishAsync([NotNull] Func<CancellationToken, Task> handler);

        [NotNull]
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}
