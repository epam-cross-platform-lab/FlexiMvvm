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

namespace FlexiMvvm.ViewModels
{
    public sealed class DependencyProviderViewModelFactory : ViewModelFactory
    {
        [NotNull]
        private readonly IDependencyProvider _dependencyProvider;

        public DependencyProviderViewModelFactory([NotNull] IDependencyProvider dependencyProvider)
        {
            _dependencyProvider = dependencyProvider ?? throw new ArgumentNullException(nameof(dependencyProvider));
        }

        protected override TViewModel CreateInstance<TViewModel>()
        {
            return _dependencyProvider.Get<TViewModel>();
        }
    }
}
