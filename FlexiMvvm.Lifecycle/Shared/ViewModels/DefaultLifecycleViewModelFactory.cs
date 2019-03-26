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

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Default implementation of the lifecycle-aware view model factory. <see cref="IDependencyProvider"/> is used to create a view model instance.
    /// </summary>
    public sealed class DefaultLifecycleViewModelFactory : ILifecycleViewModelFactory
    {
        private readonly IDependencyProvider _dependencyProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultLifecycleViewModelFactory"/> class.
        /// </summary>
        /// <param name="dependencyProvider">The dependency provider that is used to create a view model instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="dependencyProvider"/> is <c>null</c>.</exception>
        public DefaultLifecycleViewModelFactory(IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider ?? throw new ArgumentNullException(nameof(dependencyProvider));
        }

        /// <inheritdoc />
        public TViewModel Create<TViewModel>()
            where TViewModel : class, ILifecycleViewModel
        {
            return _dependencyProvider.Get<TViewModel>();
        }
    }
}
