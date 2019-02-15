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
using FlexiMvvm.Ioc;
using JetBrains.Annotations;

namespace FlexiMvvm.Operations
{
    public class OperationFactory : IOperationFactory
    {
        [NotNull]
        private readonly OperationSharedContext _sharedContext;

        public OperationFactory([NotNull] IDependencyProvider dependencyProvider, [NotNull] IErrorHandler errorHandler)
        {
            if (dependencyProvider == null)
                throw new ArgumentNullException(nameof(dependencyProvider));
            if (errorHandler == null)
                throw new ArgumentNullException(nameof(errorHandler));

            _sharedContext = new OperationSharedContext(dependencyProvider, errorHandler);
        }

        public IOperationBuilder Create(object owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            var context = new OperationContext(owner, _sharedContext);

            return new OperationBuilder(context);
        }
    }
}
