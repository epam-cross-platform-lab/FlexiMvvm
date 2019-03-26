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
    /// Defines the contract for a lifecycle-aware view model store.
    /// </summary>
    public interface ILifecycleViewModelStore
    {
        /// <summary>
        /// Returns an existing lifecycle-aware view model from the store.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to get.</typeparam>
        /// <param name="key">The view model unique key.</param>
        /// <returns>The view model instance if it exists; otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        TViewModel? Get<TViewModel>(string key)
            where TViewModel : class, ILifecycleViewModel;

        /// <summary>
        /// Adds a lifecycle-aware view model to the store by <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to add.</typeparam>
        /// <param name="key">The view model unique key.</param>
        /// <param name="viewModel">The view model to add.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> or <paramref name="viewModel"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">The store already has a view model with the specified <paramref name="key"/>.</exception>
        void Add<TViewModel>(string key, TViewModel viewModel)
            where TViewModel : class, ILifecycleViewModel;

        /// <summary>
        /// Removes a lifecycle-aware view model from the store by <paramref name="key"/>.
        /// </summary>
        /// <param name="key">The view model unique key.</param>
        /// <exception cref="ArgumentNullException"><paramref name="key"/> is <c>null</c>.</exception>
        void Remove(string key);
    }
}
