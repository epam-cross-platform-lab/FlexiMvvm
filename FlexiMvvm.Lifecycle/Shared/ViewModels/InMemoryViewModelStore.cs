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
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public sealed class InMemoryViewModelStore : IViewModelStore
    {
        [CanBeNull]
        private Dictionary<string, ILifecycleViewModel> _viewModels;

        [NotNull]
        private Dictionary<string, ILifecycleViewModel> ViewModels => _viewModels ?? (_viewModels = new Dictionary<string, ILifecycleViewModel>());

        public TViewModel Get<TViewModel>(string key)
            where TViewModel : class, ILifecycleViewModel
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            return (TViewModel)_viewModels.GetValueOrDefault(key);
        }

        public void Add<TViewModel>(string key, TViewModel viewModel)
            where TViewModel : class, ILifecycleViewModel
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ViewModels.ContainsKey(key))
                throw new ArgumentException($"View model store has a view model with the \"{key}\" key.");

            ViewModels[key] = viewModel;
        }

        public void Remove(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));

            ViewModels.Remove(key);
        }
    }
}
