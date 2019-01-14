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
        [CanBeNull]
        private readonly IDependencyProvider _dependencyProvider;
        [NotNull]
        private readonly IErrorHandler _errorHandler;

        public OperationFactory([CanBeNull] IDependencyProvider dependencyProvider, [NotNull] IErrorHandler errorHandler)
        {
            _dependencyProvider = dependencyProvider;
            _errorHandler = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        public IOperationBuilder CreateOperation(OperationContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            return new OperationBuilder(context);
        }

        public OperationContext CreateContext(object owner)
        {
            if (owner == null)
                throw new ArgumentNullException(nameof(owner));

            return new OperationContext(_dependencyProvider, owner, _errorHandler);
        }
    }
}
