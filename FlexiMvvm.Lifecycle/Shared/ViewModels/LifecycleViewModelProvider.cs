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
    /// Represents a provider that returns an existing lifecycle-aware view model instance or creates a new one.
    /// </summary>
    public static class LifecycleViewModelProvider
    {
        private static ILifecycleViewModelFactory? _factory;

        /// <summary>
        /// Returns an existing lifecycle-aware <typeparamref name="TViewModel"/> instance by <paramref name="key"/> if it is presented in the <paramref name="store"/>,
        /// or creates a new one using the <paramref name="factory"/> with restoring its <paramref name="state"/>.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model to get.</typeparam>
        /// <param name="store">The view model store.</param>
        /// <param name="key">The view model unique key.</param>
        /// <param name="factory">The view model factory.</param>
        /// <param name="state">The view model state bundle.</param>
        /// <param name="created"><see langword="true"/> if the view model is created by the <paramref name="factory"/>; otherwise, <see langword="false"/>.</param>
        /// <returns>The view model instance.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="store"/> or <paramref name="key"/> or <paramref name="factory"/> is <see langword="null"/>.</exception>
        /// <exception cref="InvalidOperationException">The <paramref name="factory"/> returned <see langword="null"/> value for the <typeparamref name="TViewModel"/>.</exception>
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
                $"The lifecycle-aware view model factory is not set. Use '{nameof(LifecycleViewModelProvider)}.{nameof(SetFactory)}' method to set the factory instance.");
        }

        /// <summary>
        /// Sets the lifecycle-aware view model <paramref name="factory"/> that is used to create a view model instance.
        /// </summary>
        /// <param name="factory">The view model factory.</param>
        /// <exception cref="ArgumentNullException"><paramref name="factory"/> is <see langword="null"/>.</exception>
        public static void SetFactory(ILifecycleViewModelFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}
