using System;
using System.Collections.Generic;

namespace FlexiMvvm.DependencyInjection
{
    internal sealed class ServiceProvider : IServiceProvider
    {
        private readonly IDictionary<Type, ServiceFactory> _serviceFactories;

        internal ServiceProvider(IDictionary<Type, ServiceFactory> serviceFactories)
        {
            _serviceFactories = serviceFactories;
        }

        public object? GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            object? service = null;

            if (_serviceFactories.TryGetValue(serviceType, out var serviceFactory))
            {
                service = serviceFactory.Get();
            }

            return service;
        }
    }
}
