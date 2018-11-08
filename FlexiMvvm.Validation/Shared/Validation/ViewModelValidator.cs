// =========================================================================
// Copyright 2018 EPAM Systems, Inc.
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Internal;
using FluentValidation.Results;
using JetBrains.Annotations;

namespace FlexiMvvm.Validation
{
    /// <inheritdoc />
    public class ViewModelValidator<TViewModel> : IViewModelValidator<TViewModel>
        where TViewModel : IValidatableViewModel
    {
        [NotNull]
        private readonly IValidator<TViewModel> _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelValidator{TViewModel}"/> class.
        /// </summary>
        /// <param name="validator">The view model validator.</param>
        /// <exception cref="ArgumentNullException"><paramref name="validator"/> is <c>null</c>.</exception>
        public ViewModelValidator([NotNull] IValidator<TViewModel> validator)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
        }

        /// <inheritdoc />
        public bool Validate(TViewModel viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var validationResult = _validator.Validate(viewModel).NotNull();
            RefreshViewModelErrors(null, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        /// <inheritdoc />
        public bool Validate(TViewModel viewModel, string ruleSet)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ruleSet == null)
                throw new ArgumentNullException(nameof(ruleSet));
            if (string.IsNullOrWhiteSpace(ruleSet))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ruleSet));

            var validationResult = _validator.Validate(viewModel, ruleSet: ruleSet).NotNull();
            var properties = GetRuleSetProperties(ruleSet);
            RefreshViewModelErrors(properties, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        /// <inheritdoc />
        public bool Validate(TViewModel viewModel, IEnumerable<string> properties)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var propertiesArray = properties.ToArray();
            var validationResult = _validator.Validate(viewModel, propertiesArray).NotNull();
            RefreshViewModelErrors(propertiesArray, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        /// <inheritdoc />
        public async Task<bool> ValidateAsync(TViewModel viewModel, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            var validationResult = await _validator.ValidateAsync(viewModel, cancellationToken).NotNull();
            RefreshViewModelErrors(null, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        /// <inheritdoc />
        public async Task<bool> ValidateAsync(TViewModel viewModel, string ruleSet, CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (ruleSet == null)
                throw new ArgumentNullException(nameof(ruleSet));
            if (string.IsNullOrWhiteSpace(ruleSet))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(ruleSet));

            var validationResult = await _validator.ValidateAsync(viewModel, ruleSet: ruleSet, cancellationToken: cancellationToken).NotNull();
            var properties = GetRuleSetProperties(ruleSet);
            RefreshViewModelErrors(properties, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        /// <inheritdoc />
        public async Task<bool> ValidateAsync(
            TViewModel viewModel,
            IEnumerable<string> properties,
            CancellationToken cancellationToken = default)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            var propertiesArray = properties.ToArray();
            var validationResult = await _validator.ValidateAsync(viewModel, cancellationToken, propertiesArray).NotNull();
            RefreshViewModelErrors(propertiesArray, validationResult, viewModel.Errors);

            return validationResult.IsValid;
        }

        [NotNull]
        private IEnumerable<string> GetRuleSetProperties([NotNull] string ruleSet)
        {
            var validationProperties = new List<string>();
            var descriptor = _validator.CreateDescriptor().NotNull();
            var members = descriptor.GetMembersWithValidators().NotNull();

            foreach (var member in members)
            {
                var validationRules = descriptor.GetRulesForMember(member.Key).NotNull();

                foreach (var validationRule in validationRules)
                {
                    if (validationRule is PropertyRule rule && rule.RuleSets.NotNull().Contains(ruleSet))
                    {
                        validationProperties.Add(rule.PropertyName);
                    }
                }
            }

            return validationProperties;
        }

        private void RefreshViewModelErrors(
            [CanBeNull] [ItemNotNull] IEnumerable<string> validationProperties,
            [NotNull] ValidationResult validationResult,
            [NotNull] IDictionary<string, string> viewModelErrors)
        {
            var validationPropertiesList = validationProperties?.ToList();

            if (validationPropertiesList != null && validationPropertiesList.Any())
            {
                foreach (var property in validationPropertiesList)
                {
                    viewModelErrors.Remove(property);
                }
            }
            else
            {
                viewModelErrors.Clear();
            }

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors.NotNull())
                {
                    viewModelErrors[error.PropertyName.NotNull()] = error.ErrorMessage;
                }
            }
        }
    }
}
