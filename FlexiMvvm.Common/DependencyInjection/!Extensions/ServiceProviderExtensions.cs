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
using System.Diagnostics.CodeAnalysis;
using FlexiMvvm.Formatters;

namespace FlexiMvvm.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static T GetRequiredService<T>(this IServiceProvider serviceProvider)
            where T : notnull
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return (T)serviceProvider.GetRequiredService(typeof(T));
        }

        public static object GetRequiredService(this IServiceProvider serviceProvider, Type serviceType)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));
            if (serviceType == null)
                throw new ArgumentNullException(nameof(serviceType));

            var service = serviceProvider.GetService(serviceType);

            if (service == null)
            {
                throw new InvalidOperationException(
                    $"Service of type '{TypeFormatter.FormatName(serviceType)}' is not registered in the service collection. " +
                    $"Use '{TypeFormatter.FormatName<IServiceCollection>()}.{nameof(IServiceCollection.Add)}' method for the service registration.");
            }

            return service;
        }

        [return: MaybeNull]
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
                throw new ArgumentNullException(nameof(serviceProvider));

            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
