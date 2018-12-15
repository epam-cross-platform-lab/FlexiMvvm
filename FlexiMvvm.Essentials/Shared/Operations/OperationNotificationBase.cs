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

using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public abstract class OperationNotificationBase
    {
        private readonly int _delay;
        private readonly int _minDuration;

        protected OperationNotificationBase(int delay, int minDuration, bool isCancelable)
        {
            _delay = delay;
            _minDuration = minDuration;

            if (isCancelable)
            {
                CancellationTokenSource = new CancellationTokenSource();
            }
        }

        [CanBeNull]
        protected internal CancellationTokenSource CancellationTokenSource { get; }

        [NotNull]
        internal Task DelayAsync(CancellationToken cancellationToken)
        {
            return _delay > 0 ? Task.Delay(_delay, cancellationToken).NotNull() : Task.CompletedTask;
        }

        [NotNull]
        internal Task MinDurationDelayAsync(CancellationToken cancellationToken)
        {
            return _minDuration > 0 ? Task.Delay(_minDuration, cancellationToken).NotNull() : Task.CompletedTask;
        }

        protected internal abstract void Show([NotNull] OperationContext context);

        protected internal abstract void Hide([NotNull] OperationContext context, OperationStatus status);
    }
}
