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

using System.Threading.Tasks;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Defines the contract for a lifecycle-aware view model.
    /// </summary>
    public interface ILifecycleViewModel : IViewModel
    {
    }

    /// <summary>
    /// Defines the contract for a lifecycle-aware view model without parameters.
    /// </summary>
    public interface ILifecycleViewModelWithoutParameters : ILifecycleViewModel
    {
        /// <summary>
        /// An asynchronous lifecycle method for the lifecycle-aware view model initialization.
        /// </summary>
        /// <returns>A task that represents the asynchronous initialization operation.</returns>
        Task InitializeAsync();

        /// <summary>
        /// A lifecycle method for the lifecycle-aware view model initialization.
        /// </summary>
        void Initialize();
    }

    /// <summary>
    /// Defines the contract for a lifecycle-aware view model with parameters.
    /// </summary>
    /// <typeparam name="TParameters">The type of the view model parameters.</typeparam>
    public interface ILifecycleViewModelWithParameters<TParameters> : ILifecycleViewModel
        where TParameters : Parameters
    {
        /// <summary>
        /// An asynchronous lifecycle method for the lifecycle-aware view model initialization with <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">The view model parameters. Can be <c>null</c>.</param>
        /// <returns>A task that represents the asynchronous initialization operation.</returns>
        Task InitializeAsync(TParameters? parameters);

        /// <summary>
        /// A lifecycle method for the lifecycle-aware view model initialization with <paramref name="parameters"/>.
        /// </summary>
        /// <param name="parameters">The view model parameters. Can be <c>null</c>.</param>
        void Initialize(TParameters? parameters);
    }

    /// <summary>
    /// Defines the contract for a lifecycle-aware view model with a result.
    /// </summary>
    /// <typeparam name="TResult">The type of the view model result.</typeparam>
    public interface ILifecycleViewModelWithResult<in TResult> : ILifecycleViewModel
        where TResult : Result
    {
        /// <summary>
        /// Sets the lifecycle-aware view model result.
        /// </summary>
        /// <param name="resultCode">Determines whether the result should be set as successful or not due to cancellation by the user.</param>
        /// <param name="result">The view model result. Can be <c>null</c>.</param>
        void SetResult(ResultCode resultCode, TResult? result);
    }

    /// <summary>
    /// Defines the contract for a lifecycle-aware view model that can handle a lifecycle-aware view model result.
    /// </summary>
    public interface ILifecycleViewModelWithResultHandler : ILifecycleViewModel
    {
        /// <summary>
        /// Handles the lifecycle-aware view model result.
        /// </summary>
        /// <param name="resultCode">Determines whether the view model result is set successfully or not due to cancellation by the user.</param>
        /// <param name="result">The view model result to handle. Can be <c>null</c>.</param>
        void HandleResult(ResultCode resultCode, Result? result);
    }
}
