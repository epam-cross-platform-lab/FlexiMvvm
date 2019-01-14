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
using FlexiMvvm.Diagnostics;
using FlexiMvvm.Persistence;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public static partial class ViewModelProvider
    {
        [CanBeNull]
        private static IViewModelFactory _factory;

        [NotNull]
        public static TViewModel Get<TViewModel>([NotNull] IViewModelFactory factory, [CanBeNull] IBundle stateBundle)
            where TViewModel : class, IViewModel, IViewModelWithState
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var viewModel = Get<TViewModel>(factory);
            viewModel.ImportStateBundle(stateBundle);

            return viewModel;
        }

        [NotNull]
        public static TViewModel Get<TViewModel>([NotNull] IViewModelFactory factory)
            where TViewModel : class, IViewModel
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var viewModel = factory.Create<TViewModel>();

            if (viewModel == null)
            {
                throw new InvalidOperationException(
                    $"\"{LogFormatter.FormatTypeName(factory)}\" returned \"null\" for \"{LogFormatter.FormatTypeName<TViewModel>()}>\" " +
                    $"view model instance that is not allowed.");
            }

            return viewModel;
        }

        [NotNull]
        internal static IViewModelFactory GetFactory()
        {
            if (_factory == null)
            {
                throw new InvalidOperationException(
                    $"View model factory is not set. Use \"{nameof(ViewModelProvider)}.{nameof(SetFactory)}\" method to set factory instance.");
            }

            return _factory;
        }

        public static void SetFactory([NotNull] IViewModelFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}
