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
using System.Threading.Tasks;
using FlexiMvvm.ViewModels;

namespace FlexiMvvm.Views.Core
{
    /// <summary>
    /// Defines the contract for a lifecycle-aware view model owner.
    /// <para>This interface is intended for internal use by the FlexiMvvm.</para>
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface ILifecycleViewModelOwner<in TViewModel>
        where TViewModel : class, ILifecycleViewModel
    {
        /// <summary>
        /// Sets the lifecycle-aware view model to its owner.
        /// </summary>
        /// <param name="viewModel">The view model to set.</param>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        void SetViewModel(TViewModel viewModel);

        /// <summary>
        /// Initializes the lifecycle-aware view model by calling its corresponding method.
        /// </summary>
        /// <param name="recreated">Determines whether the view model has been destroyed to recover memory and recreated with a restored state if it was persisted.</param>
        /// <returns>A task that represents the asynchronous initialization operation.</returns>
        Task InitializeViewModelAsync(bool recreated);
    }
}
