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
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    internal class Operation<TResult>
    {
        [NotNull]
        private readonly Func<CancellationToken, Task<TResult>> _expression;
        [CanBeNull]
        [ItemNotNull]
        private List<IOperationErrorHandler> _errorsHandlers;
        private bool _isNotificationShowed;
        private bool _isNotificationHidden;

        internal Operation(
            [NotNull] Func<CancellationToken, Task<TResult>> expression,
            [CanBeNull] OperationNotification notification,
            [CanBeNull] OperationCondition condition)
        {
            _expression = expression;
            Notification = notification;
            Condition = condition;
        }

        [CanBeNull]
        private OperationNotification Notification { get; }

        [CanBeNull]
        private OperationCondition Condition { get; }

        [CanBeNull]
        internal Func<CancellationToken, Task> StartHandler { get; set; }

        [CanBeNull]
        internal Func<TResult, CancellationToken, Task> SuccessHandler { get; set; }

        [CanBeNull]
        internal Func<CancellationToken, Task> CancelHandler { get; set; }

        [NotNull]
        [ItemNotNull]
        internal List<IOperationErrorHandler> ErrorsHandlers => _errorsHandlers ?? (_errorsHandlers = new List<IOperationErrorHandler>());

        [NotNull]
        internal Func<CancellationToken, Task> FinishHandler { get; set; } = cancellationToken => Task.CompletedTask;

        internal async Task ExecuteAsync([NotNull] OperationContext context, CancellationToken cancellationToken)
        {
            var notificationCancellationTokenSource = Notification?.CancellationTokenSource;
            var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                notificationCancellationTokenSource?.Token ?? CancellationToken.None,
                cancellationToken);
            var linkedCancellationToken = linkedCancellationTokenSource.Token;

            try
            {
                IOperationErrorResult errorResult;

                do
                {
                    var result = default(TResult);
                    var status = OperationStatus.Succeeded;
                    errorResult = null;
                    _isNotificationShowed = false;
                    _isNotificationHidden = false;

                    try
                    {
                        context.AttemptCount++;
                        var notificationDelayTask = Notification?.DelayAsync(linkedCancellationToken) ?? Task.CompletedTask;
                        await ExecuteOperationStartHandlerAsync(linkedCancellationToken);
                        var operationTask = ExecuteExpressionWithConditionCheckAsync(context, linkedCancellationToken);
                        await ShowNotificationIfNeededAsync(context, notificationDelayTask, operationTask, linkedCancellationToken);

                        try
                        {
                            result = await operationTask;
                            status = OperationStatus.Succeeded;
                        }
                        catch (OperationCanceledException)
                        {
                            throw;
                        }
                        catch (Exception ex)
                        {
                            status = OperationStatus.Failed;
                            errorResult = await ExecuteOperationErrorHandlerAsync(context, status, ex, linkedCancellationToken);
                            await ExecuteOperationFinishHandlerAsync(context, status, linkedCancellationToken);

                            if (!(errorResult?.Handled ?? false))
                            {
                                errorResult = await ExecuteErrorHandlerAsync(context, ex, linkedCancellationToken);

                                if (!errorResult.Handled)
                                {
                                    throw;
                                }
                            }
                        }
                        finally
                        {
                            if (status == OperationStatus.Succeeded)
                            {
                                await ExecuteOperationSuccessHandlerAsync(context, status, result, linkedCancellationToken);
                                await ExecuteOperationFinishHandlerAsync(context, status, linkedCancellationToken);
                            }
                        }
                    }
                    catch (OperationCanceledException ex)
                    {
                        status = OperationStatus.Canceled;
                        await ExecuteOperationCancelHandlerAsync(context, status, ex.CancellationToken);
                        await ExecuteOperationFinishHandlerAsync(context, status, ex.CancellationToken);
                    }
                }
                while (errorResult?.RetryOperation ?? false);
            }
            catch (OperationCanceledException)
            {
                // Do nothing.
            }
            finally
            {
                notificationCancellationTokenSource?.Dispose();
                linkedCancellationTokenSource.Dispose();
            }
        }

        [NotNull]
        private async Task ExecuteOperationStartHandlerAsync(CancellationToken cancellationToken)
        {
            if (StartHandler != null)
            {
                await StartHandler(cancellationToken).NotNull();
            }
        }

        [NotNull]
        [ItemCanBeNull]
        private async Task<TResult> ExecuteExpressionWithConditionCheckAsync(
            [NotNull] OperationContext context,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (Condition == null || await Condition.CheckAsync(context, cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();

                return await _expression(cancellationToken).NotNull();
            }
            else
            {
                throw new OperationCanceledException(CancellationToken.None);
            }
        }

        [NotNull]
        private async Task ExecuteOperationSuccessHandlerAsync(
            [NotNull] OperationContext context,
            OperationStatus status,
            [CanBeNull] TResult result,
            CancellationToken cancellationToken)
        {
            if (SuccessHandler != null)
            {
                var successTask = SuccessHandler(result, cancellationToken).NotNull();
                HideNotificationIfNeeded(context, status);
                await successTask;
            }
        }

        private async Task ExecuteOperationCancelHandlerAsync(
            [NotNull] OperationContext context,
            OperationStatus status,
            CancellationToken cancellationToken)
        {
            if (CancelHandler != null)
            {
                var cancelTask = CancelHandler(cancellationToken).NotNull();
                HideNotificationIfNeeded(context, status);
                await cancelTask;
            }
        }

        [NotNull]
        [ItemCanBeNull]
        private async Task<IOperationErrorResult> ExecuteOperationErrorHandlerAsync(
            [NotNull] OperationContext context,
            OperationStatus status,
            [NotNull] Exception ex,
            CancellationToken cancellationToken)
        {
            IOperationErrorResult errorResult = null;
            var errorHandler = _errorsHandlers?.FirstOrDefault(handler => handler.NotNull().CanHandle(ex));

            if (errorHandler != null)
            {
                var errorTask = errorHandler.HandleAsync(context, ex, cancellationToken);
                HideNotificationIfNeeded(context, status);
                errorResult = await errorTask;
            }

            return errorResult;
        }

        [NotNull]
        private async Task ExecuteOperationFinishHandlerAsync(
            [NotNull] OperationContext context,
            OperationStatus status,
            CancellationToken cancellationToken)
        {
            var finishTask = FinishHandler(cancellationToken).NotNull();
            HideNotificationIfNeeded(context, status);
            await finishTask;
        }

        [NotNull]
        [ItemNotNull]
        private async Task<IOperationErrorResult> ExecuteErrorHandlerAsync(
            [NotNull] OperationContext context,
            [NotNull] Exception ex,
            CancellationToken cancellationToken)
        {
            var errorHandler = new OperationErrorHandler<Exception>(context.Shared.ErrorHandler.HandleAsync);

            return await errorHandler.HandleAsync(context, ex, cancellationToken);
        }

        [NotNull]
        private async Task ShowNotificationIfNeededAsync(
            [NotNull] OperationContext context,
            [NotNull] Task notificationDelayTask,
            [NotNull] Task operationTask,
            CancellationToken cancellationToken)
        {
            if (Notification != null)
            {
                await Task.WhenAny(notificationDelayTask, operationTask).NotNull();

                if (!operationTask.IsCompleted)
                {
                    Notification.Show(context);
                    context.Shared.IncreaseNotificationCount(Notification.GetType());
                    _isNotificationShowed = true;

                    await Notification.MinDurationDelayAsync(cancellationToken);
                }
            }
        }

        private void HideNotificationIfNeeded(
            [NotNull] OperationContext context,
            OperationStatus status)
        {
            if (Notification != null && _isNotificationShowed && !_isNotificationHidden)
            {
                context.Shared.DecreaseNotificationCount(Notification.GetType());
                Notification.Hide(context, status);
                _isNotificationHidden = true;
            }
        }
    }
}
