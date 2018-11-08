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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    internal class Operation<TResult> : IOperation
    {
        [NotNull]
        private readonly Func<CancellationToken, Task<TResult>> _expression;
        [CanBeNull]
        [ItemNotNull]
        private List<IOperationErrorHandler> _errorsHandlers;

        internal Operation(
            [NotNull] Func<CancellationToken, Task<TResult>> expression,
            [CanBeNull] OperationNotificationBase notification,
            [CanBeNull] OperationConditionBase condition)
        {
            _expression = expression;
            Notification = notification;
            Condition = condition;
        }

        public event EventHandler<HideNotificationEventArgs> HideNotificationRequested;

        public OperationNotificationBase Notification { get; }

        public OperationConditionBase Condition { get; }

        [NotNull]
        internal Func<TResult, CancellationToken, Task> SuccessHandler { get; set; } = (result, cancellationToken) => Task.CompletedTask;

        [NotNull]
        internal Func<CancellationToken, Task> CancelHandler { get; set; } = cancellationToken => Task.CompletedTask;

        [NotNull]
        private Func<OperationError, CancellationToken, Task> ErrorHandler { get; } = (error, cancellationToken) =>
        {
            error.NotNull().Handled = false;

            return Task.CompletedTask;
        };

        [NotNull]
        [ItemNotNull]
        internal List<IOperationErrorHandler> ErrorsHandlers => _errorsHandlers ?? (_errorsHandlers = new List<IOperationErrorHandler>());

        public async Task ExecuteAsync(OperationContext context, CancellationToken cancellationToken)
        {
            var result = default(TResult);
            var executedSuccessfully = false;
            OperationError error;

            do
            {
                error = null;

                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (Condition == null || await Condition.CheckAsync(context, cancellationToken))
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        result = await _expression(cancellationToken).NotNull();
                        cancellationToken.ThrowIfCancellationRequested();
                        executedSuccessfully = true;
                    }
                    else
                    {
                        throw new OperationCanceledException(CancellationToken.None);
                    }
                }
                catch (OperationCanceledException ex)
                {
                    var cancelTask = CancelHandler(ex.CancellationToken).NotNull();
                    OnRequestHideNotification(new HideNotificationEventArgs(OperationCallback.Cancel));

                    await cancelTask;
                }
                catch (Exception ex)
                {
                    error = new OperationError(ex);
                    var errorHandler = GetErrorHandler(ex);
                    var errorTask = errorHandler(error, cancellationToken).NotNull();
                    OnRequestHideNotification(new HideNotificationEventArgs(OperationCallback.Error));

                    await errorTask;

                    if (!error.Handled)
                    {
                        throw;
                    }
                }
            }
            while (error?.RetryOperation ?? false);

            if (executedSuccessfully)
            {
                var successTask = SuccessHandler(result, cancellationToken).NotNull();
                OnRequestHideNotification(new HideNotificationEventArgs(OperationCallback.Success));

                await successTask;
            }
        }

        protected virtual void OnRequestHideNotification([NotNull] HideNotificationEventArgs e)
        {
            HideNotificationRequested?.Invoke(this, e);
        }

        [NotNull]
        private Func<OperationError, CancellationToken, Task> GetErrorHandler([NotNull] Exception ex)
        {
            return _errorsHandlers?.FirstOrDefault(errorHandler => errorHandler.NotNull().CanHandle(ex))?.Handler ?? ErrorHandler;
        }
    }
}
