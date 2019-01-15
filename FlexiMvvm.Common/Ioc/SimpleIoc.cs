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
using FlexiMvvm.Formatters;
using JetBrains.Annotations;

namespace FlexiMvvm.Ioc
{
    public sealed class SimpleIoc : ISimpleIoc
    {
        [CanBeNull]
        private Dictionary<Type, ItemProvider> _itemsProviders;

        [NotNull]
        private Dictionary<Type, ItemProvider> ItemsProviders => _itemsProviders ?? (_itemsProviders = new Dictionary<Type, ItemProvider>());

        public void Register<T>(Func<T> factory, Reuse reuse = Reuse.Transient)
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            ItemsProviders[typeof(T)] = new ItemProvider(() => factory(), reuse);
        }

        public T Get<T>()
        {
            if (_itemsProviders != null && _itemsProviders.TryGetValue(typeof(T), out var itemProvider))
            {
                var instance = (T)itemProvider.Get();

                if (instance == null)
                {
                    throw new InvalidOperationException(
                        $"\"{TypeFormatter.FormatName<IDependencyProvider>()}.{nameof(IDependencyProvider.Get)}\" " +
                        $"returned \"null\" for the \"{TypeFormatter.FormatName<T>()}>\" type instance.");
                }

                return instance;
            }

            throw new InvalidOperationException(
                $"Instance factory is not registered for the \"{TypeFormatter.FormatName<T>()}\" type. " +
                $"Use \"{TypeFormatter.FormatName<ISimpleIoc>()}.{nameof(ISimpleIoc.Register)}\" method for the factory registration.");
        }
    }
}
