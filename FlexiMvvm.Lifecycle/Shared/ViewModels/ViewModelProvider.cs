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
using FlexiMvvm.Persistence;
using FlexiMvvm.Persistence.Core;
using JetBrains.Annotations;

namespace FlexiMvvm.ViewModels
{
    public static class ViewModelProvider
    {
        [CanBeNull]
        private static IViewModelFactory _factory;

        [NotNull]
        public static TViewModel Get<TViewModel>(
            [NotNull] IViewModelStore store,
            [NotNull] string key,
            [NotNull] IViewModelFactory factory,
            [CanBeNull] IBundle state,
            out bool created)
            where TViewModel : class, ILifecycleViewModel, IStateOwner
        {
            if (store == null)
                throw new ArgumentNullException(nameof(store));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(key));
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var viewModel = store.Get<TViewModel>(key);
            created = false;

            if (viewModel == null)
            {
                viewModel = factory.Create<TViewModel>(state);
                store.Add(key, viewModel);
                created = true;
            }

            return viewModel;
        }

        [NotNull]
        internal static IViewModelFactory GetFactory()
        {
            return _factory ?? throw new InvalidOperationException(
                $"View model factory is not specified. Use \"{nameof(ViewModelProvider)}.{nameof(SetFactory)}\" method to set the factory instance.");
        }

        public static void SetFactory([NotNull] IViewModelFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }
    }
}
