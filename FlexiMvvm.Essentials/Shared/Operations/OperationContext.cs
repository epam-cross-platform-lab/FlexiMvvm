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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public class OperationContext
    {
        [NotNull]
        private readonly Dictionary<Type, int> _notificationsCounter = new Dictionary<Type, int>();

        public OperationContext([NotNull] object owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        [NotNull]
        public object Owner { get; }

        [NotNull]
        internal async Task ExecuteAsync([NotNull] IOperation operation, CancellationToken cancellationToken)
        {
            var notificationCancellationTokenSource = operation.Notification?.CancellationTokenSource;
            var linkedCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(
                notificationCancellationTokenSource?.Token ?? CancellationToken.None,
                cancellationToken);
            var linkedCancellationToken = linkedCancellationTokenSource.Token;

            try
            {
                OperationError error;

                do
                {
                    error = null;

                    var operationTask = operation.ExecuteAsync(this, linkedCancellationToken);
                    var notificationMinDurationTask = Task.CompletedTask;

                    if (operation.Notification != null)
                    {
                        var notificationDelayTask = operation.Notification.GetDelayTask();
                        var completedTask = await Task.WhenAny(operationTask, notificationDelayTask).NotNull();

                        if (completedTask != operationTask)
                        {
                            operation.HideNotificationRequested += Operation_HideNotificationRequested;
                            RequestShowNotification(operation.Notification);
                            notificationMinDurationTask = operation.Notification.GetMinDurationTask();
                        }
                    }

                    try
                    {
                        await Task.WhenAll(operationTask, notificationMinDurationTask).NotNull();
                    }
                    catch (Exception ex)
                    {
                        error = new OperationError(ex);
                        await OnErrorAsync(error);

                        if (!error.Handled)
                        {
                            throw;
                        }
                    }
                }
                while (error?.RetryOperation ?? false);
            }
            finally
            {
                notificationCancellationTokenSource?.Dispose();
                linkedCancellationTokenSource.Dispose();
            }
        }

        [NotNull]
        protected virtual Task OnErrorAsync([NotNull] OperationError error)
        {
            return Task.CompletedTask;
        }

        private void RequestShowNotification([NotNull] OperationNotificationBase notification)
        {
            var notificationType = notification.GetType();
            _notificationsCounter.TryGetValue(notificationType, out var counter);
            _notificationsCounter[notificationType] = ++counter;

            notification.Show(this);
        }

        private void RequestHideNotification([NotNull] OperationNotificationBase notification, OperationCallback callback)
        {
            var notificationType = notification.GetType();
            _notificationsCounter.TryGetValue(notificationType, out var counter);
            _notificationsCounter[notificationType] = Math.Max(--counter, 0);

            if (counter == 0)
            {
                notification.Hide(this, callback);
            }
        }

        private void Operation_HideNotificationRequested([NotNull] object sender, [NotNull] HideNotificationEventArgs e)
        {
            var operation = (IOperation)sender;

            if (operation.Notification != null)
            {
                RequestHideNotification(operation.Notification, e.Callback);
            }
        }
    }
}
