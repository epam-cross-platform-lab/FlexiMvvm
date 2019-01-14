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
    public class OperationContext
    {
        [CanBeNull]
        private Dictionary<Type, int> _notificationsCounter;

        public OperationContext([CanBeNull] IDependencyProvider dependencyProvider, [NotNull] object owner, [NotNull] IErrorHandler errorHandler)
        {
            DependencyProvider = dependencyProvider;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            ErrorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        [CanBeNull]
        public IDependencyProvider DependencyProvider { get; }

        [NotNull]
        public object Owner { get; }

        [NotNull]
        internal IErrorHandler ErrorHandler { get; }

        [NotNull]
        private Dictionary<Type, int> NotificationsCounter => _notificationsCounter ?? (_notificationsCounter = new Dictionary<Type, int>());

        public int GetNotificationsCount<TNotification>()
            where TNotification : OperationNotificationBase
        {
            return GetNotificationsCount(typeof(TNotification));
        }

        internal int GetNotificationsCount([NotNull] Type notificationType)
        {
            var count = 0;

            _notificationsCounter?.TryGetValue(notificationType, out count);

            return count;
        }

        internal void IncreaseNotificationsCount([NotNull] Type notificationType)
        {
            var count = GetNotificationsCount(notificationType);
            NotificationsCounter[notificationType] = ++count;
        }

        internal void DecreaseNotificationsCount([NotNull] Type notificationType)
        {
            var count = GetNotificationsCount(notificationType);
            NotificationsCounter[notificationType] = Math.Max(--count, 0);
        }
    }
}
