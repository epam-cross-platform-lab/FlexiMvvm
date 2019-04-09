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

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Represents an <see cref="ILifecycleViewModelFactory"/> that creates a new lifecycle-aware view model instance using the <see cref="IServiceProvider"/>.
    /// </summary>
    public sealed class DefaultLifecycleViewModelFactory : ILifecycleViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultLifecycleViewModelFactory"/> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider that is used to create a view model instance.</param>
        /// <exception cref="ArgumentNullException"><paramref name="serviceProvider"/> is <see langword="null"/>.</exception>
        public DefaultLifecycleViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <inheritdoc />
        public TViewModel Create<TViewModel>()
            where TViewModel : class, ILifecycleViewModel
        {
            return (TViewModel)_serviceProvider.GetService(typeof(TViewModel));
        }
    }
}
