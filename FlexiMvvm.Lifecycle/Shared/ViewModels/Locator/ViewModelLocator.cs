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
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels.Locator
{
    public static class ViewModelLocator
    {
        [CanBeNull]
        private static ViewModelLocatorBase _locator;

        public static void SetLocator([NotNull] ViewModelLocatorBase locator)
        {
            _locator = locator ?? throw new ArgumentNullException(nameof(locator));

            if (_locator.Factory == null)
            {
                _locator.Factory = new ViewModelFactory();
                _locator.SetupFactory(_locator.Factory);
            }
        }

        [NotNull]
        internal static TViewModel CreateInstance<TViewModel>()
            where TViewModel : class, IViewModel
        {
            if (_locator?.Factory == null)
            {
                throw new InvalidOperationException(
                    $"View model locator is not set. Use \"{nameof(ViewModelLocator)}.{nameof(SetLocator)}\" method to set new instance.");
            }

            var viewModel = _locator.CreateInstance<TViewModel>(_locator.Factory);

            if (viewModel == null)
            {
                throw new InvalidOperationException(
                    $"\"{LogFormatter.FormatTypeName(_locator)}\" returned \"null\" for \"{LogFormatter.FormatTypeName<TViewModel>()}>\" " +
                    $"view model instance which is not allowed.");
            }

            return viewModel;
        }
    }
}
