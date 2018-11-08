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
using FlexiMvvm.Diagnostics;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels.Locator
{
    public class ViewModelFactory
    {
        [NotNull]
        private readonly Dictionary<Type, Func<IViewModel>> _viewModelsFactories = new Dictionary<Type, Func<IViewModel>>();

        public void Register<TViewModel>([NotNull] Func<TViewModel> factory)
            where TViewModel : class, IViewModel
        {
            _viewModelsFactories[typeof(TViewModel)] = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        [NotNull]
        internal TViewModel Get<TViewModel>()
            where TViewModel : class, IViewModel
        {
            if (!_viewModelsFactories.TryGetValue(typeof(TViewModel), out var viewModelFactory))
            {
                throw new InvalidOperationException(
                    $"View model factory is not registered for \"{LogFormatter.FormatTypeName<TViewModel>()}\" view model. " +
                    $"Use \"{LogFormatter.FormatTypeName<ViewModelFactory>()}.{nameof(Register)}\" method for that.");
            }

            return (TViewModel)viewModelFactory().NotNull();
        }
    }
}
