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

namespace FlexiMvvm.DependencyInjection
{
    public sealed class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, ServiceFactory> _serviceFactories = new Dictionary<Type, ServiceFactory>();

        public void Add<TInterface, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface : notnull
            where TImplementation : notnull, TInterface
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var serviceFactory = new ServiceFactory(() => factory(), reuse);

            _serviceFactories[typeof(TInterface)] = serviceFactory;
        }

        public void Add<TInterface1, TInterface2, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TImplementation : notnull, TInterface1, TInterface2
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var serviceFactory = new ServiceFactory(() => factory(), reuse);

            _serviceFactories[typeof(TInterface1)] = serviceFactory;
            _serviceFactories[typeof(TInterface2)] = serviceFactory;
        }

        public void Add<TInterface1, TInterface2, TInterface3, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var serviceFactory = new ServiceFactory(() => factory(), reuse);

            _serviceFactories[typeof(TInterface1)] = serviceFactory;
            _serviceFactories[typeof(TInterface2)] = serviceFactory;
            _serviceFactories[typeof(TInterface3)] = serviceFactory;
        }

        public void Add<TInterface1, TInterface2, TInterface3, TInterface4, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TInterface4 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3, TInterface4
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var serviceFactory = new ServiceFactory(() => factory(), reuse);

            _serviceFactories[typeof(TInterface1)] = serviceFactory;
            _serviceFactories[typeof(TInterface2)] = serviceFactory;
            _serviceFactories[typeof(TInterface3)] = serviceFactory;
            _serviceFactories[typeof(TInterface4)] = serviceFactory;
        }

        public void Add<TInterface1, TInterface2, TInterface3, TInterface4, TInterface5, TImplementation>(
            Func<TImplementation> factory,
            Reuse reuse = Reuse.Transient)
            where TInterface1 : notnull
            where TInterface2 : notnull
            where TInterface3 : notnull
            where TInterface4 : notnull
            where TInterface5 : notnull
            where TImplementation : notnull, TInterface1, TInterface2, TInterface3, TInterface4, TInterface5
        {
            if (factory == null)
                throw new ArgumentNullException(nameof(factory));

            var serviceFactory = new ServiceFactory(() => factory(), reuse);

            _serviceFactories[typeof(TInterface1)] = serviceFactory;
            _serviceFactories[typeof(TInterface2)] = serviceFactory;
            _serviceFactories[typeof(TInterface3)] = serviceFactory;
            _serviceFactories[typeof(TInterface4)] = serviceFactory;
            _serviceFactories[typeof(TInterface5)] = serviceFactory;
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(_serviceFactories);
        }
    }
}
