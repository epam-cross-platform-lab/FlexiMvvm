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
using FlexiMvvm.Ioc;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public class OperationSharedContext
    {
        [CanBeNull]
        private Dictionary<Type, int> _notificationCounter;

        public OperationSharedContext([NotNull] IDependencyProvider dependencyProvider, [NotNull] IErrorHandler errorHandler)
        {
            DependencyProvider = dependencyProvider ?? throw new ArgumentNullException(nameof(dependencyProvider));
            ErrorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        [NotNull]
        public IDependencyProvider DependencyProvider { get; }

        [NotNull]
        internal IErrorHandler ErrorHandler { get; }

        [NotNull]
        private Dictionary<Type, int> NotificationCounter => _notificationCounter ?? (_notificationCounter = new Dictionary<Type, int>());

        public int GetNotificationCount<TNotification>()
            where TNotification : OperationNotification
        {
            return GetNotificationCount(typeof(TNotification));
        }

        internal int GetNotificationCount([NotNull] Type notificationType)
        {
            var count = 0;
            _notificationCounter?.TryGetValue(notificationType, out count);

            return count;
        }

        internal void IncreaseNotificationCount([NotNull] Type notificationType)
        {
            var count = GetNotificationCount(notificationType);
            NotificationCounter[notificationType] = ++count;
        }

        internal void DecreaseNotificationCount([NotNull] Type notificationType)
        {
            var count = GetNotificationCount(notificationType);
            NotificationCounter[notificationType] = Math.Max(--count, 0);
        }
    }
}
