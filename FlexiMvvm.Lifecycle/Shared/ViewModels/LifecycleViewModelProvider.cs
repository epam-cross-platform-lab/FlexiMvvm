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
using FlexiMvvm.Formatters;
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;

namespace FlexiMvvm.ViewModels
{
    /// <summary>
    /// Represents a lifecycle-aware view model provider that returns an existing or new instance of lifecycle-aware view model.
    /// </summary>
    public static class LifecycleViewModelProvider
    {
        private static ILifecycleViewModelFactory? _factory;

        /// <summary>
        /// Returns an existing lifecycle-aware view model by <paramref name="key"/> if it is presented in the <paramref name="store"/>
        /// or creates a new one using the <paramref name="factory"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to get.</typeparam>
        /// <param name="store">The view model store.</param>
        /// <param name="key">The view model unique key.</param>
        /// <param name="factory">The view model factory.</param>
        /// <param name="state">The view model state bundle.</param>
        /// <param name="created"><c>true</c> if the view model is created by <paramref name="factory"/>; otherwise, <c>false</c>.</param>
        /// <returns>The view model instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="store"/> or <paramref name="key"/> or <paramref name="factory"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException"><paramref name="factory"/> returned <c>null</c> value for the <typeparamref name="TViewModel"/>.</exception>
        public static TViewModel Get<TViewModel>(
            ILifecycleViewModelStore store,
            string key,
            ILifecycleViewModelFactory factory,
            IBundle? state,
            out bool created)
            where TViewModel : class, ILifecycleViewModel, IStateOwner
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));
            if (key == null)
                throw new ArgumentNullException(nameof(key));
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var viewModel = store.Get<TViewModel>(key);
            created = false;

            if (viewModel == null)
            {
                viewModel = factory.Create<TViewModel>();

                if (viewModel == null)
                {
                    throw new InvalidOperationException(
                        $"'{TypeFormatter.FormatName(factory.GetType())}.{nameof(ILifecycleViewModelFactory.Create)}' " +
                        $"returned 'null' value for the '{TypeFormatter.FormatName<TViewModel>()}>' view model.");
                }

                viewModel.ImportState(state);
                store.Add(key, viewModel);
                created = true;
            }

            return viewModel;
        }

        internal static ILifecycleViewModelFactory GetFactory()
        {
            return _factory ?? throw new InvalidOperationException(
                $"View model factory is not specified. Use \"{nameof(LifecycleViewModelProvider)}.{nameof(SetFactory)}\" method to set the factory instance.");
        }

        public static void SetFactory(ILifecycleViewModelFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}
