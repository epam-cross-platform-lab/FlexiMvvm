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
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace FlexiMvvm.Validation
{
    /// <summary>
    /// Provides methods for view model validation.
    /// </summary>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface IViewModelValidator<in TViewModel>
        where TViewModel : IValidatableViewModel
    {
        /// <summary>
        /// Validates the specified view model.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model to validate.</param>
        /// <returns><c>true</c> if view model is valid, and <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        bool Validate([NotNull] TViewModel viewModel);

        /// <summary>
        /// Validates the specified view model based on provided rule set.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model to validate.</param>
        /// <param name="ruleSet">The rule set to validate.</param>
        /// <returns><c>true</c> if view model is valid, and <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> or <paramref name="ruleSet"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="ruleSet"/> is a zero-length string or contains only white space.</exception>
        bool Validate([NotNull] TViewModel viewModel, [NotNull] string ruleSet);

        /// <summary>
        /// Validates the specified view model based on provided properties.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model to validate.</param>
        /// <param name="properties">The view model properties to validate.</param>
        /// <returns><c>true</c> if view model is valid, and <c>false</c> otherwise.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> or <paramref name="properties"/> is <c>null</c>.</exception>
        bool Validate([NotNull] TViewModel viewModel, [NotNull] IEnumerable<string> properties);

        /// <summary>
        /// Validates the specified view model asynchronously.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model to validate.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns>
        /// A task that represents the asynchronous validate operation.
        /// The task result contains <c>true</c> if view model is valid, and <c>false</c> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> is <c>null</c>.</exception>
        [NotNull]
        Task<bool> ValidateAsync([NotNull] TViewModel viewModel, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validates the specified view model asynchronously based on provided rule set.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model to validate.</param>
        /// <param name="ruleSet">The rule set to validate.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns>
        /// A task that represents the asynchronous validate operation.
        /// The task result contains <c>true</c> if view model is valid, and <c>false</c> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> or <paramref name="ruleSet"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="ruleSet"/> is a zero-length string or contains only white space.</exception>
        [NotNull]
        Task<bool> ValidateAsync([NotNull] TViewModel viewModel, [NotNull] string ruleSet, CancellationToken cancellationToken = default);

        /// <summary>
        /// Validates the specified view model asynchronously based on provided properties.
        /// Errors are set to <see cref="IValidatableViewModel.Errors" /> property.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <param name="properties">The view model properties to validate.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.
        /// The default value is <see cref="CancellationToken.None" />.</param>
        /// <returns>
        /// A task that represents the asynchronous validate operation.
        /// The task result contains <c>true</c> if view model is valid, and <c>false</c> otherwise.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="viewModel"/> or <paramref name="properties"/> is <c>null</c>.</exception>
        [NotNull]
        Task<bool> ValidateAsync(
            [NotNull] TViewModel viewModel,
            [NotNull] IEnumerable<string> properties,
            CancellationToken cancellationToken = default);
    }
}
